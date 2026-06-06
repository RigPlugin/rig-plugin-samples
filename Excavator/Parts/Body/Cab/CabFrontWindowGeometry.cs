namespace Excavator.Parts.Body.Cab;

public class CabFrontWindowGeometry(CabCrossSection cabCrossSection, CabParams cabParams)
    : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
        {
            var csPolyline = ((PolylineCurve)cabCrossSection.Geometry.Value).ToPolyline();
            var widthVec = Vector3d.XAxis * cabParams.Width;
            var pts = new[]
            {
                csPolyline[0],
                csPolyline[1],
                csPolyline[1] + widthVec,
                csPolyline[0] + widthVec,
                csPolyline[0],
            };

            var poly = new PolylineCurve(pts);

            poly.TryGetPlane(out Plane plane);

            var offsetCurve = poly.Offset(
                    plane: plane,
                    distance: -cabParams.WindowOffset,
                    tolerance: AbsoluteTolerance,
                    cornerStyle: CurveOffsetCornerStyle.Sharp
                )
                .Single();

            var extrusion = Surface
                .CreateExtrusion(
                    profile: offsetCurve,
                    direction: Vector3d.YAxis * cabParams.WindowThickness
                )
                .ToBrep();

            var brep = extrusion.CapPlanarHoles(AbsoluteTolerance);

            if (brep.SolidOrientation == BrepSolidOrientation.Inward)
            {
                brep.Flip();
            }

            return brep;
        });

    private Polyline CabCrossSectionPolyline =>
        ((PolylineCurve)cabCrossSection.Geometry.Value).ToPolyline();

    private Vector3d WidthVec => Vector3d.XAxis * cabParams.Width;
}
