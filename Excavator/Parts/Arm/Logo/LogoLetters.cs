namespace Excavator.Parts.Arm.Logo;

public abstract class LogoLetters(Computed<Transform> transform, LogoLettersGeometry logoLetters)
    : Part
{
    public override Computed<Transform> Transform { get; } = transform;
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() => logoLetters.Geometry.Value);
}
