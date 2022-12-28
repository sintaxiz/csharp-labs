namespace ChoiceContender.RabbitMQ.Dto;

public class Contender
{
    public string? Name { get; set; }

    public Contender(string? name)
    {
        Name = name;
    }
}