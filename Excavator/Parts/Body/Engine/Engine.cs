namespace Excavator.Parts.Body.Engine;

public class Engine(BodyTransform parent, BodyParams bodyParams, EngineParams parameters) : Part
{
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateFromBox(
                    new Box(
                        basePlane: Plane.WorldXY,
                        xSize: new Interval(0, parameters.Width),
                        ySize: new Interval(0, parameters.Length),
                        zSize: new Interval(0, parameters.Height)
                    )
                )
                .FilletAllEdges(
                    radius: parameters.Filleting.FilletRadius,
                    tolerance: AbsoluteTolerance,
                    blendType: parameters.Filleting.BlendType,
                    railType: parameters.Filleting.RailType
                )
                .Single()
        );

    public override Computed<Transform> Transform { get; } =
        new(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    Z = bodyParams.BodyBase.Height + bodyParams.Spacing.Spacing,
                    Y = -bodyParams.Engine.Length,
                }
            )
        );

    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
}
