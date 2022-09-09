namespace ChoiceContender;

public class Princess
{
    private readonly Hall _hall;
    
    public Princess(Hall hall)
    {
        _hall = hall;
    }

    public int ChoseHusband()
    {
        var contendersCount = _hall.GetContendersCount();
        while (_hall.CurrentContender != contendersCount / 2)
        {
            _hall.CallNextContender();
        }

        while (_hall.CurrentContender != contendersCount)
        {
            var isBetterCount = 0;
            for (var i = 0; i < _hall.CurrentContender; i++)
            {
                var friendAnswer = _hall.AskFriend(i);
                if (friendAnswer)
                {
                    ++isBetterCount;
                }
            }

            if (isBetterCount >= contendersCount / 2)
            {
                return _hall.CurrentContender;
            }

            _hall.CallNextContender();
        }

        return -1; // nobody
    }
}