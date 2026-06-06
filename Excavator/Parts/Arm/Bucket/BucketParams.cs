namespace Excavator.Parts.Arm.Bucket;

public class BucketParams : Component
{
    public Signal<double> Height { get; } = new(60);
    public Signal<double> Thickness { get; } = new(3);
    public Signal<double> Width { get; } = new(80);

    public Point3d FixedEndCenter
    {
        get
        {
            var radius = Height / 2.0;
            return new Point3d(0, radius, Height);
        }
    }
}
