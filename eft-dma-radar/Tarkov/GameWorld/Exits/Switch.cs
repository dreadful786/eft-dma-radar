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

namespace eft_dma_radar.Tarkov.GameWorld.Exits
{
    /// <summary>
    /// Represents an interactive switch on the map
    /// </summary>
    public sealed class Switch : IMouseoverEntity, IMapEntity, IESPEntity
    {
        private Vector3 _position;
        public ref Vector3 Position => ref _position;

        public string Name { get; set; }
        public string SwitchInfo { get; set; }
        public Switch(Vector3 position, string name)
        {
            _position = position;
            Name = name;
            SwitchInfo = GetDescriptionFromName(name);
        }

        /// <summary>
        /// Generate a description based on the switch name
        /// </summary>
        private string GetDescriptionFromName(string name)
        {
            if (name.Contains("power", StringComparison.OrdinalIgnoreCase))
            {
                return "Controls power to an area";
            }
            else if (name.Contains("alarm", StringComparison.OrdinalIgnoreCase))
            {
                return "Triggers an alarm when activated";
            }
            else if (name.Contains("door", StringComparison.OrdinalIgnoreCase))
            {
                return "Opens a locked door";
            }
            else if (name.Contains("extract", StringComparison.OrdinalIgnoreCase) ||
                     name.Contains("exfil", StringComparison.OrdinalIgnoreCase))
            {
                return "Activates an extraction point";
            }
            else if (name.Contains("light", StringComparison.OrdinalIgnoreCase))
            {
                return "Controls lighting in an area";
            }

            return "Activates something on the map";
        }

        /// <summary>
        /// Draw the switch on the radar map
        /// </summary>
        public void Draw(SKCanvas canvas, LoneMapParams mapParams, ILocalPlayer localPlayer)
        {
            var heightDiff = localPlayer.Position.Y - Position.Y;
            var paint = GetPaint();
            var point = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);
            MouseoverPosition = new Vector2(point.X, point.Y);

            SKPaints.ShapeOutline.StrokeWidth = 1f;
            float size = 8f * MainForm.UIScale;

            if (heightDiff > 1.75f) // switch is above player
            {
                using var path = point.GetUpArrow(5f * MainForm.UIScale);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
            }
            else if (heightDiff < -1.75f) // switch is below player
            {
                using var path = point.GetDownArrow(5f * MainForm.UIScale);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paint);
            }
            else // switch is level with player
            {
                canvas.DrawRect(point.X - size / 2, point.Y - size / 2, size, size, SKPaints.ShapeOutline);
                canvas.DrawRect(point.X - size / 2, point.Y - size / 2, size, size, paint);
            }
        }

        /// <summary>
        /// Draw mouseover information when hovering over the switch
        /// </summary>
        public void DrawMouseover(SKCanvas canvas, LoneMapParams mapParams, LocalPlayer localPlayer)
        {
            var point = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);

            // Save the current canvas state
            canvas.Save();

            // Rotate the canvas 180 degrees around the switch point to counteract the main rotation
            canvas.RotateDegrees(180, point.X, point.Y);

            // Create lines for the mouseover text
            List<string> lines = new List<string>
            {
                $"Switch: {Name}"
            };

            if (!string.IsNullOrEmpty(SwitchInfo))
            {
                lines.Add(SwitchInfo);
            }

            // Calculate dimensions
            float padding = 4f * MainForm.UIScale;
            float lineHeight = 14f * MainForm.UIScale;
            float maxWidth = 0;

            // Measure text width for each line
            foreach (var line in lines)
            {
                float width = SKPaints.TextMouseover.MeasureText(line);
                maxWidth = Math.Max(maxWidth, width);
            }

            // Calculate total height needed
            float totalHeight = lines.Count * lineHeight + (padding * 2);

            // Draw background with proper dimensions
            SKRect rect = new SKRect(
                point.X - maxWidth / 2 - padding,
                point.Y - totalHeight + padding,
                point.X + maxWidth / 2 + padding,
                point.Y + padding
            );

            canvas.DrawRect(rect, SKPaints.PaintTransparentBacker);

            // Calculate starting Y position for the first line of text
            float startY = point.Y - totalHeight + padding + lineHeight;

            // Draw text lines with proper spacing
            for (int i = 0; i < lines.Count; i++)
            {
                float yPos = startY + (i * lineHeight);
                canvas.DrawText(
                    lines[i],
                    point.X - SKPaints.TextMouseover.MeasureText(lines[i]) / 2,
                    yPos,
                    SKPaints.TextMouseover
                );
            }

            // Restore the canvas state
            canvas.Restore();
        }

        /// <summary>
        /// Draw ESP for the switch, similar to exfil points
        /// </summary>
            public void DrawESP(SKCanvas canvas, LocalPlayer localPlayer)
            {
                if (!CameraManagerBase.WorldToScreen(ref Position, out var screenPos))
                {
                    return;
                }

                canvas.DrawText(Name, screenPos, SKPaints.TextSwitchesESP);
                if (ESP.Config.ShowDistances)
                {
                    var distance = Vector3.Distance(localPlayer.Position, Position);
                    var distanceText = $"{distance:F0}m";
                    var distancePoint = new SKPoint(screenPos.X, screenPos.Y + 16f * ESP.Config.FontScale);
                    canvas.DrawText(distanceText, distancePoint, SKPaints.TextSwitchesESP);
                }
            }
        /// <summary>
        /// Convert world position to screen position
        /// </summary>
        private ScreenPoint WorldToScreen(Vector3 worldPos)
        {
            // Replace this with the actual implementation for converting world coordinates to screen coordinates
            // This is a placeholder implementation
            return new ScreenPoint { X = 400, Y = 300, IsValid = true };
        }

        /// <summary>
        /// Simple screen point structure
        /// </summary>
        private struct ScreenPoint
        {
            public float X;
            public float Y;
            public bool IsValid;
        }

        /// <summary>
        /// Get the appropriate ESP color based on switch type
        /// </summary>
        private SKColor GetESPColor()
        {
            return SKColors.Orange; // Orange color for all switches
        }

        /// <summary>
        /// Cached mouseover position for hover detection
        /// </summary>
        public Vector2 MouseoverPosition { get; set; }

        /// <summary>
        /// Get the appropriate paint color based on switch type
        /// </summary>
        private SKPaint GetPaint()
        {
            return new SKPaint
            {
                Color = SKColors.Orange, // Orange color for all switches
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };
        }
    }
}