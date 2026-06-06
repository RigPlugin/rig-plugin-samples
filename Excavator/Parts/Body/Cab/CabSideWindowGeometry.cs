namespace Excavator.Parts.Body.Cab;

public class CabSideWindowGeometry(
    CabSideWindowCrossSection cabSideWindowCrossSection,
    CabParams cabParams
) : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Brep.JoinBreps(
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
                                                    cabSideWindowCrossSection.Geometry.Value
                                            ).ToPolyline()[i],
                                            to: (
                                                (PolylineCurve)
                                                    cabSideWindowCrossSection.Geometry.Value
                                            ).ToPolyline()[i + 1]
                                        ),
                                        direction: Vector3d.XAxis * cabParams.WindowThickness
                                    )
                                    .ToBrep()
                                    .MakeOutwards()
                            ),
                        Brep.CreatePlanarBreps(
                                inputLoop: (PolylineCurve)cabSideWindowCrossSection.Geometry.Value,
                                tolerance: AbsoluteTolerance
                            )
                            .Single()
                            .MakeOutwards(),
                        Brep.CreatePlanarBreps(
                                inputLoop: (PolylineCurve)cabSideWindowCrossSection.Geometry.Value,
                                tolerance: AbsoluteTolerance
                            )
                            .Single()
                            .MakeOutwards()
                            .Translate<Brep>(Vector3d.XAxis * cabParams.WindowThickness),
                    ],
                    tolerance: AbsoluteTolerance
                )
                .Single()
                .MakeOutwards()
        );

    private Vector3d WidthVec => Vector3d.XAxis * cabParams.WindowThickness;
}
