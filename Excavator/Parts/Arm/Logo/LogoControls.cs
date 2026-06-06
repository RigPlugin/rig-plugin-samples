namespace Excavator.Parts.Arm.Logo;

public class LogoControls(LogoParams logoParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Logo",
                false,
                Section.Row(
                    "Depth",
                    new NumericSetter.For(logoParams.Depth)
                    {
                        MinValue = 0.1,
                        MaxValue = 1.9,
                        Increment = 0.1,
                        DecimalPlaces = 1,
                    }
                )
            ),
        ];
    }
}
