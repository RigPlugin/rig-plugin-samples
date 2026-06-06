namespace Excavator.Extensions;

public static class PolyCurveExtensions
{
    public static PolyCurve AppendAndReturn(this PolyCurve polyCurve, Curve curve)
    {
        polyCurve.Append(curve);
        return polyCurve;
    }

    public static PolyCurve CloseWithLine(this PolyCurve polyCurve)
    {
        polyCurve.Append(new LineCurve(polyCurve.PointAtEnd, polyCurve.PointAtStart));
        return polyCurve;
    }

    public static PolyCurve With(this PolyCurve polyCurve, Curve[] curves)
    {
        foreach (var curve in curves)
        {
            polyCurve.Append(curve);
        }
        return polyCurve;
    }
}
