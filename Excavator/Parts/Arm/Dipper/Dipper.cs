namespace Excavator.Parts.Arm.Dipper;

public class Dipper(ArmTransform armTransform, ArmKinematics kinematics, DipperParams parameters)
    : Part
{
    public override Computed<Transform> Transform { get; } =
        new(() =>
            armTransform.Transform.Value
            * kinematics.BoomRotation
            * kinematics.DipperRotation
            * Rhino.Geometry.Transform.Translation(
                kinematics.DipperOffset + new Vector3d { X = -parameters.Width / 2.0 }
            )
        );
    public override Computed<ObjectAttributes> Attributes { get; } =
        new(() => new ObjectAttributes { LayerIndex = Document.Layers.Body.Index });
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateFilletEdges(
                    brep: Surface
                        .CreateExtrusion(
                            profile: CurveExtensions.CreateRaceTrack(
                                plane: Plane.WorldYZ,
                                length: parameters.Length,
                                height: parameters.Height
                            ),
                            new Vector3d { X = parameters.Width }
                        )
                        .ToBrep()
                        .CapPlanarHoles(tolerance: AbsoluteTolerance),
                    edgeIndices: [1, 2],
                    startRadii:
                    [
                        .. Enumerable.Repeat(element: parameters.Filleting.FilletRadius, count: 2),
                    ],
                    endRadii:
                    [
                        .. Enumerable.Repeat(element: parameters.Filleting.FilletRadius, count: 2),
                    ],
                    blendType: parameters.Filleting.BlendType,
                    railType: parameters.Filleting.RailType,
                    tolerance: AbsoluteTolerance
                )
                .Single()
        );
}
