using ChoiceContender.exceptions;

namespace ChoiceContender;

public class Hall : IHall
{
    private readonly List<Contender> _contenders;

    public int CurrentContender { get; set; }
    //list checkedContenders
    //Hall(c1, c2)

    public Hall(List<Contender> contenders)
    {
        _contenders = contenders;
        CurrentContender = -1;
    }

    public int GetContendersCount()
    {
        return _contenders.Count;
    }

    public Task CallNextContender()
    {
        ++CurrentContender;
        if (CurrentContender >= _contenders.Count)
        {
            throw new NoContendersInHallException();
        }
        return Task.CompletedTask;
    }
}