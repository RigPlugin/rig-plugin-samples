namespace Excavator.Parts.Body.Cab;

public abstract class CabSideWindow(
    Computed<Rhino.Geometry.Transform> transform,
    CabSideWindowParams parameters
) : Part
{
    public override Computed<Rhino.Geometry.Transform> Transform { get; } = transform;
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Glass.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() => parameters.CabSideWindowGeometry.Geometry.Value);
}
