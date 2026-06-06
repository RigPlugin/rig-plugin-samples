using Rig.UI;

namespace Extrusion;

public class ExtrusionControls(ExtrusionParams p) : IControls
{
    public Eto.Forms.Control[] Controls() =>
        [
            new Section(
                "Extrusion",
                true,
                Section.Row(
                    "Height",
                    new Slider.For(p.Height)
                    {
                        MinValue = 1,
                        MaxValue = 20,
                        SnapToTick = false,
                    }
                )
            ),
        ];
}
