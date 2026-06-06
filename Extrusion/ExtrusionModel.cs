using Rig;

namespace Extrusion;

public class ExtrusionModel : Model
{
    protected override void Configure(ModelBuilder builder)
    {
        builder.Root<ExtrusionPart>();
        builder.Controls<ExtrusionControls>();
    }
}
