namespace Excavator.Parts.Body.Cab;

public class CabFrameParams(
    CabFrontWindowGeometry cabFrontWindowGeometry,
    CabOuterBrep cabOuterBrep,
    CabSideWindowGeometry cabSideWindowGeometry,
    CabParams cabParams
) : Component
{
    public CabFrontWindowGeometry CabFrontWindowGeometry { get; } = cabFrontWindowGeometry;
    public CabOuterBrep CabOuterBrep { get; } = cabOuterBrep;
    public CabSideWindowGeometry CabSideWindowGeometry { get; } = cabSideWindowGeometry;
    public CabParams CabParams { get; } = cabParams;
}
