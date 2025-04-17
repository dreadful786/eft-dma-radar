using System.Numerics;
using MessagePack;
using eft_dma_radar_non_rotated_maps.Tarkov.Loot;

namespace eft_dma_radar_non_rotated_maps.Tarkov.WebRadar.Data
{
    [MessagePackObject]
    public class EspServerLoot
    {
        [Key(0)] public string Name { get; set; }
        [Key(1)] public int Price { get; set; }
        [Key(2)] public Vector3 Position { get; set; }

        public static EspServerLoot CreateFromLoot(LootItem loot)
        {
            return new EspServerLoot
            {
                Name = loot.Name,
                Price = loot.Price,
                Position = loot.Position
            };
        }
    }
}
