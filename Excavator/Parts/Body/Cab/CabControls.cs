namespace Excavator.Parts.Body.Cab;

public class CabControls(CabParams cabParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Cab",
                false,
                Section.Row(
                    "Height",
                    new NumericSetter.For(cabParams.Height)
                    {
                        MinValue = 50,
                        MaxValue = 150,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Length",
                    new NumericSetter.For(cabParams.Length)
                    {
                        MinValue = 50,
                        MaxValue = 150,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Width",
                    new NumericSetter.For(cabParams.Width)
                    {
                        MinValue = 40,
                        MaxValue = 140,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Window Offset",
                    new NumericSetter.For(cabParams.WindowOffset)
                    {
                        MinValue = 5,
                        MaxValue = 15,
                        Increment = 1,
                    }
                ),
                Section.Row(
                    "Window Thickness",
                    new NumericSetter.For(cabParams.WindowThickness)
                    {
                        MinValue = 1,
                        MaxValue = 3,
                        Increment = 0.2,
                        DecimalPlaces = 1,
                    }
                )
            ),
        ];
    }
}
