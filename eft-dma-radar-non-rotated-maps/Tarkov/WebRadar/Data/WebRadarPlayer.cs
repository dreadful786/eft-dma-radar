using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer.Plugins;
using eft_dma_radar_non_rotated_maps.Tarkov.Loot;
using eft_dma_shared.Common.ESP;
using eft_dma_shared.Common.Unity;
using MessagePack;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections.Generic;
using System.Numerics;

namespace eft_dma_radar_non_rotated_maps.Tarkov.WebRadar.Data
{
    [MessagePackObject]
    public readonly struct WebRadarPlayer
    {
        /// <summary>
        /// Player Name.
        /// </summary>
        [Key(0)]
        public readonly string Name { get; init; }
        
        /// <summary>
        /// Player Type (PMC, Scav, etc.).
        /// </summary>
        [Key(1)]
        public readonly WebPlayerType Type { get; init; }

        /// <summary>
        /// True if the player is active, otherwise false.
        /// </summary>
        [Key(2)]
        public readonly bool IsActive { get; init; }

        /// <summary>
        /// True if the player is alive, otherwise false.
        /// </summary>
        [Key(3)]
        public readonly bool IsAlive { get; init; }

        /// <summary>
        /// Unity World Position.
        /// </summary>
        [Key(4)]
        public readonly Vector3 Position { get; init; }

        /// <summary>
        /// Unity World Rotation.
        /// </summary>
        [Key(5)]
        public readonly Vector2 Rotation { get; init; }

        /// <summary>
        /// Players Gear Value.
        /// </summary>
        [Key(6)]
        public readonly int Value { get; init; }

        /// <summary>
        /// Player Gear Data.
        /// </summary>
        [Key(7)] public string PrimaryWeapon { get; init; }
        [Key(8)] public string SecondaryWeapon { get; init; }
        [Key(9)] public string Armor { get; init; }
        [Key(10)] public string Helmet { get; init; }
        [Key(11)] public string Backpack { get; init; }
        [Key(12)] public string Rig { get; init; }
        [Key(13)] public float KD { get; init; }
        [Key(14)] public float TotalHoursPlayed { get; init; }

        public override string ToString() =>
            $"{Name} [{Type}] - Weapons: {PrimaryWeapon}, {SecondaryWeapon} | Gear: {Armor}, {Helmet}, {Backpack}, {Rig}";

        /// <summary>
        /// Create a WebRadarPlayer from a full Player Object.
        /// </summary>
        /// <param name="player">Full EFT Player Object.</param>
        /// <returns>Compact WebRadarPlayer object.</returns>
        public static WebRadarPlayer CreateFromPlayer(Player player)
        {
            if (player == null)
            {
                return new WebRadarPlayer
                {
                    Name = "Unknown",
                    Type = WebPlayerType.Bot,
                    IsActive = false,
                    IsAlive = false,
                    Position = Vector3.Zero,
                    Rotation = Vector2.Zero,
                    Value = 0,
                    KD = 0f, // AI players should always have KD = 0f
                    TotalHoursPlayed = 0f, // AI players should always have 0 hours
                    PrimaryWeapon = "None",
                    SecondaryWeapon = "None",
                    Armor = "None",
                    Helmet = "None",
                    Backpack = "None",
                    Rig = "None"
                };
            }

            WebPlayerType type = player is LocalPlayer ?
                WebPlayerType.LocalPlayer : player.IsFriendly ?
                WebPlayerType.Teammate : player.IsHuman ?
                player.IsScav ? WebPlayerType.PlayerScav : WebPlayerType.Player
                : WebPlayerType.Bot;

            bool isAI = player.IsAI;

            // Get KD and total playtime
            float kd = 0f;
            float totalHoursPlayed = 0f;
            if (!isAI && player is ObservedPlayer observed)
            {
                kd = observed.Profile?.Overall_KD ?? 0f;
                totalHoursPlayed = observed.Profile?.Hours ?? 0f;
            }

            return new WebRadarPlayer
            {
                Name = player.Name ?? "Unknown",
                Type = type,
                IsActive = player.IsActive,
                IsAlive = player.IsAlive,
                Position = player.Position,
                Rotation = player.Rotation,
                Value = player.Gear?.Value ?? 0,
                KD = kd,
                TotalHoursPlayed = totalHoursPlayed,
                PrimaryWeapon = player.Gear?.Equipment?.TryGetValue("FirstPrimaryWeapon", out var primary) == true ? primary.Long : "None",
                SecondaryWeapon = player.Gear?.Equipment?.TryGetValue("SecondPrimaryWeapon", out var secondary) == true ? secondary.Long : "None",
                Armor = player.Gear?.Equipment?.TryGetValue("ArmorVest", out var armor) == true ? armor.Long : "None",
                Helmet = player.Gear?.Equipment?.TryGetValue("Headwear", out var helmet) == true ? helmet.Long : "None",
                Backpack = player.Gear?.Equipment?.TryGetValue("Backpack", out var backpack) == true ? backpack.Long : "None",
                Rig = player.Gear?.Equipment?.TryGetValue("TacticalVest", out var rig) == true ? rig.Long : "None"
            };
        }
    }
}
