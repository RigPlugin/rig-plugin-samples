namespace Excavator.Appearance;

public class SpacingParams : Component
{
    public Signal<double> Spacing { get; } = new(2.5);
}
