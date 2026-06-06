namespace Excavator.Parts.Undercarriage.Wheels;

public class LeftWheels(UndercarriageParams up) : PartArray<LeftWheel>
{
    public override Computed<int> Count { get; } = new(() => (int)up.NumberOfWheels.Value);
}
