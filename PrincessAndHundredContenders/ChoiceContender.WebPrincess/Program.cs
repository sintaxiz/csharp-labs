using ChoiceContender.WebPrincess;
using ChoiceContender.WebPrincess.RabbitMq;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    public static async Task Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
       

        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(config =>
                {
                    config.AddConsumer<ContenderConsumer>();
                    
                    config.UsingRabbitMq((ctx, cfg) =>
                    {
                        var jsonCfg = hostContext.Configuration;
                        Console.WriteLine(hostContext.Configuration.GetConnectionString("RabbitMqHost"));
                        cfg.Host(jsonCfg.GetConnectionString("RabbitMqHost"), c =>
                        {
                            c.Username(jsonCfg.GetConnectionString("RabbitMqUserName"));
                            c.Password(jsonCfg.GetConnectionString("RabbitMqPassword"));
                        });
                        cfg.ReceiveEndpoint("Nsu.PeakyBride.DataContracts:Contender", c =>
                        {
                            c.ConfigureConsumer<ContenderConsumer>(ctx);
                        });
                        
                    });
                });

                services.AddHostedService<WebPrincess>();
            });
    }
}



