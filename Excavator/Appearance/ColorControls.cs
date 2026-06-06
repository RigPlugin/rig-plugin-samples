namespace Excavator.Appearance;

public class ColorControls(ColorParams colorParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Colors",
                true,
                Section.Row("Body Color", new ColorPicker.For(colorParams.BodyColor)),
                Section.Row("Glass Color", new ColorPicker.For(colorParams.GlassColor)),
                Section.Row("Track Color", new ColorPicker.For(colorParams.TrackColor))
            ),
        ];
    }
}
