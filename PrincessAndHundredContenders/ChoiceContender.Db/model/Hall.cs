using ChoiceContender.Db.entities;
using ChoiceContender.Db.exceptions;

namespace ChoiceContender.Db.model;

public class Hall
{
    private readonly List<Contender> _contenders;

    public int CurrentContender { get; private set; }
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

    public void CallNextContender()
    {
        ++CurrentContender;
        if (CurrentContender >= _contenders.Count)
        {
            throw new NoContendersInHallException();
        }
    }
}