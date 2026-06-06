namespace Excavator.Parts.Body;

public class BodyTransform(
    UndercarriageParams undercarriageParams,
    SpacingParams spacingParams,
    BodyBaseParams bodyBaseParams,
    AttachmentPositionParams attachmentPositionParams
) : Component
{
    public Computed<Transform> Transform { get; } =
        new(() =>
        {
            var translation = Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = -undercarriageParams.Width / 2.0,
                    Y = undercarriageParams.Length / 2.0,
                    Z = undercarriageParams.Height + spacingParams.Spacing,
                }
            );

            var rotationCenter = new Point3d(
                x: 0,
                y: undercarriageParams.Length / 2.0 - bodyBaseParams.Length / 2.0,
                z: undercarriageParams.Height + spacingParams.Spacing + bodyBaseParams.Height / 2.0
            );

            var rotation = Rhino.Geometry.Transform.Rotation(
                angleRadians: RhinoMath.ToRadians(-attachmentPositionParams.BodyBaseRotationAngle),
                rotationAxis: Vector3d.ZAxis,
                rotationCenter: rotationCenter
            );

            return rotation * translation;
        });
}
