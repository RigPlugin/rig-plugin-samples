namespace Excavator.Parts.Body.Cab;

public class CabFrontWindow(CabTransform transform, CabFrontWindowParams parameters) : Part
{
    public override Computed<Transform> Transform => transform.Transform;
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Glass.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() => parameters.CabFrontWindowGeometry.Geometry.Value);
}
