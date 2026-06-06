namespace Excavator.Parts.Body;

public class BodyParams(
    CabParams cab,
    SpacingParams spacing,
    EngineParams engine,
    UndercarriageParams undercarriage,
    BodyBaseParams bodyBase
) : Component
{
    public CabParams Cab { get; } = cab;
    public SpacingParams Spacing { get; } = spacing;
    public EngineParams Engine { get; } = engine;
    public UndercarriageParams Undercarriage { get; } = undercarriage;
    public BodyBaseParams BodyBase { get; } = bodyBase;
}
