using System.Collections.Generic;
using MessagePack;

namespace eft_dma_radar_non_rotated_maps.Tarkov.WebRadar.Data
{
    [MessagePackObject]
    public class EspServerUpdate
    {
        [Key(0)] public long Version { get; set; }
        [Key(1)] public bool InGame { get; set; }
        [Key(2)] public List<EspServerPlayer> Players { get; set; }
        [Key(3)] public List<EspServerLoot> Loot { get; set; }
    }
}
