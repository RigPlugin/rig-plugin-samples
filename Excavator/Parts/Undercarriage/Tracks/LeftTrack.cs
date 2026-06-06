namespace Excavator.Parts.Undercarriage.Tracks;

public class LeftTrack(UndercarriageParams p, TrackGeometry track, LeftWheels wheels) : Track(track)
{
    public LeftWheels Wheels { get; } = wheels;

    public override Computed<Transform> Transform { get; } =
        new(() =>
            Rhino.Geometry.Transform.Translation(
                new Vector3d { X = (p.Width - p.TrackParams.Width) / 2.0 }
            )
        );
}
