using Rig;
using Rhino.DocObjects;
using Rhino.Geometry;

namespace Extrusion;

public class ExtrusionPart(Document.Profile profile, ExtrusionParams p) : Part
{
    public override Computed<GeometryBase> Geometry { get; } =
        new(() =>
            Rhino.Geometry.Extrusion.Create(
                planarCurve: profile.Geometry<Curve>(),
                height: p.Height,
                cap: true
            )
        );

    public override Computed<ObjectAttributes> Attributes =>
        new(() => new ObjectAttributes() { LayerIndex = Document.Layers.Default.Index });
}
