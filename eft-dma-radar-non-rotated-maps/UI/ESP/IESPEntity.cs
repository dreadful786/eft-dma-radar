using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;
using eft_dma_shared.Common.Unity;

namespace eft_dma_radar_non_rotated_maps.UI.ESP
{
    /// <summary>
    /// Defines an entity that can be drawn on Fuser ESP.
    /// </summary>
    public interface IESPEntity : IWorldEntity
    {
        /// <summary>
        /// Draw this Entity on Fuser ESP.
        /// </summary>
        /// <param name="canvas">SKCanvas instance to draw on.</param>
        void DrawESP(SKCanvas canvas, LocalPlayer localPlayer);
    }
}
