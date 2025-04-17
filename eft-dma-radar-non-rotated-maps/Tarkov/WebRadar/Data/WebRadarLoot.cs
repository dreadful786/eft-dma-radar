using eft_dma_radar_non_rotated_maps.Tarkov.Loot;
using eft_dma_shared.Common.Unity;
using MessagePack;

namespace eft_dma_radar_non_rotated_maps.Tarkov.WebRadar.Data
{
    [MessagePackObject]
    public readonly struct WebRadarLoot
    {
        /// <summary>
        /// Item's Short Name.
        /// </summary>
        [Key(0)]
        public readonly string ShortName { get; init; }

        /// <summary>
        /// Item's Price (Roubles).
        /// </summary>
        [Key(1)]
        public readonly int Price { get; init; }

        /// <summary>
        /// Item's Position.
        /// </summary>
        [Key(2)]
        public readonly Vector3 Position { get; init; }

        /// <summary>
        /// Item is Meds.
        /// </summary>
        [Key(3)]
        public bool IsMeds { get; init; }

        /// <summary>
        /// Item is Food.
        /// </summary>
        [Key(4)]
        public bool IsFood { get; init; }

        /// <summary>
        /// Item is Backpack.
        /// </summary>
        [Key(5)]
        public bool IsBackpack { get; init; }
        /// <summary>
        /// Create a WebRadarLoot object from a LootItem.
        /// </summary>
        /// <param name="loot">LootItem Object.</param>
        /// <returns>Compact WebRadarLoot object.</returns>
        public static WebRadarLoot CreateFromLoot(LootItem loot)
        {
            return new WebRadarLoot
            {
                ShortName = loot.ShortName,
                Price = loot.Price,
                Position = loot.Position,
                IsMeds = loot.IsMeds,
                IsFood = loot.IsFood,
                IsBackpack = loot.IsBackpack
            };
        }
    }
}
