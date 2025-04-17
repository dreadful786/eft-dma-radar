using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer; // TEMP

namespace LonesEFTRadar.Tarkov.Features.MemoryWrites
{
    class InstantPoseChange : MemWriteFeature<InstantPoseChange>
    {
        private static float original_POSE_CHANGING_SPEED = 3f;
        private static float new_POSE_CHANGING_SPEED = float.MaxValue;
        private static ulong EFTHardSettingsInstance = 0;
        private bool isApplied = false;

        public override bool Enabled
        {
            get => MemWrites.Config.InstantPoseChange;
            set => MemWrites.Config.InstantPoseChange = value;
        }

        public override bool CanRun => base.CanRun && Utils.IsValidVirtualAddress(InstantPoseChange.EFTHardSettingsInstance);

        public override void TryApply(ScatterWriteHandle writes)
        {
            try
            {
                if (this.Enabled)
                {
                    writes.AddValueEntry(InstantPoseChange.EFTHardSettingsInstance + Offsets.EFTHardSettings.POSE_CHANGING_SPEED, InstantPoseChange.new_POSE_CHANGING_SPEED);
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
                    writes.AddValueEntry(InstantPoseChange.EFTHardSettingsInstance + Offsets.EFTHardSettings.POSE_CHANGING_SPEED, InstantPoseChange.original_POSE_CHANGING_SPEED);
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

            if (InstantPoseChange.EFTHardSettingsInstance == 0)
                InstantPoseChange.EFTHardSettingsInstance = Memory.ReadPtr(MonoLib.MonoClass.Find("Assembly-CSharp", "EFTHardSettings", out var hardSettingsClassAddress).GetStaticFieldDataPtr());
        }
        public override void OnGameStop()
        {
            base.OnGameStop();
            InstantPoseChange.EFTHardSettingsInstance = default;
        }
    }
}