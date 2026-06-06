namespace Excavator;

public class ExcavatorModel : Model
{
    private static readonly ILogger<ExcavatorModel> _log = Log.For<ExcavatorModel>();

    protected override void Configure(ModelBuilder builder)
    {
        ConfigureLogging(builder);
        ConfigurePersistence(builder);
        builder.Root<Excavator>();
        builder.Controls<ExcavatorControls>();
    }

    public override void OnActivated() => _log.LogInformation("[Excavator] Model activated.");

    public override void OnReloaded() => _log.LogInformation("[Excavator] Model reloaded.");

    public override void OnRebuilt() => _log.LogInformation("[Excavator] Model rebuilt.");

    private static void ConfigurePersistence(ModelBuilder builder)
    {
        builder.Persist<SpacingParams>();
        builder.Persist<OverlayParams>();
        builder.Persist<FilletingParams>();
        builder.Persist<CabParams>();
        builder.Persist<BoomParams>();
        builder.Persist<DipperParams>();
        builder.Persist<BucketParams>();
        builder.Persist<AttachmentPositionParams>();
        builder.Persist<UndercarriageParams>();
        builder.Persist<TrackParams>();
        builder.Persist<EngineParams>();
        builder.Persist<LogoParams>();
    }

    private static void ConfigureLogging(ModelBuilder builder)
    {
        builder.Logging.AddRhinoLogger();
        builder.Logging.AddTraceLogger();
        builder.Logging.SetMinimumLevel(LogLevel.Information);
    }
}
