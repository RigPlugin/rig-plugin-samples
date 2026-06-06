namespace Excavator.Extensions;

public static class ObjectAttributesExtensions
{
    public static ObjectAttributes WithName(this ObjectAttributes objectAttributes, string name)
    {
        objectAttributes.Name = name;
        return objectAttributes;
    }

    public static ObjectAttributes OnLayer(
        this ObjectAttributes objectAttributes,
        string layerName,
        RhinoDoc doc
    )
    {
        objectAttributes.LayerIndex = doc.Layers.FindName(layerName).Index;
        return objectAttributes;
    }

    public static ObjectAttributes OnLayer(this ObjectAttributes objectAttributes, Layer layer)
    {
        objectAttributes.LayerIndex = layer.Index;
        return objectAttributes;
    }
}
