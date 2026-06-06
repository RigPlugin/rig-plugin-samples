namespace Excavator.Parts.Body.Cab;

public class CabParams : Component
{
    public Signal<double> Height { get; } = new(100);
    public Signal<double> Length { get; } = new(100);
    public Signal<double> Width { get; } = new(90);
    public Signal<double> WindowOffset { get; } = new(10);
    public Signal<double> WindowThickness { get; } = new(2);
}
