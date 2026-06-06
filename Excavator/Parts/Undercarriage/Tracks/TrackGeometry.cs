namespace Excavator.Parts.Undercarriage.Tracks;

public class TrackGeometry(TrackComponentParams parameters) : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateFromSweep(
                    rail: Curve.CreateFilletCornersCurve(
                        curve: new PolylineCurve(
                            points: new Rectangle3d(
                                plane: Plane.WorldYZ,
                                width: parameters.UndercarriageParams.Length,
                                height: parameters.UndercarriageParams.Height
                            ).ToPolyline()
                        ),
                        radius: parameters.UndercarriageParams.Height / 2,
                        tolerance: AbsoluteTolerance,
                        angleTolerance: AngleToleranceDegrees
                    ),
                    shape: Curve
                        .CreateFilletCornersCurve(
                            curve: new PolylineCurve(
                                points: new Rectangle3d(
                                    plane: Plane.WorldXY,
                                    width: parameters.TrackParams.Width,
                                    height: parameters.TrackParams.Thickness
                                ).ToPolyline()
                            ),
                            radius: parameters.FilletingParams.FilletRadius,
                            tolerance: AbsoluteTolerance,
                            angleTolerance: AngleToleranceDegrees
                        )
                        .Translate<Curve>(
                            -parameters.TrackParams.Width / 2,
                            0,
                            parameters.UndercarriageParams.Height / 2
                        ),
                    closed: true,
                    tolerance: AbsoluteTolerance
                )
                .Single()
                .Translate<Brep>(0, -parameters.UndercarriageParams.Length / 2, 0)
        );
}
