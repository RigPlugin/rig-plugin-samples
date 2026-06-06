namespace Excavator.Parts.Arm.Boom;

public class BoomSideParams(
    BoomGeometry boom,
    LogoWell well,
    BoomParams boomParams,
    LogoParams logoParams
) : Component
{
    public BoomGeometry Boom { get; } = boom;
    public LogoWell Well { get; } = well;
    public BoomParams BoomParams { get; } = boomParams;
    public LogoParams LogoParams { get; } = logoParams;
}
