namespace Excavator.Parts.Undercarriage.Tracks;

public class TrackComponentParams(
    TrackParams trackParams,
    UndercarriageParams undercarriageParams,
    SpacingParams spacingParams,
    FilletingParams filletingParams
) : Component
{
    public TrackParams TrackParams { get; } = trackParams;
    public UndercarriageParams UndercarriageParams { get; } = undercarriageParams;
    public SpacingParams SpacingParams { get; } = spacingParams;
    public FilletingParams FilletingParams { get; } = filletingParams;
}
