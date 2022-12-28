using ChoiceContender.WebPrincess.Network;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ChoiceContender.WebPrincess;

public class WebPrincess : IHostedService
{
    private readonly IConfiguration Configuration;
    public WebPrincess(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(Run);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }


    private async Task Run()
    {
        
        var restServer = new RestApi(Configuration["SessionId"],
            Configuration["BaseUrl"]);

        var attemptsCount = 100;
        for (var i = 0; i < attemptsCount; i++)
        {
            for (var a = 0; a < 50; a++)
            {
                await restServer.NextContender(i);
            }
            await restServer.SelectContender(i);
        }
    }
}