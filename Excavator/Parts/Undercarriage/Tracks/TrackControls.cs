namespace Excavator.Parts.Undercarriage.Tracks;

public class TrackControls(TrackParams trackParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Track",
                false,
                Section.Row(
                    "Thickness",
                    new NumericSetter.For(trackParams.Thickness)
                    {
                        MinValue = 7.5,
                        MaxValue = 12.5,
                        Increment = 0.5,
                        DecimalPlaces = 1,
                    }
                ),
                Section.Row(
                    "Width",
                    new NumericSetter.For(trackParams.Width)
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
