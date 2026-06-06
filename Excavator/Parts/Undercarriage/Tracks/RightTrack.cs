namespace Excavator.Parts.Undercarriage.Tracks;

public class RightTrack(UndercarriageParams p, TrackGeometry track, RightWheels wheels)
    : Track(track)
{
    public RightWheels Wheels { get; } = wheels;

    public override Computed<Transform> Transform { get; } =
        new(() =>
            Rhino.Geometry.Transform.Translation(
                new Vector3d { X = -(p.Width - p.TrackParams.Width) / 2.0 }
            )
        );
}
