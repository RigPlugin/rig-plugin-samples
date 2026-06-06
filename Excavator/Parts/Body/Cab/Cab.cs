namespace Excavator.Parts.Body.Cab;

public class Cab(
    CabFrame cabFrame,
    CabFrontWindow cabFrontWindow,
    CabSideWindowLeft cabSideWindowLeft,
    CabSideWindowRight cabSideWindowRight
) : Component
{
    public CabFrame CabFrame { get; } = cabFrame;
    public CabFrontWindow CabFrontWindow { get; } = cabFrontWindow;
    public CabSideWindowLeft CabSideWindowLeft { get; } = cabSideWindowLeft;
    public CabSideWindowRight CabSideWindowRight { get; } = cabSideWindowRight;
}
