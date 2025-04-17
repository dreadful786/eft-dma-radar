using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;

namespace LonesEFTRadar.Tarkov.Features.MemoryWrites
{
    class InstantPlant : MemWriteFeature<InstantPlant>
    {
        public override bool Enabled
        {
            get => MemWrites.Config.InstantPlant;
            set => MemWrites.Config.InstantPlant = value;
        }

        protected override TimeSpan Delay => TimeSpan.FromMilliseconds(100);

        public override void TryApply(ScatterWriteHandle writes)
        {
            if (!this.Enabled)
                return;
            
            try
            {
                if (Memory.LocalPlayer is LocalPlayer localPlayer)
                {
                    var plantStatePtr = Memory.ReadPtr(localPlayer.MovementContext + Offsets.MovementContext.PlantState);
                    writes.AddValueEntry(plantStatePtr + Offsets.MovementState.PlantTime, 0.001f);
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR configuring InstantPlant: {ex}");
            }
        }
    }
}
