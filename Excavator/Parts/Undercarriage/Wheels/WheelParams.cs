namespace Excavator.Parts.Undercarriage.Wheels;

public class WheelParams(
    UndercarriageParams undercarriage,
    TrackParams track,
    FilletingParams filleting
) : Component
{
    public UndercarriageParams Undercarriage { get; } = undercarriage;
    public TrackParams Track { get; } = track;
    public FilletingParams Filleting { get; } = filleting;
}
