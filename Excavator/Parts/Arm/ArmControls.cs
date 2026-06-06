namespace Excavator.Parts.Arm;

public class ArmControls(DipperControls dipperControls, BucketControls bucketControls) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return [.. dipperControls.Controls(), .. bucketControls.Controls()];
    }
}
