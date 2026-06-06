namespace Excavator.Parts.Body.Cab;

public class CabSideWindowCrossSection(CabCrossSection cabCrossSection, CabParams cabParams)
    : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
            ((PolylineCurve)cabCrossSection.Geometry.Value)
                .WithPoint(
                    index: 3,
                    point: ((PolylineCurve)cabCrossSection.Geometry.Value).ToPolyline()[3].WithZ(20)
                )
                .Offset(
                    plane: Plane.WorldYZ,
                    distance: cabParams.WindowOffset,
                    tolerance: AbsoluteTolerance,
                    cornerStyle: CurveOffsetCornerStyle.Sharp
                )
                .Single()
        );

    private Point3d CabCrossSectionPoint(int index) =>
        ((PolylineCurve)cabCrossSection.Geometry.Value).ToPolyline()[index];
}
