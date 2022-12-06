using ChoiceContender.exceptions;

namespace ChoiceContender;

public class Princess : IPrincess
{
    private readonly IHall _hall;
    private readonly IFreind _friend;
    public Princess(IHall hall, IFreind friend)
    {
        _hall = hall;
        _friend = friend;
    }

    public int ChoseHusband()
    {
        var contendersCount = _hall.GetContendersCount();
        if (_hall.CurrentContender != -1)
        {
            throw new NoContendersInHallException();
        }

        while (_hall.CurrentContender != contendersCount / 2)
        {
            _hall.CallNextContender();
        }

        while (_hall.CurrentContender != contendersCount)
        {
            var isBetterCount = 0;
            for (var i = 0; i < _hall.CurrentContender; i++)
            {
                var friendAnswer = _friend.AskWhoBetter(i);
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