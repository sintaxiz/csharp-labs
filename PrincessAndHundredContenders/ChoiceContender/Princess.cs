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
        while (_hall.CurrentContender != 50)
        {
            _hall.CallNextContender();
        }

        while (_hall.CurrentContender != 100)
        {
            int isBetterCount = 0;
            for (int i = 0; i < _hall.CurrentContender; i++)
            {
                bool friendAnswer = _hall.AskFriend(i);
                if (friendAnswer)
                {
                    ++isBetterCount;
                }
            }

            if (isBetterCount >= 50)
            {
                return _hall.CurrentContender;
            }

            _hall.CallNextContender();
        }

        return -1; // nobody
    }
}