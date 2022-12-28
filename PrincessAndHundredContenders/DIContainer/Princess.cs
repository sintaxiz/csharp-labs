namespace DIContainer;

public class Princess : BackgroundService
{
    private readonly ILogger<Princess> _logger;

    private const int ContenderCount = 100;
    private Hall _hall;
    private Friend _friend;

    private IServiceProvider Services { get; }

    public Princess(ILogger<Princess> logger, IServiceProvider services)
    {
        _logger = logger;
        Services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Princess running at: {time}", DateTimeOffset.Now);
        using (var scope = Services.CreateScope())
        {
            _hall = scope.ServiceProvider.GetRequiredService<Hall>();
            _friend = scope.ServiceProvider.GetRequiredService<Friend>();
            var contenderGenerator = scope.ServiceProvider.GetRequiredService<ContenderGenerator>();

            _hall.InitContenders(contenderGenerator, ContenderCount);
            _hall.InitFriend(_friend);
        }

        var happyLevel = ChoseHusband();
        Console.WriteLine($"Happy level = {happyLevel}");
        Environment.Exit(0);
    }
    
    private int ChoseHusband()
    {
        while (_hall.CurrentContender != ContenderCount / 2)
        {
            _hall.CallNextContender();
        }

        while (_hall.CurrentContender != ContenderCount)
        {
            var isBetterCount = 0;
            for (var i = 0; i < _hall.CurrentContender; i++)
            {
                var friendAnswer = _friend.AskWhoBetter(i);
                if (friendAnswer)
                {
                    ++isBetterCount;
                }
            }

            if (isBetterCount >= ContenderCount / 2)
            {
                return _hall.ChoseCurrentHusband();
            }

            _hall.CallNextContender();
        }

        return 10; // nobody
    }
}