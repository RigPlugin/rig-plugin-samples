namespace Excavator.Parts.Body.Cab;

public class CabTransform(BodyTransform parent, BodyParams bodyParams) : Component
{
    public Computed<Transform> Transform { get; } =
        new(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    Z = bodyParams.BodyBase.Height + bodyParams.Spacing.Spacing,
                    Y =
                        -bodyParams.Engine.Length
                        - bodyParams.Cab.Length
                        - bodyParams.Spacing.Spacing,
                    X = bodyParams.Undercarriage.Width - bodyParams.Cab.Width,
                }
            )
        );
}
