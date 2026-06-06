namespace Excavator.Appearance;

public class FilletingControls(FilletingParams filletingParams) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Filleting",
                false,
                Section.Row("Blend Type", CreateEnumDropDown(filletingParams.BlendType)),
                Section.Row("Rail Type", CreateEnumDropDown(filletingParams.RailType)),
                Section.Row(
                    "Fillet Radius",
                    new Slider.For(filletingParams.FilletRadius)
                    {
                        MinValue = 1,
                        MaxValue = 11,
                        SnapToTick = true,
                    }
                )
            ),
        ];
    }

    private static DropDown.For<TEnum> CreateEnumDropDown<TEnum>(Signal<TEnum> signal)
        where TEnum : struct, Enum
    {
        return new DropDown.For<TEnum>(signal)
        {
            DataStore = ((TEnum[])Enum.GetValues(typeof(TEnum))).Cast<object>(),
            ItemTextBinding = Eto.Forms.Binding.Delegate<object, string>(o => o?.ToString() ?? ""),
        };
    }
}
