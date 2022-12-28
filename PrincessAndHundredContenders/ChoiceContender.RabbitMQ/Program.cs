using ChoiceContender.RabbitMQ;
using ChoiceContender.RabbitMQ.DataContracts;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add mass transit for rabbitmq
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NextContenderConsumer>();
    x.UsingRabbitMq();
    x.AddRequestClient<NextContenderRequest>(new Uri("queue:next-contender-event"));
});

// configure consumer to use MassTransit
var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    cfg.ReceiveEndpoint("next-contender-event", e => { e.Consumer<NextContenderConsumer>(); }));
await busControl.StartAsync();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

await busControl.StopAsync();