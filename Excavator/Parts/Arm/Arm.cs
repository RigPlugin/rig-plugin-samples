using BucketPart = Excavator.Parts.Arm.Bucket.Bucket;
using DipperPart = Excavator.Parts.Arm.Dipper.Dipper;

namespace Excavator.Parts.Arm;

public class Arm(LeftBoom leftBoom, RightBoom rightBoom, DipperPart dipper, BucketPart bucket)
    : Component
{
    public LeftBoom LeftBoom { get; } = leftBoom;
    public RightBoom RightBoom { get; } = rightBoom;
    public DipperPart Dipper { get; } = dipper;
    public BucketPart Bucket { get; } = bucket;
}
