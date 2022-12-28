namespace DIContainer;

public class Friend : IHostedService
{
    private readonly ILogger<Friend> _logger;

    private List<Contender> _contenders;

    public Friend(ILogger<Friend> logger)
    {
        _logger = logger;
        _contenders = new List<Contender>();
    }

    public bool AskWhoBetter(int checkContender)
    {
        return _contenders.Last().Rating >= _contenders[checkContender].Rating;
    }

    public void AddContender(Contender contender)
    {
        _contenders.Add(contender);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Friend started.");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Friend stopped.");
    }
}