namespace Excavator.Parts.Arm;

public class ArmKinematics(
    BoomParams boomParams,
    BucketParams bucketParams,
    DipperParams dipperParams,
    AttachmentPositionParams attachmentPositionParams
) : Component
{
    public Transform BoomRotation =>
        Rhino.Geometry.Transform.Rotation(BoomAngle, Vector3d.XAxis, BoomRotationCenter);
    public Transform DipperRotation =>
        Rhino.Geometry.Transform.Rotation(DipperAngle, Vector3d.XAxis, DipperRotationCenter);
    public Transform BucketRotation =>
        Rhino.Geometry.Transform.Rotation(BucketAngle, Vector3d.XAxis, BucketRotationCenter);
    public Vector3d DipperOffset => (Vector3d)BoomLooseEndUnrotated - (Vector3d)DipperFixedEndLocal;
    public Vector3d BucketOffset =>
        DipperOffset
        + (Vector3d)DipperLooseEndUnrotated
        - (Vector3d)bucketParams.FixedEndCenter
        + new Vector3d(dipperParams.Width / 2.0, 0, 0);
    private double BoomAngle =>
        RhinoMath.ToRadians(-attachmentPositionParams.BoomElevationAngle + 180);
    private double BoomRadius => boomParams.Height / 2.0;
    private double BoomStraightLength => boomParams.Length - boomParams.Height;
    private Point3d BoomRotationCenter => new(0, BoomRadius, BoomRadius);
    private Point3d BoomLooseEndUnrotated => new(0, BoomRadius + BoomStraightLength, BoomRadius);
    private double DipperAngle =>
        RhinoMath.ToRadians(-attachmentPositionParams.DipperElevationAngle + 180);
    private double DipperRadius => dipperParams.Height / 2.0;
    private double DipperStraightLength => dipperParams.Length - dipperParams.Height;
    private Point3d DipperFixedEndLocal =>
        new(0, DipperRadius + DipperStraightLength, DipperRadius);
    private Point3d DipperLooseEndUnrotated => new(0, DipperRadius, DipperRadius);
    private Point3d DipperRotationCenter => (Point3d)DipperOffset + (Vector3d)DipperFixedEndLocal;
    private double BucketAngle =>
        RhinoMath.ToRadians(-attachmentPositionParams.BucketElevationAngle);
    private Point3d BucketRotationCenter =>
        (Point3d)BucketOffset + (Vector3d)bucketParams.FixedEndCenter;
}
