namespace Excavator.Parts.Body.Cab;

public class CabSideWindowParams(CabSideWindowGeometry cabSideWindowGeometry) : Component
{
    public CabSideWindowGeometry CabSideWindowGeometry { get; } = cabSideWindowGeometry;
}
