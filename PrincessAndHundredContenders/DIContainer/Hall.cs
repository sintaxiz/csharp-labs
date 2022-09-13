namespace DIContainer;

public class Hall
{
    private readonly ILogger _logger;
    public Hall(ILogger<Hall> logger)
    {
        _logger = logger;
    }

    public async Task Test(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Hall is working.");
    }
}