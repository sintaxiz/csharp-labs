namespace ChoiceContender.RabbitMQ.Dto;

public class ContenderRank
{
    public ContenderRank(int rank)
    {
        Rank = rank;
    }

    public int Rank { get; set; }
}