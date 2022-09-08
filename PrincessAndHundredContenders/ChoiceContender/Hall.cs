namespace ChoiceContender;

public class Hall
{
    private List<Contender> contenders;

    public int CurrentContender { get; private set; }
    //list checkedContenders
    //Hall(c1, c2)

    public Hall(List<Contender> contenders)
    {
        this.contenders = contenders;
        CurrentContender = 0;
    }

    public void CallNextContender()
    {
        ++CurrentContender;
    }

    public bool AskFriend(int checkContender)
    {
        return contenders[CurrentContender].Rating >= contenders[checkContender].Rating;
    }
}