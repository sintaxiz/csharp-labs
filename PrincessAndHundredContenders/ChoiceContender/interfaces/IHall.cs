namespace ChoiceContender;

public interface IHall
{
    public int GetContendersCount();

    public int CurrentContender { get; set; }
    Task CallNextContender();
}