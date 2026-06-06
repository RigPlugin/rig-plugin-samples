namespace Excavator.Parts.Undercarriage;

public class Undercarriage(LeftTrack leftTrack, RightTrack rightTrack) : Component
{
    public LeftTrack LeftTrack { get; } = leftTrack;
    public RightTrack RightTrack { get; } = rightTrack;
}
