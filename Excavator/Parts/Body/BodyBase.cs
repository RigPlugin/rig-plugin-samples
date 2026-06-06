namespace Excavator.Parts.Body;

public class BodyBase(BodyTransform parent, BodyParams bodyParams, BodyBaseParams parameters) : Part
{
    public override Computed<Transform> Transform { get; } =
        new(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(new Vector3d { Y = -bodyParams.BodyBase.Length })
        );
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });

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
}

public class BodyBaseParams(
    UndercarriageParams undercarriage,
    EngineParams engine,
    CabParams cab,
    FilletingParams filleting,
    SpacingParams spacing
) : Component
{
    public UndercarriageParams Undercarriage { get; } = undercarriage;
    public EngineParams Engine { get; } = engine;
    public CabParams Cab { get; } = cab;
    public FilletingParams Filleting { get; } = filleting;
    public SpacingParams Spacing { get; } = spacing;
    public double Width => Undercarriage.Width;

    public Signal<double> Height { get; } = new(15);

    public double Length => Engine.Length + Spacing.Spacing + Cab.Length;
}
