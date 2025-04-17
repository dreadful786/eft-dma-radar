using System;
using System.Collections.Generic;
using System.Numerics;
using MessagePack;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;
using eft_dma_radar_non_rotated_maps.Tarkov.GameWorld;
using eft_dma_shared.Common.Misc.MessagePack;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer.Plugins;
using eft_dma_shared.Common.Misc;

namespace eft_dma_radar_non_rotated_maps.Tarkov.WebRadar.Data
{
    [MessagePackObject]
    public class EspServerPlayer
    {
        [Key(0)] public string Name { get; init; }
        [Key(1)] public WebPlayerType Type { get; init; }
        [Key(2)] public bool IsActive { get; init; }
        [Key(3)] public bool IsAlive { get; init; }
        [Key(4)] public Vector3 Position { get; init; }
        [Key(5)] public Vector2 Rotation { get; init; }
        [Key(6)] public int Value { get; init; }
        [Key(7)] public string PrimaryWeapon { get; init; }
        [Key(8)] public string SecondaryWeapon { get; init; }
        [Key(9)] public string Armor { get; init; }
        [Key(10)] public string Helmet { get; init; }
        [Key(11)] public string Backpack { get; init; }
        [Key(12)] public string Rig { get; init; }
        [Key(13)] public float KD { get; init; }
        [Key(14)] public float TotalHoursPlayed { get; init; }
        [Key(15)] public bool HasExfil { get; init; }
        [Key(16)]
        [MessagePackFormatter(typeof(Vector3DictionaryFormatter))]
        public Dictionary<string, Vector3> Skeleton { get; init; } = new();

        // ✅ Only LocalPlayer will have these values set
        [Key(17)] public bool IsScoped { get; init; }
        [Key(18)] public bool IsADS { get; init; }
        [Key(19)] public Vector3 FireportPosition { get; init; }

        /// <summary>
        /// Creates an `EspServerPlayer` object from a `Player` instance.
        /// </summary>
        public static EspServerPlayer CreateFromPlayer(Player player, LocalPlayer localPlayer = null, CameraManager cameraManager = null)
        {
            FirearmManager firearmManager = null;
            if (player is LocalPlayer lp)
            {
                firearmManager = new FirearmManager(lp); // ✅ Ensure FirearmManager is created
            }

            var fireportPos = firearmManager?.FireportPosition ?? Vector3.Zero;
            LoneLogging.WriteLine($"📡 ESP Server - Fireport Position for {player.Name}: {fireportPos}");

            if (player == null)
            {
                return new EspServerPlayer
                {
                    Name = "Unknown",
                    Type = WebPlayerType.Bot,
                    IsActive = false,
                    IsAlive = false,
                    Position = Vector3.Zero,
                    Rotation = Vector2.Zero,
                    Value = 0,
                    KD = 0f,
                    TotalHoursPlayed = 0f,
                    PrimaryWeapon = "None",
                    SecondaryWeapon = "None",
                    Armor = "None",
                    Helmet = "None",
                    Backpack = "None",
                    Rig = "None",
                    Skeleton = new Dictionary<string, Vector3>(),
                    HasExfil = false,
                    IsADS = false,
                    IsScoped = false,
                    FireportPosition = fireportPos // ✅ Should now be set properly
                };
            }

            WebPlayerType type = player is LocalPlayer ? WebPlayerType.LocalPlayer
                : player.IsFriendly ? WebPlayerType.Teammate
                : player.IsHuman ? (player.IsScav ? WebPlayerType.PlayerScav : WebPlayerType.Player)
                : WebPlayerType.Bot;

            bool isAI = player.IsAI;
            bool isLocalPlayer = player is LocalPlayer;

            float kd = 0f;
            float totalHoursPlayed = 0f;
            if (!isAI && player is ObservedPlayer observed)
            {
                kd = observed.Profile?.Overall_KD ?? 0f;
                totalHoursPlayed = observed.Profile?.Hours ?? 0f;
            }

            Dictionary<string, Vector3> skeleton = new();
            if (player.Skeleton?.Bones != null)
            {
                foreach (var bone in player.Skeleton.Bones)
                {
                    skeleton[bone.Key.ToString()] = bone.Value.Position;
                }
            }

            // ✅ Use CameraManager to check for ADS and Scoped for LocalPlayer only
            bool isADS = isLocalPlayer && localPlayer?.CheckIfADS() == true;
            bool isScoped = isADS && cameraManager?.isOpticCameraActive == true;

            // ✅ Ensure Fireport Position is logged correctly
            LoneLogging.WriteLine($"📡 ESP Server - Final Fireport Position for {player.Name}: {fireportPos}");
        
            return new EspServerPlayer
            {
                Name = player.Name ?? "Unknown",
                Type = player is LocalPlayer ? WebPlayerType.LocalPlayer
                    : player.IsFriendly ? WebPlayerType.Teammate
                    : player.IsHuman ? (player.IsScav ? WebPlayerType.PlayerScav : WebPlayerType.Player)
                    : WebPlayerType.Bot,
                IsActive = player.IsActive,
                IsAlive = player.IsAlive,
                Position = player.Position,
                Rotation = player.Rotation,
                Value = player.Gear?.Value ?? 0,
                KD = kd,
                TotalHoursPlayed = player is ObservedPlayer obs ? obs.Profile?.Hours ?? 0f : 0f,
                PrimaryWeapon = player.Gear?.Equipment?.TryGetValue("FirstPrimaryWeapon", out var primary) == true ? primary.Long : "None",
                SecondaryWeapon = player.Gear?.Equipment?.TryGetValue("SecondPrimaryWeapon", out var secondary) == true ? secondary.Long : "None",
                Armor = player.Gear?.Equipment?.TryGetValue("ArmorVest", out var armor) == true ? armor.Long : "None",
                Helmet = player.Gear?.Equipment?.TryGetValue("Headwear", out var helmet) == true ? helmet.Long : "None",
                Backpack = player.Gear?.Equipment?.TryGetValue("Backpack", out var backpack) == true ? backpack.Long : "None",
                Rig = player.Gear?.Equipment?.TryGetValue("TacticalVest", out var rig) == true ? rig.Long : "None",
                Skeleton = player.Skeleton?.Bones != null ? player.Skeleton.Bones.ToDictionary(b => b.Key.ToString(), b => b.Value.Position) : new Dictionary<string, Vector3>(),
                HasExfil = player.HasExfild,
                IsADS = player is LocalPlayer && localPlayer?.CheckIfADS() == true,
                IsScoped = player is LocalPlayer && localPlayer?.CheckIfADS() == true && cameraManager?.isOpticCameraActive == true,
                FireportPosition = fireportPos // ✅ Now FireportPosition should be set properly
            };
        }
    }
}
