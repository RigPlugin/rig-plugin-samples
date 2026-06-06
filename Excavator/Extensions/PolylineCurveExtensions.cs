namespace Excavator.Extensions;

public static class PolylineCurveExtensions
{
    public static PolylineCurve WithPoint(
        this PolylineCurve polylineCurve,
        int index,
        Point3d point
    )
    {
        var points = polylineCurve.ToPolyline();
        points[index] = point;
        return new PolylineCurve(points);
    }
}
