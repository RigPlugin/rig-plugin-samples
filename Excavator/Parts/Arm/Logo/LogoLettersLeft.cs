namespace Excavator.Parts.Arm.Logo;

public class LogoLettersLeft(
    ArmTransform parent,
    DipperParams dipperParams,
    SpacingParams spacingParams,
    ArmKinematics kinematics,
    BoomParams boomParams,
    LogoParams logoParams,
    LogoLettersGeometry logoLetters
)
    : LogoLetters(
        new Computed<Rhino.Geometry.Transform>(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d { X = dipperParams.Width / 2.0 + spacingParams.Spacing }
            )
            * kinematics.BoomRotation
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = boomParams.Width - logoParams.Depth / 2.0,
                    Y = boomParams.Length / 2.0 + logoParams.LengthOffset,
                    Z = boomParams.Height / 2.0,
                }
            )
            * Rhino.Geometry.Transform.Rotation(System.Math.PI, Vector3d.XAxis, Point3d.Origin)
        ),
        logoLetters
    ) { }
