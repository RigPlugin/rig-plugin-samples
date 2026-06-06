namespace Excavator.Appearance;

public class OverlayParams : Component
{
    private readonly RhinoDoc _doc;
    public Signal<bool> ShowOverlay { get; } = new(true);

    public OverlayParams(RhinoDoc doc)
    {
        _doc = doc;
        ShowOverlay.Subscribe(() => _doc?.Views.Redraw());
    }
}
