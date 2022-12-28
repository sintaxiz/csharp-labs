using ChoiceContender.exceptions;

namespace ChoiceContender;

public class Friend : IFreind
{
    private List<Contender> _contenders;
    private IHall _hall;
    
    public Friend(List<Contender> contenders, IHall hall)
    {
        _contenders = contenders;
        _hall = hall;
    }

    public async Task<bool> AskWhoBetter(int checkContender)
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