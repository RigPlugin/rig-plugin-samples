namespace Excavator.Parts.Arm.Dipper;

public class DipperControls(DipperParams dipperParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Dipper",
                false,
                Section.Row(
                    "Length",
                    new NumericSetter.For(dipperParams.Length)
                    {
                        MinValue = 100,
                        MaxValue = 200,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Width",
                    new NumericSetter.For(dipperParams.Width)
                    {
                        MinValue = 5,
                        MaxValue = 15,
                        Increment = 1,
                    }
                ),
                Section.Row(
                    "Height",
                    new NumericSetter.For(dipperParams.Height)
                    {
                        MinValue = 20,
                        MaxValue = 40,
                        Increment = 2,
                    }
                )
            ),
        ];
    }
}
