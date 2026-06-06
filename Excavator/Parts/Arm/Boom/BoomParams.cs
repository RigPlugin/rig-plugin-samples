namespace Excavator.Parts.Arm.Boom;

public class BoomParams(FilletingParams filleting) : Component
{
    public FilletingParams Filleting { get; } = filleting;

    public Signal<double> Height { get; } = new(30);
    public Signal<double> HoleRadius { get; } = new(10);
    public Signal<double> Length { get; } = new(220);
    public Signal<double> Width { get; } = new(10);
}
