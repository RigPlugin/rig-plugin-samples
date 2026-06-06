namespace Excavator.Parts.Body.Cab;

public class CabFrontWindowParams(CabFrontWindowGeometry cabFrontWindowGeometry) : Component
{
    public CabFrontWindowGeometry CabFrontWindowGeometry { get; } = cabFrontWindowGeometry;
}
