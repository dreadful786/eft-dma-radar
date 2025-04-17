using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Unity;


namespace LonesEFTRadar.Tarkov.Features.MemoryWrites
{
    class LongJump : MemWriteFeature<LongJump>
    {
        private static float original_AIR_CONTROL_SAME_DIR = 1.2f;
        private static float original_AIR_CONTROL_NONE_OR_ORT_DIR = 0.9f;
        private static ulong EFTHardSettingsInstance = 0;
        private bool isApplied = false;

        public override bool Enabled
        {
            get => MemWrites.Config.LongJump;
            set => MemWrites.Config.LongJump = value;
        }

        public override bool CanRun => base.CanRun && Utils.IsValidVirtualAddress(LongJump.EFTHardSettingsInstance);

        public override void TryApply(ScatterWriteHandle writes)
        {
            try
            {
                if (this.Enabled)
                {
                    writes.AddValueEntry(LongJump.EFTHardSettingsInstance + Offsets.EFTHardSettings.AIR_CONTROL_SAME_DIR, LongJump.original_AIR_CONTROL_SAME_DIR * MemWrites.Config.LongJumpMultiplier);
                    writes.AddValueEntry(LongJump.EFTHardSettingsInstance + Offsets.EFTHardSettings.AIR_CONTROL_NONE_OR_ORT_DIR, LongJump.original_AIR_CONTROL_NONE_OR_ORT_DIR * MemWrites.Config.LongJumpMultiplier);
                    writes.Callbacks += () =>
                    {
                        if (!this.isApplied)
                        {
                            this.isApplied = true;
                            LoneLogging.WriteLine($"{this.GetType().Name} [ON]");
                        }
                    };
                }
                else if (!this.Enabled)
                {
                    writes.AddValueEntry(LongJump.EFTHardSettingsInstance + Offsets.EFTHardSettings.AIR_CONTROL_SAME_DIR, LongJump.original_AIR_CONTROL_SAME_DIR);
                    writes.AddValueEntry(LongJump.EFTHardSettingsInstance + Offsets.EFTHardSettings.AIR_CONTROL_NONE_OR_ORT_DIR, LongJump.original_AIR_CONTROL_NONE_OR_ORT_DIR);
                    writes.Callbacks += () =>
                    {
                        if (this.isApplied)
                        {
                            this.isApplied = false;
                            LoneLogging.WriteLine($"{this.GetType().Name} [OFF]");
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR configuring {this.GetType().Name}: {ex}");
            }
        }

        public override void OnRaidStart()
        {
            base.OnRaidStart();

            if (LongJump.EFTHardSettingsInstance == 0)
                LongJump.EFTHardSettingsInstance = Memory.ReadPtr(MonoLib.MonoClass.Find("Assembly-CSharp", "EFTHardSettings", out var hardSettingsClassAddress).GetStaticFieldDataPtr());
        }

        public override void OnGameStop()
        {
            base.OnGameStop();
            LongJump.EFTHardSettingsInstance = default;
        }
    }
}