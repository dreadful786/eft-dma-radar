using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using eft_dma_radar_non_rotated_maps.Tarkov.GameWorld;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Misc.Config;
using eft_dma_shared.Common.Unity;
using eft_dma_shared.Common.Unity.LowLevel;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;

namespace eft_dma_radar_non_rotated_maps.Tarkov.Features.MemoryWrites
{
    public sealed class Chams : MemWriteFeature<Chams>
    {
        /// <summary>
        /// Chams Config.
        /// </summary>
        public static ChamsConfig Config { get; } = MemWrites.Config.Chams;

        public override bool Enabled
        {
            get => Config.Enabled;
            set => Config.Enabled = value;
        }

        protected override TimeSpan Delay => TimeSpan.FromMilliseconds(100);

        public override void TryApply(ScatterWriteHandle writes)
        {
            try
            {
                if (Enabled && Memory.Game is LocalGameWorld game)
                {
                    var cm = game.CameraManager;
                    var mode = Config.Mode; // Cache value

                    // Disable culling for VisCheck modes
                    if (mode is ChamsManager.ChamsMode.VisCheckFlat || mode is ChamsManager.ChamsMode.VisCheckGlow || 
                        mode is ChamsManager.ChamsMode.VisCheckWireframe)
                    {
                        ulong fpsView = cm.FPSCamera;
                        ulong opticView = cm.OpticCamera;
                        const bool targetCulling = false;

                        var cullingFps = Memory.ReadValue<bool>(fpsView + UnityOffsets.Camera.OcclusionCulling);
                        var cullingOptical = Memory.ReadValue<bool>(opticView + UnityOffsets.Camera.OcclusionCulling);

                        if (cullingFps != targetCulling)
                        {
                            writes.AddValueEntry(fpsView + UnityOffsets.Camera.OcclusionCulling, targetCulling);
                            LoneLogging.WriteLine($"FPS Culling -> {targetCulling}");
                        }
                        if (cullingOptical != targetCulling)
                        {
                            writes.AddValueEntry(opticView + UnityOffsets.Camera.OcclusionCulling, targetCulling);
                            LoneLogging.WriteLine($"Optical Culling -> {targetCulling}");
                        }
                    }

                    // Find all players needing Chams
                    var players = game.Players
                        .Where(x => x.IsHostileActive)
                        .Where(x => x.ChamsMode != mode);

                    if (!players.Any()) // Already Set
                        return;

                    using var hChamsScatter = new ScatterWriteHandle();

                    foreach (var player in players)
                    {
                        int materialID = GetMaterialID(mode, player); // Select correct material based on PlayerT

                        // Apply Chams to player
                        player.SetChams(hChamsScatter, game, mode, materialID);
                        LoneLogging.WriteLine($"Chams applied to {player.Name} ({player.Type})");
                    }
                }
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR configuring Chams: {ex}");
            }
        }
        private int GetMaterialID(ChamsManager.ChamsMode mode, Player player)
        {
            string playerTypeCategory = player.IsPmc || player.Type == Player.PlayerType.AIBoss ? "PMC" : "AI";

            if (ChamsManager.Materials.TryGetValue((mode, playerTypeCategory), out var material) && material.InstanceID < 0)
            {
                return material.InstanceID;
            }

            LoneLogging.WriteLine($"[ERROR] Could not retrieve material ID for {mode} - {playerTypeCategory}");
            return -1;
        }
    }
}
