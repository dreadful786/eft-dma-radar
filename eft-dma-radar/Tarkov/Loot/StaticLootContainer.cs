using System.IO;
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

namespace eft_dma_radar.Tarkov.Loot
{
    public sealed class StaticLootContainer : LootContainer
    {
        //private static readonly IReadOnlyList<LootItem> _defaultLoot = new List<LootItem>(1);

        public override string Name { get; } = "Container";
        public override string ID { get; }

        /// <summary>
        /// True if the container has been searched by LocalPlayer or another Networked Entity.
        /// </summary>
        public bool Searched { get; }

        public StaticLootContainer(string containerId, bool opened, IReadOnlyList<LootItem> loot = null) : base(loot)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(containerId, nameof(containerId));
            this.ID = containerId;
            this.Searched = opened;
            if (EftDataManager.AllContainers.TryGetValue(containerId, out var container))
            {
                this.Name = container.ShortName ?? "Container";
            }
        }

        public override void Draw(SKCanvas canvas, LoneMapParams mapParams, ILocalPlayer localPlayer)
        {
            var dist = Vector3.Distance(localPlayer.Position, Position);
            var paints = GetPaints();
            if (dist > MainForm.Config.ContainerDrawDistance)
                return;
            var heightDiff = Position.Y - localPlayer.Position.Y;
            var point = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);
            MouseoverPosition = new Vector2(point.X, point.Y);
            SKPaints.ShapeOutline.StrokeWidth = 2f;
            if (heightDiff > 1.45) // loot is above player
            {
                using var path = point.GetUpArrow(4);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paints.Item1);
            }
            else if (heightDiff < -1.45) // loot is below player
            {
                using var path = point.GetDownArrow(4);
                canvas.DrawPath(path, SKPaints.ShapeOutline);
                canvas.DrawPath(path, paints.Item1);
            }
            else // loot is level with player
            {
                var size = 4 * MainForm.UIScale;
                canvas.DrawCircle(point, size, SKPaints.ShapeOutline);
                canvas.DrawCircle(point, size, paints.Item1);
            }
        }

        public override void DrawESP(SKCanvas canvas, LocalPlayer localPlayer)
        {
            var dist = Vector3.Distance(localPlayer.Position, Position);
            var paints = GetPaints();
            if (dist > ESP.Config.ContainerDrawDistance)
                return;
            if (!CameraManagerBase.WorldToScreen(ref Position, out var scrPos))
                return;
            var boxHalf = 2.75f * ESP.Config.FontScale; // was 3.5f
            var showDist = ESP.Config.ShowDistances || dist <= 10f;
            var boxPt = new SKRect(scrPos.X - boxHalf, scrPos.Y + boxHalf,
                scrPos.X + boxHalf, scrPos.Y - boxHalf);
            canvas.DrawRect(boxPt, SKPaints.PaintContainerLootESP);
            var textPt = new SKPoint(scrPos.X,
                scrPos.Y + 16f * ESP.Config.FontScale);

            // Define the custom SKPaint object with desired font properties
            var customTextPaint = new SKPaint
            {
                SubpixelText = true,
                Color = paints.Item1.Color, // Use the color from paints.Item1
                IsStroke = false,
                TextSize = SKPaints.TextContainerLootESP.TextSize, // Use the text size from TextContainerLootESP
                TextAlign = SKTextAlign.Center,
                TextEncoding = SKTextEncoding.Utf8,
                IsAntialias = true,
                Typeface = SKPaints.TextContainerLootESP.Typeface, // Use the typeface from TextContainerLootESP
                FilterQuality = SKFilterQuality.High
            };

            textPt.DrawESPText(canvas, this, localPlayer, showDist, customTextPaint, this.Name);

            IEnumerable<LootItem> filteredLoot = this.FilteredLoot;
            if (filteredLoot.Count() <= 0)
                return;

            List<string> lines = new List<string>();
            foreach (LootItem lootItem in filteredLoot)
                lines.Add(lootItem.GetUILabel(MainForm.Config.QuestHelper.Enabled));

            var lootItemPt = new SKPoint(scrPos.X, scrPos.Y + SKPaints.TextContainerLootESP.TextSize + 16f * ESP.Config.FontScale);
            lootItemPt.DrawESPText(canvas, this, localPlayer, false, SKPaints.TextContainerLootESP, lines.ToArray());
        }
        public override void DrawMouseover(SKCanvas canvas, LoneMapParams mapParams, LocalPlayer localPlayer)
        {
            // Save the current canvas state
            canvas.Save();

            // Get the quest location's position on the map
            var ContainerPosition = Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams);

            // Apply a rotation transformation to the canvas
            float rotation = MainForm.Window._rotationDegrees;
            canvas.RotateDegrees(rotation, ContainerPosition.X, ContainerPosition.Y);

            // Adjust text orientation for 90° and 270° rotations
            if (rotation == 90 || rotation == 270)
            {
                canvas.RotateDegrees(180, ContainerPosition.X, ContainerPosition.Y);
            }

            // Draw the mouseover text
            var lines = new List<string>() { this.Name };
            foreach (LootItem lootItem in FilteredLoot)
                lines.Add(lootItem.GetUILabel(MainForm.Config.QuestHelper.Enabled));
            Position.ToMapPos(mapParams.Map).ToZoomedPos(mapParams).DrawMouseoverText(canvas, lines);


            // Restore the canvas state
            canvas.Restore();
        }
    }
}
