namespace Excavator.Parts.Body.Cab;

public class CabOuterBrep(
    CabParams cabParams,
    CabCrossSection cabCrossSection,
    FilletingParams filletingParams
) : Component
{
    private Vector3d WidthVec => Vector3d.XAxis * cabParams.Width;

    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.CreateFilletEdges(
                    brep: Brep.JoinBreps(
                            brepsToJoin:
                            [
                                .. Enumerable
                                    .Range(0, 4)
                                    .Select(i =>
                                        Surface
                                            .CreateExtrusion(
                                                profile: new LineCurve(
                                                    from: (
                                                        (PolylineCurve)
                                                            cabCrossSection.Geometry.Value
                                                    ).ToPolyline()[i],
                                                    to: (
                                                        (PolylineCurve)
                                                            cabCrossSection.Geometry.Value
                                                    ).ToPolyline()[i + 1]
                                                ),
                                                direction: Vector3d.XAxis * cabParams.Width
                                            )
                                            .ToBrep()
                                    ),
                                Brep.CreatePlanarBreps(
                                        inputLoop: (PolylineCurve)cabCrossSection.Geometry.Value,
                                        tolerance: AbsoluteTolerance
                                    )
                                    .Single(),
                                Brep.CreatePlanarBreps(
                                        inputLoop: (PolylineCurve)cabCrossSection.Geometry.Value,
                                        tolerance: AbsoluteTolerance
                                    )
                                    .Single()
                                    .Translate<Brep>(Vector3d.XAxis * cabParams.Width),
                            ],
                            tolerance: AbsoluteTolerance
                        )
                        .Single(),
                    edgeIndices: [.. Enumerable.Range(0, 12)],
                    startRadii: [.. Enumerable.Repeat(filletingParams.FilletRadius, 12)],
                    endRadii: [.. Enumerable.Repeat(filletingParams.FilletRadius, 12)],
                    blendType: filletingParams.BlendType,
                    railType: filletingParams.RailType,
                    tolerance: AbsoluteTolerance
                )
                .Single()
        );
}
