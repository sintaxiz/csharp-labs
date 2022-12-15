namespace ChoiceContender.RabbitMQ.DataContracts;

public interface NextContenderRequest
{
    string AttemptName { get; set; }
}