using Rhino.Render;

namespace Excavator.Appearance;

public class ColorParams : Component
{
    private readonly RhinoDoc _doc;
    public Signal<System.Drawing.Color> BodyColor { get; }
    public Signal<System.Drawing.Color> GlassColor { get; }
    public Signal<System.Drawing.Color> TrackColor { get; }

    public ColorParams(RhinoDoc doc)
    {
        _doc = doc;
        BodyColor = new(GetLayerColor(Document.Layers.Body));
        GlassColor = new(GetLayerColor(Document.Layers.Glass));
        TrackColor = new(GetLayerColor(Document.Layers.Track));

        BodyColor.Subscribe(() => SetLayerColor(Document.Layers.Body, BodyColor.Value));
        GlassColor.Subscribe(() => SetLayerColor(Document.Layers.Glass, GlassColor.Value));
        TrackColor.Subscribe(() => SetLayerColor(Document.Layers.Track, TrackColor.Value));
    }

    private void SetLayerColor(Layer layer, System.Drawing.Color color)
    {
        layer.Color = color;
        var material =
            layer.RenderMaterial?.ToMaterial(RenderTexture.TextureGeneration.Allow)
            ?? new Material();
        material.DiffuseColor = color;
        layer.RenderMaterial = RenderMaterial.CreateBasicMaterial(material, _doc);
        _doc?.Views?.Redraw();
    }

    private static System.Drawing.Color GetLayerColor(Layer layer)
    {
        var material = layer.RenderMaterial?.ToMaterial(RenderTexture.TextureGeneration.Allow);
        if (material != null)
        {
            return material.DiffuseColor;
        }
        return layer.Color;
    }
}
