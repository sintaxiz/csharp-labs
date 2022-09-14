namespace DIContainer;

public class Friend
{
    private List<Contender> _contenders;

    public Friend()
    {
        _contenders = new List<Contender>();
    }

    public bool AskWhoBetter(int checkContender)
    {
        return _contenders.Last().Rating >= _contenders[checkContender].Rating;
    }

    public void AddContender(Contender contender)
    {
        _contenders.Add(contender);
    }
}