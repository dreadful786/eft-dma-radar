using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.Tarkov.Features;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Players;
using eft_dma_shared.Common.Unity;
using eft_dma_shared.Common.Unity.Collections;

namespace eft_dma_radar.Tarkov.Features.MemoryWrites
{
    public sealed class FastWeaponOps : MemWriteFeature<FastWeaponOps>
    {
        private bool _set;
        private ulong _hands;
        public override bool Enabled
        {
            get => MemWrites.Config.FastWeaponOps;
            set => MemWrites.Config.FastWeaponOps = value;
        }

        protected override TimeSpan Delay => TimeSpan.FromMilliseconds(100);

        public override void TryApply(ScatterWriteHandle writes)
        {
            const float fast = 4f;
            const float normal = 1f;
            try
            {
                if (Memory.LocalPlayer is LocalPlayer localPlayer && ILocalPlayer.HandsController is ulong hands && hands.IsValidVirtualAddress())
                {
                    string className = ObjectClass.ReadName(hands);

                    // Always reset state when hands controller changes
                    if (hands != _hands)
                    {
                        _set = false; // Force reset state
                        _hands = hands;
                        LoneLogging.WriteLine($"FastWeaponOps detected hands change to {className}, resetting state");
                    }

                    // Check if this is a supported controller type
                    bool supportedController =
                        className.Contains("FirearmController") ||
                        className.Contains("KnifeController") ||
                        className.Contains("GrenadeHandsController");

                    if (supportedController)
                    {
                        // Get the animator reference which we'll need for both enabling and disabling
                        var pAnimators = Memory.ReadPtr(localPlayer + Offsets.Player._animators);
                        if (!pAnimators.IsValidVirtualAddress())
                        {
                            LoneLogging.WriteLine("Invalid animators pointer");
                            return;
                        }

                        using var animators = MemArray<ulong>.Get(pAnimators);
                        if (animators == null || animators.Count <= 1)
                        {
                            LoneLogging.WriteLine("Invalid animators array");
                            return;
                        }

                        var animatorAddress = Memory.ReadPtrChain(animators[1], new uint[] { Offsets.BodyAnimator.UnityAnimator, ObjectClass.MonoBehaviourOffset });
                        if (!animatorAddress.IsValidVirtualAddress())
                        {
                            LoneLogging.WriteLine("Invalid animator address");
                            return;
                        }

                        // Check current animator speed to determine our actual state
                        // This is crucial for handling switching back to previous weapons
                        var currentSpeed = Memory.ReadValue<float>(animatorAddress + UnityOffsets.UnityAnimator.Speed, false);

                        if (Enabled)
                        {
                            // Always apply aiming speed every frame while enabled
                            writes.AddValueEntry(localPlayer.PWA + Offsets.ProceduralWeaponAnimation._aimingSpeed, 9999f);

                            // If we need to set the fast animation speed (either first time or after switching weapons)
                            if (!_set || Math.Abs(currentSpeed - fast) > 0.1f)
                            {
                                try
                                {
                                    // Only update if the speed isn't already what we want
                                    if (Math.Abs(currentSpeed - fast) > 0.1f)
                                    {
                                        ThrowIfInvalidSpeed(currentSpeed);
                                        writes.AddValueEntry(animatorAddress + UnityOffsets.UnityAnimator.Speed, fast);

                                        writes.Callbacks += () =>
                                        {
                                            _set = true;
                                            LoneLogging.WriteLine($"FastWeaponOps [On] for {className}, speed changed: {currentSpeed} -> {fast}");
                                        };
                                    }
                                    else
                                    {
                                        // Speed is already what we want, just update state
                                        _set = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LoneLogging.WriteLine($"Failed to set animator speed ({currentSpeed}): {ex.Message}");
                                }
                            }
                        }
                        else if (_set || Math.Abs(currentSpeed - normal) > 0.1f)
                        {
                            // Reset to normal speed when feature is disabled
                            try
                            {
                                if (Math.Abs(currentSpeed - normal) > 0.1f)
                                {
                                    ThrowIfInvalidSpeed(currentSpeed);
                                    writes.AddValueEntry(animatorAddress + UnityOffsets.UnityAnimator.Speed, normal);
                                    writes.AddValueEntry(localPlayer.PWA + Offsets.ProceduralWeaponAnimation._aimingSpeed, normal);

                                    writes.Callbacks += () =>
                                    {
                                        _set = false;
                                        LoneLogging.WriteLine($"FastWeaponOps [Off] for {className}, speed changed: {currentSpeed} -> {normal}");
                                    };
                                }
                                else
                                {
                                    _set = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                LoneLogging.WriteLine($"Failed to reset animator speed ({currentSpeed}): {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR in FastWeaponOps.TryApply: {ex}");
            }

            static void ThrowIfInvalidSpeed(float speed)
            {
                if (!float.IsNormal(speed) || speed < normal - 0.2f || speed > fast + 0.2f)
                    throw new ArgumentOutOfRangeException(nameof(speed), $"Invalid speed: {speed}");
            }
        }

        public override void OnRaidStart()
        {
            _set = default;
            _hands = default;
        }
    }
}
