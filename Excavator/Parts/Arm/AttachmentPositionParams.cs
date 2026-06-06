namespace Excavator.Parts.Arm;

public class AttachmentPositionParams : Component
{
    public class Bounds(int min, int max, int tick = 0)
    {
        public int Min { get; } = min;
        public int Max { get; } = max;
        public int Tick { get; } = tick;
    }

    public Signal<double> BodyBaseRotationAngle { get; } = new(0);
    public Bounds BodyBaseRotationBounds { get; } = new(-180, 180, 30);

    public Signal<double> BoomElevationAngle { get; } = new(25);
    public Bounds BoomElevationBounds { get; } = new(0, 50, 5);

    public Signal<double> DipperElevationAngle { get; } = new(-45);
    public Bounds DipperElevationBounds { get; } = new(-90, 0, 5);

    public Signal<double> BucketElevationAngle { get; } = new(0);
    public Bounds BucketElevationBounds { get; } = new(-30, 150);
}
