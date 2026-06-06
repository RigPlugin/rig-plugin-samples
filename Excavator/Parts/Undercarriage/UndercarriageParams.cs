namespace Excavator.Parts.Undercarriage;

public class UndercarriageParams(SpacingParams spacing, TrackParams trackParams) : Component
{
    public SpacingParams Spacing { get; } = spacing;
    public TrackParams TrackParams { get; } = trackParams;

    public Signal<double> Length { get; } = new(200);
    public Signal<double> NumberOfWheels { get; } = new(4);
    public Signal<double> Width { get; } = new(180);

    public double Height => WheelDiameter + (TrackParams.Thickness * 2) + (Spacing.Spacing * 2);
    public double WheelDiameter =>
        (Length - (TrackParams.Thickness * 2) - (Spacing.Spacing * ((double)NumberOfWheels + 1)))
        / (double)NumberOfWheels;
    public double WheelRadius => WheelDiameter / 2;
}
