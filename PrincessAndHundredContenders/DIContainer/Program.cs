namespace DIContainer;

class Program

{
    public static void Main(string[] args)

    {
        CreateHostBuilder(args).Build().Run();
    }


    public static IHostBuilder CreateHostBuilder(string[] args)

    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>

            {
                services.AddHostedService<Princess>();
                services.AddScoped<Hall>();
                services.AddScoped<Friend>();
                services.AddScoped<ContenderGenerator>();
            });
    }
}