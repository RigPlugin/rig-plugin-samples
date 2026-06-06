namespace Excavator.Parts.Arm;

public class AttachmentPositionControls(AttachmentPositionParams p) : IControls
{
    public Eto.Forms.Control[] Controls()
    {
        return
        [
            new Section(
                "Controls",
                true,
                Section.Row(
                    "Base Angle",
                    new Slider.For(p.BodyBaseRotationAngle)
                    {
                        MinValue = p.BodyBaseRotationBounds.Min,
                        MaxValue = p.BodyBaseRotationBounds.Max,
                        TickFrequency = 0,
                        SnapToTick = false,
                    }
                ),
                Section.Row(
                    "Boom Angle",
                    new Slider.For(p.BoomElevationAngle)
                    {
                        MinValue = p.BoomElevationBounds.Min,
                        MaxValue = p.BoomElevationBounds.Max,
                        TickFrequency = 0,
                        SnapToTick = false,
                    }
                ),
                Section.Row(
                    "Dipper Angle",
                    new Slider.For(p.DipperElevationAngle)
                    {
                        MinValue = p.DipperElevationBounds.Min,
                        MaxValue = p.DipperElevationBounds.Max,
                        TickFrequency = 0,
                        SnapToTick = false,
                    }
                ),
                Section.Row(
                    "Bucket Angle",
                    new Slider.For(p.BucketElevationAngle)
                    {
                        MinValue = p.BucketElevationBounds.Min,
                        MaxValue = p.BucketElevationBounds.Max,
                        TickFrequency = 0,
                        SnapToTick = false,
                    }
                )
            ),
        ];
    }
}
