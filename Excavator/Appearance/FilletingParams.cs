namespace Excavator.Appearance;

public class FilletingParams : Component
{
    public Signal<BlendType> BlendType { get; } = new(Rhino.Geometry.BlendType.Fillet);
    public Signal<double> FilletRadius { get; } = new(3.0);
    public Signal<RailType> RailType { get; } = new(Rhino.Geometry.RailType.RollingBall);
}
