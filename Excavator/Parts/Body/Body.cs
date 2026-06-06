namespace Excavator.Parts.Body;

public class Body(BodyBase bodyBase, Engine.Engine engine, Cab.Cab cab) : Component
{
    public BodyBase BodyBase { get; } = bodyBase;
    public Engine.Engine Engine { get; } = engine;
    public Cab.Cab Cab { get; } = cab;
}
