namespace Excavator.Parts.Arm.Logo;

public class LogoParams : Component
{
    public Signal<double> Depth { get; } = new(1.0);
    public Signal<double> LengthOffset { get; } = new(40.0);
}
