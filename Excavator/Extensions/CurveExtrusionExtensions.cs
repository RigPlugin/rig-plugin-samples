namespace Excavator.Extensions;

public static class CurveExtrusionExtensions
{
    public static Brep[] ExtrudeCurvesWithHoles(
        this IEnumerable<Curve> inputCurves,
        Vector3d dir,
        double height,
        double tolerance
    ) =>
        [
            .. Brep.CreatePlanarBreps(inputCurves, tolerance)
                .Select(planarBrep =>
                    planarBrep
                        .Faces[0]
                        .CreateExtrusion(
                            new LineCurve(Point3d.Origin, Point3d.Origin + dir * height),
                            true
                        )
                ),
        ];
}
