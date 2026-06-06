namespace Excavator.Parts.Body.Cab;

public class CabFrame(CabTransform transform, CabFrameParams parameters) : Part
{
    public override Computed<Transform> Transform => transform.Transform;
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
        {
            var frontWindow = (Brep)parameters.CabFrontWindowGeometry.Geometry.Value.Duplicate();
            var leftWindow = (Brep)parameters.CabSideWindowGeometry.Geometry.Value.Duplicate();
            var rightWindow = parameters
                .CabSideWindowGeometry.Geometry.Value.Duplicate()
                .Translate<Brep>(
                    new Vector3d
                    {
                        X = parameters.CabParams.Width - parameters.CabParams.WindowThickness,
                    }
                );
            var brep = Brep.CreateBooleanDifference(
                    firstSet: [(Brep)parameters.CabOuterBrep.Geometry.Value],
                    secondSet: [frontWindow, leftWindow, rightWindow],
                    tolerance: AbsoluteTolerance
                )
                .Single();
            return brep;
        });
}
