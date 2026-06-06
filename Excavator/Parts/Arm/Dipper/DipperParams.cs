namespace Excavator.Parts.Arm.Dipper;

public class DipperParams(FilletingParams filleting) : Component
{
    public FilletingParams Filleting { get; } = filleting;

    public Signal<double> Height { get; } = new(30);
    public Signal<double> Length { get; } = new(150);
    public Signal<double> Width { get; } = new(10);
}
