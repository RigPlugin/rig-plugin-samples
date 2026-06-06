using Rig;

namespace Extrusion;

public class ExtrusionParams : Component
{
    public Signal<double> Height { get; } = new(50);
}
