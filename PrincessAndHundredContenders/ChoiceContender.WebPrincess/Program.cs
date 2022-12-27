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
                        var jsonCfg = hostContext.Configuration.GetSection("RabbitMq");
                        cfg.Host(jsonCfg["RabbitMqHost"], c =>
                        {
                            c.Username(jsonCfg["UserName"]);
                            c.Password(jsonCfg["Password"]);
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



