namespace Excavator.Parts.Arm.Logo;

public class LogoLettersGeometry(Document.LogoLetters logoLetters, LogoParams logoParams)
    : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
        {
            var curves = logoLetters.Geometries<Curve>();
            var center = curves
                .Select(c => c.GetBoundingBox(true))
                .Aggregate(BoundingBox.Union)
                .Center;
            return Brep.MergeBreps(
                curves
                    .Select(c =>
                        c.Translate<Curve>(-center.X - logoParams.Depth / 2.0, -center.Y, -center.Z)
                    )
                    .ExtrudeCurvesWithHoles(Vector3d.XAxis, logoParams.Depth, AbsoluteTolerance),
                AbsoluteTolerance
            );
        });
}
