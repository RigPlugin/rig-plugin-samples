using Rig.Plugin;
using Rhino.Display;

namespace Excavator.Appearance;

public class OverlayTextConduit(OverlayParams overlayParams) : Component
{
    private readonly Conduit _conduit = new(overlayParams);

    public override void Initialize() => _conduit.Enabled = true;

    public override void Destroy() => _conduit.Enabled = false;

    private sealed class Conduit(OverlayParams overlayParams) : DisplayConduit
    {
        protected override void DrawForeground(DrawEventArgs e)
        {
            if (!overlayParams.ShowOverlay.Value)
                return;

            var mode = RigPlugIn.Instance?.Session.DefaultOutputMode;
            string text = $"Output: {mode?.ToString() ?? "None"}";

            var viewport = e.Viewport ?? e.Display?.Viewport;
            if (viewport == null)
                return;

            var bounds = viewport.Bounds;
            var point = new Point2d(bounds.Left + 10, bounds.Bottom - 20);
            var bg = Rhino.ApplicationSettings.AppearanceSettings.ViewportBackgroundColor;
            var textColor = System.Drawing.Color.FromArgb(255 - bg.R, 255 - bg.G, 255 - bg.B);
            e.Display?.Draw2dText(text, textColor, point, false, 16);
        }
    }
}
