namespace Excavator;

public class ExcavatorControls(
    AttachmentPositionControls attachmentPositionControls,
    SpacingControls spacingControls,
    OverlayControls overlayControls,
    ColorControls colorControls,
    TurntableControls turntableControls,
    FilletingControls filletingControls,
    UndercarriageControls undercarriageControls,
    BodyBaseControls bodyBaseControls,
    EngineControls engineControls,
    CabControls cabControls,
    BoomControls boomControls,
    LogoControls logoControls,
    ArmControls armControls
) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            .. attachmentPositionControls.Controls(),
            .. turntableControls.Controls(),
            .. colorControls.Controls(),
            .. spacingControls.Controls(),
            .. overlayControls.Controls(),
            .. filletingControls.Controls(),
            .. undercarriageControls.Controls(),
            .. bodyBaseControls.Controls(),
            .. engineControls.Controls(),
            .. cabControls.Controls(),
            .. boomControls.Controls(),
            .. logoControls.Controls(),
            .. armControls.Controls(),
        ];
    }
}
