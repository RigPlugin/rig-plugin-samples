namespace Excavator.Extensions;

public static class BrepExtensions
{
    public static Brep[] FilletAllEdges(
        this Brep brep,
        double radius,
        double tolerance,
        BlendType blendType,
        RailType railType
    ) =>
        Brep.CreateFilletEdges(
            brep: brep,
            edgeIndices: Enumerable.Range(0, brep.Edges.Count),
            startRadii: Enumerable.Range(0, brep.Edges.Count).Select(_ => radius),
            endRadii: Enumerable.Range(0, brep.Edges.Count).Select(_ => radius),
            blendType: blendType,
            railType: railType,
            tolerance: tolerance
        );

    public static Brep MakeOutwards(this Brep brep)
    {
        if (brep.SolidOrientation == BrepSolidOrientation.Inward)
        {
            brep.Flip();
        }
        return brep;
    }
}
