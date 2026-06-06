namespace Excavator.Appearance;

public class TurntableControls : IControls
{
    public TurntableControls(Animation animation)
    {
        this.animation = animation;
    }

    private Animation animation;

    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Animation",
                true,
                Section.Row("Animate", new CheckBox.For(animation.Animate) { Text = string.Empty }),
                Section.Row("Turntable", new TurntableButton() { Text = "Start" })
            ),
        ];
    }
}
