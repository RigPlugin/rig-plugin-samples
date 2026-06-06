namespace Excavator.Extensions;

public static class Point3dExtensions
{
    public static Point3d WithX(this Point3d point, double x)
    {
        return new Point3d(x, point.Y, point.Z);
    }

    public static Point3d WithY(this Point3d point, double y)
    {
        return new Point3d(point.X, y, point.Z);
    }

    public static Point3d WithZ(this Point3d point, double z)
    {
        return new Point3d(point.X, point.Y, z);
    }
}
