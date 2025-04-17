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

namespace LonesEFTRadar.Tarkov.Features.MemoryWrites
{
    class UnclampFreeLook : MemWriteFeature<UnclampFreeLook>
    {
        private static Vector2 original_MOUSE_LOOK_HORIZONTAL_LIMIT = new Vector2(-40f, 40f);
        private static Vector2 original_MOUSE_LOOK_VERTICAL_LIMIT = new Vector2(-50f, 20f);
        private static Vector2 new_MOUSE_LOOK_HORIZONTAL_LIMIT = new Vector2(-float.MaxValue, float.MaxValue);
        private static Vector2 new_MOUSE_LOOK_VERTICAL_LIMIT = new Vector2(-float.MaxValue, float.MaxValue);
        private static ulong EFTHardSettingsInstance = 0;
        private bool isApplied = false;

        public override bool Enabled
        {
            get => MemWrites.Config.UnclampFreeLook;
            set => MemWrites.Config.UnclampFreeLook = value;
        }

        public override bool CanRun => base.CanRun && Utils.IsValidVirtualAddress(UnclampFreeLook.EFTHardSettingsInstance);

        public override void TryApply(ScatterWriteHandle writes)
        {
            if (!Utils.IsValidVirtualAddress(UnclampFreeLook.EFTHardSettingsInstance))
                return;

            try
            {
                if (this.Enabled)
                {
                    writes.AddValueEntry(UnclampFreeLook.EFTHardSettingsInstance + Offsets.EFTHardSettings.MOUSE_LOOK_HORIZONTAL_LIMIT, UnclampFreeLook.new_MOUSE_LOOK_HORIZONTAL_LIMIT);
                    writes.AddValueEntry(UnclampFreeLook.EFTHardSettingsInstance + Offsets.EFTHardSettings.MOUSE_LOOK_VERTICAL_LIMIT, UnclampFreeLook.new_MOUSE_LOOK_VERTICAL_LIMIT);
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
                    writes.AddValueEntry(UnclampFreeLook.EFTHardSettingsInstance + Offsets.EFTHardSettings.MOUSE_LOOK_HORIZONTAL_LIMIT, UnclampFreeLook.original_MOUSE_LOOK_HORIZONTAL_LIMIT);
                    writes.AddValueEntry(UnclampFreeLook.EFTHardSettingsInstance + Offsets.EFTHardSettings.MOUSE_LOOK_VERTICAL_LIMIT, UnclampFreeLook.original_MOUSE_LOOK_VERTICAL_LIMIT);
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

            if (UnclampFreeLook.EFTHardSettingsInstance == 0)
                UnclampFreeLook.EFTHardSettingsInstance = Memory.ReadPtr(MonoLib.MonoClass.Find("Assembly-CSharp", "EFTHardSettings", out var hardSettingsClassAddress).GetStaticFieldDataPtr());
        }
        public override void OnGameStop()
        {
            base.OnGameStop();
            UnclampFreeLook.EFTHardSettingsInstance = default;
        }
    }
}