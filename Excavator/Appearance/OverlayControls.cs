namespace Excavator.Appearance;

public class OverlayControls(OverlayParams overlayParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Overlay",
                false,
                Section.Row(
                    "Show Overlay",
                    new CheckBox.For(overlayParams.ShowOverlay) { Text = string.Empty }
                )
            ),
        ];
    }
}
