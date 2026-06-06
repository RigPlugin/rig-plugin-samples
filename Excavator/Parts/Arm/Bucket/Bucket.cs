namespace Excavator.Parts.Arm.Bucket;

public class Bucket(
    ArmTransform parent,
    ArmKinematics kinematics,
    DipperParams dipperParams,
    BucketParams parameters
) : Part
{
    public override Computed<Transform> Transform { get; } =
        new(() =>
            parent.Transform.Value
            * kinematics.BoomRotation
            * kinematics.DipperRotation
            * kinematics.BucketRotation
            * Rhino.Geometry.Transform.Translation(
                kinematics.BucketOffset + new Vector3d { X = -dipperParams.Width / 2.0 }
            )
        );
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateBooleanDifference(
                    firstSet: [OuterShape(parameters)],
                    secondSet: [Cavity(parameters)],
                    tolerance: AbsoluteTolerance
                )
                .Single()
        );

    private static double Radius(BucketParams p) => p.Height / 2.0;

    private static Point3d TopOfArc(BucketParams p) => new(0, Radius(p), p.Height);

    private static Point3d BottomOfArc(BucketParams p) => new(0, Radius(p), 0);

    private static Point3d ExtensionEnd(BucketParams p) => new(0, 2 * Radius(p), 0);

    private static double VoidWidth(BucketParams p) => p.Width - 2 * p.Thickness;

    private static PolyCurve OpenProfile(BucketParams p) =>
        new PolyCurve().With(
            curves:
            [
                new ArcCurve(
                    new Arc(
                        circle: new Circle(
                            plane: new Plane(
                                origin: new Point3d(0, Radius(p), Radius(p)),
                                normal: Vector3d.XAxis
                            ),
                            radius: Radius(p)
                        ),
                        angleIntervalRadians: new Interval(Math.PI / 2, 3 * Math.PI / 2)
                    )
                ),
                new LineCurve(from: BottomOfArc(p), to: ExtensionEnd(p)),
            ]
        );

    private static Brep OuterShape(BucketParams p) =>
        Surface
            .CreateExtrusion(
                profile: new PolyCurve().With(
                    curves: [OpenProfile(p), new LineCurve(from: ExtensionEnd(p), to: TopOfArc(p))]
                ),
                direction: new Vector3d(p.Width, 0, 0)
            )
            .ToBrep()
            .Translate<Brep>(-p.Width / 2.0, 0, 0)
            .CapPlanarHoles(tolerance: AbsoluteTolerance)
            .MakeOutwards();

    private static Brep Cavity(BucketParams p) =>
        Surface
            .CreateExtrusion(
                profile: new PolyCurve()
                    .AppendAndReturn(
                        OpenProfile(p)
                            .Offset(
                                plane: Plane.WorldYZ,
                                distance: -p.Thickness,
                                tolerance: AbsoluteTolerance,
                                cornerStyle: CurveOffsetCornerStyle.Sharp
                            )
                            .Single()
                            .Extend(
                                side: CurveEnd.Start,
                                length: p.Thickness,
                                style: CurveExtensionStyle.Line
                            )
                    )
                    .CloseWithLine(),
                direction: new Vector3d(VoidWidth(p), 0, 0)
            )
            .ToBrep()
            .Translate<Brep>(-VoidWidth(p) / 2.0, 0, 0)
            .CapPlanarHoles(tolerance: AbsoluteTolerance)
            .MakeOutwards();
}
