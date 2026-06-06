namespace Excavator.Appearance;

public class SpacingControls(SpacingParams spacingParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Spacing",
                false,
                Section.Row(
                    "Spacing",
                    new NumericSetter.For(spacingParams.Spacing)
                    {
                        MinValue = 0,
                        MaxValue = 5,
                        Increment = 0.5,
                        DecimalPlaces = 1,
                    }
                )
            ),
        ];
    }
}
