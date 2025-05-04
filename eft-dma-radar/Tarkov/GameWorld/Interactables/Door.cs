using eft_dma_radar.Tarkov.EFTPlayer;
using eft_dma_radar.UI.ESP;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.UI.Radar;
using eft_dma_shared.Common.ESP;
using eft_dma_shared.Common.Maps;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Misc.Data;
using eft_dma_shared.Common.Players;
using eft_dma_shared.Common.Unity;
using Microsoft.AspNetCore.Builder.Extensions;
using SkiaSharp;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eft_dma_radar.Tarkov.GameWorld.Interactables
{
    /// <summary>
    /// Represents an interactive Door on the map
    /// </summary>
    public sealed class Door : IMouseoverEntity, IMapEntity, IESPEntity
    {
        private Vector3 _position;
        private string _shortName;
        public ref Vector3 Position => ref _position;
        public ref string ShortName => ref _shortName;
        public string Name { get; set; }

        public Door(Vector3 position, string name, string shortName)
        {
            _position = position;
            Name = name;
            _shortName = shortName;
        }

        /// <summary>
        /// Draw the Door on the radar map
        /// </summary>
        public void Draw(SKCanvas canvas, LoneMapParams mapParams, ILocalPlayer localPlayer)
        {
            var heightDiff = Position.Y - localPlayer.Position.Y;
            var paint = GetPaint();
            var point = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);
            MouseoverPosition = new Vector2(point.X, point.Y);

            SKPaints.ShapeOutline.StrokeWidth = 1f;
            float size = 8f * MainForm.UIScale;

            if (heightDiff > 1.75f) // door is above player
            {
                using var path = point.GetUpArrow(5f * MainForm.UIScale);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
                canvas.DrawText("i", point.X, point.Y, SKPaints.DoorText);
            }
            else if (heightDiff < -1.75f) // door is below player
            {
                using var path = point.GetDownArrow(5f * MainForm.UIScale);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
                canvas.DrawText("i", point.X, point.Y, SKPaints.DoorText);
            }
            else // door is level with player 

            {
                canvas.DrawText("i", point.X, point.Y, SKPaints.DoorText);
            }
        }

        /// <summary>
        /// Draw mouseover information when hovering over the door
        /// </summary>
        public void DrawMouseover(SKCanvas canvas, LoneMapParams mapParams, LocalPlayer localPlayer)
        {
            // Save the current canvas state
            canvas.Save();

            // Get the quest location's position on the map
            var DoorPosition = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);

            // Apply a rotation transformation to the canvas
            float rotation = MainForm.Window._rotationDegrees;
            canvas.RotateDegrees(rotation, DoorPosition.X, DoorPosition.Y);

            // Adjust text orientation for 90° and 270° rotations
            if (rotation == 90 || rotation == 270)
            {
                canvas.RotateDegrees(180, DoorPosition.X, DoorPosition.Y);
            }


            // Create lines for the mouseover text
            List<string> lines = new();
            lines.Add($"Door:{Name}");
            lines.Add($"ShortName:{ShortName}");
            Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams).DrawMouseoverText(canvas, lines);

            // Restore the canvas state
            canvas.Restore();
        }

        /// <summary>
        /// Draw ESP for the door, similar to exfil points
        /// </summary>
        public void DrawESP(SKCanvas canvas, LocalPlayer localPlayer)
        {
            if (!CameraManagerBase.WorldToScreen(ref Position, out var screenPos))
            {
                return;
            }

            canvas.DrawText(ShortName, screenPos, SKPaints.TextDoorsESP);
            if (ESP.Config.ShowDistances)
            {
                var distance = Vector3.Distance(localPlayer.Position, Position);
                var distanceText = $"{distance:F0}m";
                var distancePoint = new SKPoint(screenPos.X, screenPos.Y + 16f * ESP.Config.FontScale);
                canvas.DrawText(distanceText, distancePoint, SKPaints.TextDoorsESP);
            }
        }
 
        /// <summary>
        /// Cached mouseover position for hover detection
        /// </summary>
        public Vector2 MouseoverPosition { get; set; }

        /// <summary>
        /// Get the appropriate paint color based on door type
        /// </summary>
        private SKPaint GetPaint()
        {
            return new SKPaint
            {
                Color = SKColors.Orange, // Orange color for all doors
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };
        }
    }
}