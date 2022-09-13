namespace DIContainer;

public class Princess : BackgroundService
{
    private readonly ILogger<Princess> _logger;

    public IServiceProvider Services { get; }

    public Princess(ILogger<Princess> logger, IServiceProvider services)
    {
        _logger = logger;
        Services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Princess running at: {time}", DateTimeOffset.Now);
            using (var scope = Services.CreateScope())
            {
                var hall = scope.ServiceProvider.GetRequiredService<Hall>();
                await hall.Test(stoppingToken);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}