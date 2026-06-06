namespace Excavator;

public class Excavator(
    Body body,
    Arm arm,
    Undercarriage undercarriage,
    OverlayTextConduit overlayTextConduit,
    Animation animation
) : Component
{
    public Body Body { get; } = body;
    public Arm Arm { get; } = arm;
    public Undercarriage Undercarriage { get; } = undercarriage;
    public OverlayTextConduit OverlayTextConduit { get; } = overlayTextConduit;
    public Animation Animation { get; } = animation;
}
