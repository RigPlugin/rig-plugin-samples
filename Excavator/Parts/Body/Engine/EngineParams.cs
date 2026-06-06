namespace Excavator.Parts.Body.Engine;

public class EngineParams(UndercarriageParams undercarriage, FilletingParams filleting) : Component
{
    public UndercarriageParams Undercarriage { get; } = undercarriage;
    public FilletingParams Filleting { get; } = filleting;

    public Signal<double> Height { get; } = new(50);
    public Signal<double> Length { get; } = new(50);

    public double Width => Undercarriage.Width;
}
