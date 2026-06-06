using Eto.Forms;

namespace Excavator.Appearance;

public class TurntableButton : Button
{
    public TurntableButton()
    {
        Click += (s, e) =>
        {
            RhinoApp.RunScript("_Turntable", echo: false);
        };
    }
}
