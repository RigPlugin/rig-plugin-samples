namespace Excavator.Parts.Arm.Bucket;

public class BucketControls(BucketParams parameters) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Bucket",
                false,
                Section.Row(
                    "Width",
                    new NumericSetter.For(parameters.Width)
                    {
                        MinValue = 55,
                        MaxValue = 105,
                        Increment = 5,
                    }
                ),
                Section.Row(
                    "Height",
                    new NumericSetter.For(parameters.Height)
                    {
                        MinValue = 35,
                        MaxValue = 85,
                        Increment = 5,
                    }
                ),
                Section.Row(
                    "Thickness",
                    new NumericSetter.For(parameters.Thickness)
                    {
                        MinValue = 0.5,
                        MaxValue = 5.5,
                        Increment = 0.5,
                        DecimalPlaces = 1,
                    }
                )
            ),
        ];
    }
}
