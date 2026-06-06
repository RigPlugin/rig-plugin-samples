namespace Excavator.Parts.Arm.Boom;

public class BoomGeometry(BoomParams boomParams) : Component
{
    public Computed<GeometryBase> Geometry { get; } =
        new(() =>
        {
            var profile = CurveExtensions.CreateRaceTrack(
                Plane.WorldYZ,
                boomParams.Length,
                boomParams.Height
            );
            var extrusion = Surface.CreateExtrusion(profile, new Vector3d(boomParams.Width, 0, 0));
            var brep = extrusion.ToBrep();
            brep = brep.CapPlanarHoles(AbsoluteTolerance);
            var filletedBrep = Brep.CreateFilletEdges(
                    brep: brep,
                    edgeIndices: [1, 2],
                    startRadii: [.. Enumerable.Repeat(boomParams.Filleting.FilletRadius, 2)],
                    endRadii: [.. Enumerable.Repeat(boomParams.Filleting.FilletRadius, 2)],
                    blendType: boomParams.Filleting.BlendType,
                    railType: boomParams.Filleting.RailType,
                    tolerance: AbsoluteTolerance
                )
                .Single();
            return filletedBrep;
        });
}
