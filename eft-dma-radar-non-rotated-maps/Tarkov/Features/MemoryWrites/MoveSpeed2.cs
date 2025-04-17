using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;
using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Unity;
using eft_dma_shared.Common.Unity.Collections;

namespace eft_dma_radar_non_rotated_maps.Tarkov.Features.MemoryWrites
{
    public sealed class MoveSpeed2 : MemWriteFeature<MoveSpeed2>
    {
        private bool _set = false;

        public override bool Enabled
        {
            get => MemWrites.Config.MoveSpeed2;
            set
            {
                MemWrites.Config.MoveSpeed2 = value;
                if (value)
                {
                    // Disable MoveSpeed if MoveSpeed2 is enabled
                    MoveSpeed.Instance.Enabled = false;
                }
                ApplySpeed();
            }
        }

        protected override TimeSpan Delay => TimeSpan.FromMilliseconds(100);

        public override void TryApply(ScatterWriteHandle writes)
        {
            ApplySpeed();
        }

        private void ApplySpeed()
        {
            const float baseSpeed = 1.0f;
            const float increasedSpeed = 1.4f; // Any higher risks a ban 
            try
            {
                if (Memory.LocalPlayer is LocalPlayer localPlayer)
                {
                    bool enabled = Enabled;
                    var pAnimators = Memory.ReadPtr(localPlayer + Offsets.Player._animators);
                    using var animators = MemArray<ulong>.Get(pAnimators);
                    var a = Memory.ReadPtrChain(animators[0], new uint[] { Offsets.BodyAnimator.UnityAnimator, ObjectClass.MonoBehaviourOffset });
                    var current = Memory.ReadValue<float>(a + UnityOffsets.UnityAnimator.Speed, false);
                    ValidateSpeed(current);

                    if (enabled && !_set)
                    {
                        Memory.WriteValueEnsure(a + UnityOffsets.UnityAnimator.Speed, increasedSpeed);
                        _set = true;
                        LoneLogging.WriteLine("Move Speed2 [On]");
                    }
                    else if (!enabled && _set)
                    {
                        Memory.WriteValueEnsure(a + UnityOffsets.UnityAnimator.Speed, baseSpeed);
                        _set = false;
                        LoneLogging.WriteLine("Move Speed2 [Off]");
                    }
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR Setting Move Speed2: {ex}");
            }
        }

        static void ValidateSpeed(float speed)
        {
            const float baseSpeed = 1.0f;
            const float increasedSpeed = 1.4f;
            if (!float.IsNormal(speed) || speed < baseSpeed - 0.4f || speed > increasedSpeed + 0.4f)
                throw new ArgumentOutOfRangeException(nameof(speed));
        }

        public override void OnRaidStart()
        {
            _set = default;
        }
    }
}
