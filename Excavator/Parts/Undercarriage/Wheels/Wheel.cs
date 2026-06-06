namespace Excavator.Parts.Undercarriage.Wheels;

public abstract class Wheel(WheelParams wp, SpacingParams sp, ArrayIndex i, int xSign) : Part
{
    public override Computed<Transform> Transform { get; } =
        new(() =>
            Rhino.Geometry.Transform.Translation(
                new Vector3d
                {
                    X = xSign * (wp.Undercarriage.Width - wp.Undercarriage.TrackParams.Width) / 2.0,
                }
            )
            * Rhino.Geometry.Transform.Translation(
                0,
                -(wp.Undercarriage.Length / 2.0)
                    + wp.Undercarriage.WheelRadius
                    + wp.Track.Thickness
                    + sp.Spacing
                    + ((sp.Spacing + wp.Undercarriage.WheelDiameter) * i.Value),
                wp.Track.Thickness + sp.Spacing + wp.Undercarriage.WheelRadius
            )
        );

    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateFilletEdges(
                    brep: Surface
                        .CreateExtrusion(
                            new Circle(
                                plane: Plane.WorldYZ,
                                center: new Point3d(-wp.Track.Width / 2, 0, 0),
                                radius: wp.Undercarriage.WheelRadius
                            ).ToNurbsCurve(),
                            Vector3d.XAxis * wp.Track.Width
                        )
                        .ToBrep()
                        .CapPlanarHoles(AbsoluteTolerance),
                    edgeIndices: [1, 2],
                    startRadii: [wp.Filleting.FilletRadius, wp.Filleting.FilletRadius],
                    endRadii: [wp.Filleting.FilletRadius, wp.Filleting.FilletRadius],
                    blendType: wp.Filleting.BlendType,
                    railType: wp.Filleting.RailType,
                    tolerance: AbsoluteTolerance
                )
                .Single()
        );

    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
}
