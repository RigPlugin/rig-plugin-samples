namespace Excavator.Parts.Arm.Logo;

public class LogoWell(Document.LogoLetters logoLetters, LogoParams logoParams) : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
        {
            var bbox = logoLetters
                .Objects.Select(o => o.Geometry.GetBoundingBox(true))
                .Aggregate(BoundingBox.Union);
            var logoWidth = bbox.Max.Y - bbox.Min.Y;
            var rtHeight = bbox.Max.Z - bbox.Min.Z + 2.0;
            return new[]
            {
                CurveExtensions.CreateRaceTrack(
                    new Plane(
                        new Point3d(
                            -logoParams.Depth / 2.0,
                            -(logoWidth + rtHeight) / 2.0,
                            -rtHeight / 2.0
                        ),
                        Vector3d.YAxis,
                        Vector3d.ZAxis
                    ),
                    logoWidth + rtHeight,
                    rtHeight
                ),
            }.ExtrudeCurvesWithHoles(Vector3d.XAxis, logoParams.Depth, AbsoluteTolerance)[0];
        });
}
