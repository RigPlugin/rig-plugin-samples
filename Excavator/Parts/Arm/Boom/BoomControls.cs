namespace Excavator.Parts.Arm.Boom;

public class BoomControls(BoomParams boomParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Boom",
                false,
                Section.Row(
                    "Length",
                    new NumericSetter.For(boomParams.Length)
                    {
                        MinValue = 195,
                        MaxValue = 245,
                        Increment = 5,
                    }
                ),
                Section.Row(
                    "Width",
                    new NumericSetter.For(boomParams.Width)
                    {
                        MinValue = 5,
                        MaxValue = 15,
                        Increment = 1,
                    }
                ),
                Section.Row(
                    "Height",
                    new NumericSetter.For(boomParams.Height)
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
