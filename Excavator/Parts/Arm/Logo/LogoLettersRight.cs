namespace Excavator.Parts.Arm.Logo;

public class LogoLettersRight(
    ArmTransform parent,
    DipperParams dipperParams,
    SpacingParams spacingParams,
    BoomParams boomParams,
    ArmKinematics kinematics,
    LogoParams logoParams,
    LogoLettersGeometry logoLetters
)
    : LogoLetters(
        new Computed<Rhino.Geometry.Transform>(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = -dipperParams.Width / 2.0 - spacingParams.Spacing - boomParams.Width,
                }
            )
            * kinematics.BoomRotation
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = logoParams.Depth / 2.0,
                    Y = boomParams.Length / 2.0 + logoParams.LengthOffset,
                    Z = boomParams.Height / 2.0,
                }
            )
            * Rhino.Geometry.Transform.Rotation(System.Math.PI, Vector3d.YAxis, Point3d.Origin)
        ),
        logoLetters
    ) { }
