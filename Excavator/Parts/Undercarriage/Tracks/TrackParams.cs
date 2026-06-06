namespace Excavator.Parts.Undercarriage.Tracks;

public class TrackParams : Component
{
    public Signal<double> Thickness { get; } = new(10);

    public Signal<double> Width { get; } = new(50);
}
