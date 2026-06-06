namespace Excavator.Parts.Arm.Boom;

public class RightBoom(
    ArmTransform parent,
    DipperParams dipperParams,
    SpacingParams spacingParams,
    BoomParams boomParams,
    LogoParams logoParams,
    ArmKinematics kinematics,
    BoomSideParams parameters,
    LogoLettersRight logoLettersRight
) : Part
{
    // Capturing the injected Part as a property keeps it in the DI tree (so it renders) and avoids the CS9113 unread-parameter warning.
    public LogoLettersRight LogoLettersRight { get; } = logoLettersRight;

    public override Computed<Transform> Transform { get; } =
        new(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = -dipperParams.Width / 2.0 - spacingParams.Spacing - boomParams.Width,
                }
            )
            * kinematics.BoomRotation
        );
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateBooleanDifference(
                    firstBrep: ((Brep)parameters.Boom.Geometry.Value)
                        .DuplicateBrep()
                        .MakeOutwards(),
                    secondBrep: (Brep)
                        ((Brep)parameters.Well.Geometry.Value)
                            .DuplicateBrep()
                            .MakeOutwards()
                            .WithTranslation(
                                translation: new Vector3d
                                {
                                    X = logoParams.Depth / 2.0,
                                    Y = boomParams.Length / 2.0 + logoParams.LengthOffset,
                                    Z = boomParams.Height / 2.0,
                                }
                            ),
                    tolerance: AbsoluteTolerance
                )
                .Single()
        );
}
