namespace DIContainer;

public class Hall
{
    private readonly ILogger _logger;
    
    private List<Contender> _contenders;
    private Friend _friend; 
    public Hall(ILogger<Hall> logger)
    {
        _logger = logger;
    }

    public int CurrentContender { get; set; }

    public void InitContenders(ContenderGenerator contenderGenerator, int contenderCount)
    {
        _contenders = contenderGenerator.GenerateFromInternet(contenderCount);
    }

    public void CallNextContender()
    {
        ++CurrentContender;
        _friend.AddContender(_contenders[CurrentContender]);
    }

    public void InitFriend(Friend friend)
    {
        _friend = friend;
    }

    public int ChoseCurrentHusband()
    {
        return _contenders[CurrentContender].Rating;
    }
}