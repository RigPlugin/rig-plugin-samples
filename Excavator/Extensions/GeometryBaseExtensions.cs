namespace Excavator.Extensions;

public static class GeometryBaseExtensions
{
    public static T Translate<T>(this GeometryBase geometry, double x, double y, double z)
        where T : GeometryBase
    {
        var success = geometry.Translate(x, y, z);
        Debug.Assert(success);
        return (T)geometry;
    }

    public static T Translate<T>(this GeometryBase geometry, Vector3d translation)
        where T : GeometryBase
    {
        var success = geometry.Translate(translation);
        Debug.Assert(success);
        return (T)geometry;
    }

    public static GeometryBase WithTranslation(
        this GeometryBase geometry,
        double x,
        double y,
        double z
    )
    {
        var success = geometry.Translate(x, y, z);
        Debug.Assert(success);
        return geometry;
    }

    public static GeometryBase WithTranslation(this GeometryBase geometry, Vector3d translation)
    {
        var success = geometry.Translate(translation);
        Debug.Assert(success);
        return geometry;
    }
}
