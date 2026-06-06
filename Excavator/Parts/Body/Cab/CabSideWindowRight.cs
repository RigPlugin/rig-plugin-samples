namespace Excavator.Parts.Body.Cab;

public class CabSideWindowRight(
    CabTransform parent,
    CabParams cabParams,
    CabSideWindowParams parameters
)
    : CabSideWindow(
        new Computed<Rhino.Geometry.Transform>(() =>
            parent.Transform.Value
            * Rhino.Geometry.Transform.Translation(
                new Vector3d { X = cabParams.Width - cabParams.WindowThickness }
            )
        ),
        parameters
    ) { }
