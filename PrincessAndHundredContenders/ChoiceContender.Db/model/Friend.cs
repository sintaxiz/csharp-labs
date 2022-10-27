using ChoiceContender.Db.entities;
using ChoiceContender.Db.exceptions;

namespace ChoiceContender.Db.model;

public class Friend
{
    private List<Contender> _contenders;
    private Hall _hall;
    
    public Friend(List<Contender> contenders, Hall hall)
    {
        _contenders = contenders;
        _hall = hall;
    }

    public bool AskWhoBetter(int checkContender)
    {
        if (checkContender > _hall.CurrentContender)
        {
            throw new UnfamiliarContenderException();
        }
        return _contenders.Last().Rating >= _contenders[checkContender].Rating;
    }

    public void AddContender(Contender contender)
    {
        _contenders.Add(contender);
    }
}