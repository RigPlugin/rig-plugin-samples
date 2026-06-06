namespace Excavator.Parts.Undercarriage.Tracks;

public abstract class Track(TrackGeometry track) : Part
{
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Track.Index });
    public override Computed<GeometryBase> Geometry { get; } = new(() => track.Geometry.Value);
}
