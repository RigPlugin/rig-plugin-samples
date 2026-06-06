namespace Excavator.Parts.Body.Engine;

public class EngineControls(EngineParams parameters) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Engine",
                false,
                Section.Row(
                    "Height",
                    new NumericSetter.For(parameters.Height)
                    {
                        MinValue = 25,
                        MaxValue = 75,
                        Increment = 5,
                    }
                ),
                Section.Row(
                    "Length",
                    new NumericSetter.For(parameters.Length)
                    {
                        MinValue = 25,
                        MaxValue = 75,
                        Increment = 5,
                    }
                )
            ),
        ];
    }
}
