using Eto.Forms;

namespace Excavator.Appearance;

public class Animation(AttachmentPositionParams attachmentPositionParams, RhinoDoc doc) : Component
{
    private UITimer? _timer;
    private int _activeControl;
    private int _bodyBaseDirection = 1;
    private int _boomDirection = 1;
    private int _dipperDirection = 1;
    private int _bucketDirection = 1;

    public Signal<bool> Animate { get; } = new(false);

    public override void Initialize()
    {
        _timer = new UITimer { Interval = 0.1 };

        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();
    }

    public override void Destroy()
    {
        if (_timer == null)
            return;

        _timer.Stop();
        _timer.Elapsed -= OnTimerElapsed;
        _timer.Dispose();
        _timer = null;
    }

    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        if (!Animate.Value)
        {
            return;
        }

        var p = attachmentPositionParams;
        switch (_activeControl)
        {
            case 0:
                p.BodyBaseRotationAngle.Value = MoveByTick(
                    p.BodyBaseRotationAngle.Value,
                    p.BodyBaseRotationBounds.Min,
                    p.BodyBaseRotationBounds.Max,
                    1,
                    ref _bodyBaseDirection
                );
                break;
            case 1:
                p.BoomElevationAngle.Value = MoveByTick(
                    p.BoomElevationAngle.Value,
                    p.BoomElevationBounds.Min,
                    p.BoomElevationBounds.Max,
                    1,
                    ref _boomDirection
                );
                break;
            case 2:
                p.DipperElevationAngle.Value = MoveByTick(
                    p.DipperElevationAngle.Value,
                    p.DipperElevationBounds.Min,
                    p.DipperElevationBounds.Max,
                    1,
                    ref _dipperDirection
                );
                break;
            default:
                p.BucketElevationAngle.Value = MoveByTick(
                    p.BucketElevationAngle.Value,
                    p.BucketElevationBounds.Min,
                    p.BucketElevationBounds.Max,
                    1,
                    ref _bucketDirection
                );
                break;
        }

        _activeControl = (_activeControl + 1) % 4;
        doc?.Views.Redraw();
        RhinoApp.Wait();
    }

    private static double MoveByTick(
        double value,
        double min,
        double max,
        double tick,
        ref int direction
    )
    {
        var next = value + tick * direction;

        if (next > max)
        {
            next = max;
            direction = -1;
        }
        else if (next < min)
        {
            next = min;
            direction = 1;
        }

        return next;
    }
}
