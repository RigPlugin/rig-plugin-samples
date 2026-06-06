namespace Excavator.Parts.Body;

public class BodyBaseControls(BodyBaseParams parameters) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Body Base",
                false,
                Section.Row(
                    "Height",
                    new NumericSetter.For(parameters.Height)
                    {
                        MinValue = 10,
                        MaxValue = 20,
                        Increment = 1,
                    }
                )
            ),
        ];
    }
}
