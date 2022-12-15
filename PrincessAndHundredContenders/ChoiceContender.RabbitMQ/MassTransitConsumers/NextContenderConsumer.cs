using ChoiceContender.Db.entities;
using ChoiceContender.RabbitMQ.DataContracts;
using ChoiceContender.RabbitMQ.Model;
using MassTransit;
using Newtonsoft.Json;

namespace ChoiceContender.RabbitMQ;

public class NextContenderConsumer : IConsumer<NextContenderRequest>
{
    private HallModel? _hallModel;

    public NextContenderConsumer()
    {
        _hallModel = HallModel.getInstance();
        Console.WriteLine("NextContenderConsumer created");
    }

    public async Task Consume(ConsumeContext<NextContenderRequest> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"NextContender message: {jsonMessage}");
        Console.WriteLine($"ResponseAddress: {context.ResponseAddress}");
        
        var nextContenderName = _hallModel.CallNextContenderForAttempt(context.Message.AttemptName);
        
        await context.RespondAsync<NextContender>(new
        {
            Name = nextContenderName
        });
        
        Console.WriteLine($"NextContenderName: {nextContenderName}");

    }
}