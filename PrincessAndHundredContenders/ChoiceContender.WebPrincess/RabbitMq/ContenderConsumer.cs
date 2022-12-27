using ChoiceContender.WebPrincess.Network;
using MassTransit;

namespace ChoiceContender.WebPrincess.RabbitMq;

public class ContenderConsumer : IConsumer<Contender>
{
    private readonly Comparation _comparation;

    public ContenderConsumer(Comparation comparation)
    {
        _comparation = comparation;
    }

    public Task Consume(ConsumeContext<Contender> msg)
    {
        var contenderName = msg.Message.Name;
        _comparation.AddContender(contenderName);
        return Task.CompletedTask;
    }
}