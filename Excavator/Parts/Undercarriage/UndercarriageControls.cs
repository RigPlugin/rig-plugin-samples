namespace Excavator.Parts.Undercarriage;

public class UndercarriageControls(
    UndercarriageParams undercarriageParams,
    TrackControls trackControls
) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Undercarriage",
                false,
                Section.Row(
                    "Length",
                    new NumericSetter.For(undercarriageParams.Length)
                    {
                        MinValue = 150,
                        MaxValue = 250,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Width",
                    new NumericSetter.For(undercarriageParams.Width)
                    {
                        MinValue = 130,
                        MaxValue = 230,
                        Increment = 10,
                    }
                ),
                Section.Row(
                    "Number Of Wheels",
                    new NumericSetter.For(undercarriageParams.NumberOfWheels)
                    {
                        MinValue = 2,
                        MaxValue = 6,
                        Increment = 1,
                    }
                )
            ),
            .. trackControls.Controls(),
        ];
    }
}
