using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.Tarkov.Features;
using eft_dma_radar.Tarkov.GameWorld;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Unity;
using eft_dma_shared.Common.Unity.Collections;

namespace eft_dma_radar.Tarkov.Features.MemoryWrites
{
    public sealed class BigHead : MemWriteFeature<BigHead>
    {
        private readonly ConcurrentDictionary<ulong, Vector3> _modifiedPlayers = new();
        private readonly Vector3 _defaultScale = new Vector3(1, 1, 1);
        private bool _wasEnabled = false;

        public override bool Enabled
        {
            get => MemWrites.Config.BigHead.Enabled;
            set => MemWrites.Config.BigHead.Enabled = value;
        }

        protected override TimeSpan Delay => TimeSpan.FromMilliseconds(100);

        public override void TryApply(ScatterWriteHandle writes)
        {
            try
            {
                var isCurrentlyEnabled = Enabled;
                var justDisabled = _wasEnabled && !isCurrentlyEnabled;
                _wasEnabled = isCurrentlyEnabled;

                if (Memory.Game is LocalGameWorld game)
                {
                    if (isCurrentlyEnabled)
                    {
                        var scale = MemWrites.Config.BigHead.Scale;
                        var headScale = new Vector3(scale, scale, scale);

                        var players = game.Players.Where(x => x.IsHostileActive);

                        if (!players.Any())
                            return;

                        foreach (var player in players)
                        {
                            if (player.ErrorTimer.IsRunning && player.ErrorTimer.Elapsed.TotalMilliseconds > 100)
                                continue;

                            if (!_modifiedPlayers.TryGetValue(player.Base, out var currentScale) || currentScale != headScale)
                                if (player.Skeleton.Bones.TryGetValue(Bones.HumanHead, out var transform))
                                    ApplyHeadScale(player, game, transform, headScale);
                        }

                        var activePlayers = players.Select(p => p.Base).ToHashSet();
                        var inactivePlayerBases = _modifiedPlayers.Keys
                            .Where(baseAddr => !activePlayers.Contains(baseAddr))
                            .ToList();

                        foreach (var baseAddr in inactivePlayerBases)
                        {
                            _modifiedPlayers.TryRemove(baseAddr, out _);
                        }
                    }
                    else if (justDisabled && _modifiedPlayers.Count > 0)
                    {
                        ResetAllHeadScales(game);
                    }
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR configuring BigHead: {ex}");
            }
        }

        private void ApplyHeadScale(Player player, LocalGameWorld game, UnityTransform transform, Vector3 headScale)
        {
            try
            {
                using var writeHandle = new ScatterWriteHandle();
                var offset = transform.VerticesAddr + (uint)(transform.Index * 0x30) + 0x20;
                writeHandle.AddValueEntry(offset, headScale);
                _modifiedPlayers[player.Base] = headScale;
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR applying BigHead to player '{player.Name}': {ex}");
            }
        }

        private void ResetAllHeadScales(LocalGameWorld game)
        {
            try
            {
                foreach (var playerEntry in _modifiedPlayers)
                {
                    var playerBase = playerEntry.Key;
                    var player = game.Players.FirstOrDefault(p => p.Base == playerBase);

                    if (player == null || !player.IsActive)
                        continue;

                    if (player.Skeleton.Bones.TryGetValue(Bones.HumanHead, out var transform))
                    {
                        using var writeHandle = new ScatterWriteHandle();
                        var offset = transform.VerticesAddr + (uint)(transform.Index * 0x30) + 0x20;
                        writeHandle.AddValueEntry(offset, _defaultScale);
                    }
                }

                _modifiedPlayers.Clear();
                LoneLogging.WriteLine("Reset all player head scales to default");
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR resetting head scales: {ex}");
            }
        }

        public override void OnRaidStart()
        {
            _modifiedPlayers.Clear();
            _wasEnabled = false;
        }
    }
}