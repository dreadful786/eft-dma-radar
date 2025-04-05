using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.Tarkov.Loot;
using eft_dma_radar.Tarkov.WebRadar.Data;
using MessagePack;
using eft_dma_shared.Common.Misc.MessagePack;
using eft_dma_shared.Common.Misc;

namespace eft_dma_radar.Tarkov.WebRadar
{
    public static class EspServer
    {
        private static readonly List<WebSocket> _clients = new();
        private static readonly object _lock = new();

        public static async Task StartEspServer(string ip, int port)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                        .UseUrls($"http://{ip}:{port}")
                        .ConfigureServices(services => services.AddWebSockets(options => { }))
                        .Configure(app =>
                        {
                            app.UseWebSockets();
                            app.Run(AcceptWebSocketClients);
                        });
                })
                .Build();

            LoneLogging.WriteLine($"✅ ESP Server started on {ip}:{port}");

            // ✅ Start the ESP Worker (Fix)
            await Task.Run(() => EspServerWorker.Start());

            await host.RunAsync();
        }

        private static async Task AcceptWebSocketClients(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = 400;
                return;
            }

            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            lock (_lock)
            {
                _clients.Add(webSocket);
            }

            //LoneLogging.WriteLine($"🔹 New ESP client connected. Total clients: {_clients.Count}");

            try
            {
                var buffer = new byte[131072];
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                        break;
                }
            }
            catch { }
            finally
            {
                lock (_lock)
                {
                    _clients.Remove(webSocket);
                }
                LoneLogging.WriteLine("🔻 ESP client disconnected.");
            }
        }

        public static async Task BroadcastUpdate(EspServerUpdate update)
        {
            byte[] msgPackData = MessagePackSerializer.Serialize(update, MessagePackSerializerOptions.Standard.WithResolver(ResolverGenerator.Instance));

            lock (_lock)
            {
                _clients.RemoveAll(client => client.State != WebSocketState.Open);
            }

            if (_clients.Count == 0)
            {
                //LoneLogging.WriteLine("⚠️ No connected ESP clients to broadcast data.");
                return;
            }
            foreach (var client in _clients)
            {
                try
                {
                    await client.SendAsync(new ArraySegment<byte>(msgPackData), WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    LoneLogging.WriteLine($"❌ Error sending ESP update: {ex.Message}");
                }
            }
        }

    }

    public static class EspServerWorker
    {
        private static readonly TimeSpan _tickRate = TimeSpan.FromMilliseconds(100);
        private static readonly string msgPackFilePath = "esp_update.msgpack"; // ✅ MessagePack Save Location

        public static async void Start()
        {
            LoneLogging.WriteLine("🚀 ESP Server Worker started!");

            while (true)
            {
                try
                {
                    var update = new EspServerUpdate
                    {
                        Version = DateTime.UtcNow.Ticks,
                        InGame = Memory.InRaid,
                        Players = new List<EspServerPlayer>(),
                        Loot = new List<EspServerLoot>()
                    };

                    // Fetch players
                    if (Memory.Players is IReadOnlyCollection<Player> players && players.Count > 0)
                    {
                        update.Players.AddRange(players.Select(p => EspServerPlayer.CreateFromPlayer(p)));
                    }

                    // Fetch loot
                    if (Memory.Loot?.UnfilteredLoot is IReadOnlyCollection<LootItem> loot && loot.Count > 0)
                    {
                        update.Loot.AddRange(loot.Select(l => EspServerLoot.CreateFromLoot(l)));
                    }

                    // ✅ Serialize update to MessagePack
                    byte[] msgPackData = MessagePackSerializer.Serialize(update, MessagePackSerializerOptions.Standard.WithResolver(ResolverGenerator.Instance));


                    // ✅ Save MessagePack to file
                    await File.WriteAllBytesAsync(msgPackFilePath, msgPackData);
                    //LoneLogging.WriteLine($"📂 ESP MessagePack saved to: {msgPackFilePath}");

                    // ✅ Broadcast update
                    await EspServer.BroadcastUpdate(update);
                }
                catch (Exception ex)
                {
                    LoneLogging.WriteLine($"[EspServerWorker] Error: {ex.Message}");
                }

                // Wait for next update
                Thread.Sleep(_tickRate);
            }
        }
    }
}
