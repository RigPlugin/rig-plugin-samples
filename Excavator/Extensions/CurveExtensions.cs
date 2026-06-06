namespace Excavator.Extensions;

public static class CurveExtensions
{
    public static PolyCurve CreateRaceTrack(Plane plane, double length, double height)
    {
        var radius = height / 2.0;
        var straightLength = length - height;

        var bottomLeft = plane.PointAt(radius, 0);
        var bottomRight = plane.PointAt(radius + straightLength, 0);
        var topRight = plane.PointAt(radius + straightLength, height);
        var topLeft = plane.PointAt(radius, height);

        var rightArcCenter = plane.PointAt(radius + straightLength, radius);
        var leftArcCenter = plane.PointAt(radius, radius);

        var rightArc = new Arc(
            new Circle(new Plane(rightArcCenter, plane.XAxis, plane.YAxis), radius),
            new Interval(-Math.PI / 2, Math.PI / 2)
        );

        var leftArc = new Arc(
            new Circle(new Plane(leftArcCenter, plane.XAxis, plane.YAxis), radius),
            new Interval(Math.PI / 2, 3 * Math.PI / 2)
        );

        var profile = new PolyCurve();
        profile.Append(new LineCurve(bottomLeft, bottomRight));
        profile.Append(new ArcCurve(rightArc));
        profile.Append(new LineCurve(topRight, topLeft));
        profile.Append(new ArcCurve(leftArc));

        return profile;
    }
}
