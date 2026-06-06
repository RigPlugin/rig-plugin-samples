namespace Excavator.Parts.Body.Cab;

public class CabCrossSection(CabParams cabParams) : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
            new PolylineCurve([
                .. new[]
                {
                    new Point3d(0, 0, 0),
                    new Point3d(0, 20, cabParams.Height),
                    new Point3d(0, cabParams.Length, cabParams.Height),
                    new Point3d(0, cabParams.Length, 0),
                    new Point3d(0, 0, 0),
                },
            ])
        );
}
