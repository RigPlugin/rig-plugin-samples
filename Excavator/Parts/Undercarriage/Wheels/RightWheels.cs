namespace Excavator.Parts.Undercarriage.Wheels;

public class RightWheels(UndercarriageParams up) : PartArray<RightWheel>
{
    public override Computed<int> Count { get; } = new(() => (int)up.NumberOfWheels.Value);
}
