namespace ChoiceContender;

public class Hall
{
    private readonly List<Contender> _contenders;

    public int CurrentContender { get; private set; }
    //list checkedContenders
    //Hall(c1, c2)

    public Hall(List<Contender> contenders)
    {
        _contenders = contenders;
        CurrentContender = 0;
    }

    public int GetContendersCount()
    {
        return _contenders.Count;
    }

    public void CallNextContender()
    {
        ++CurrentContender;
    }

    public bool AskFriend(int checkContender)
    {
        return _contenders[CurrentContender].Rating >= _contenders[checkContender].Rating;
    }
}