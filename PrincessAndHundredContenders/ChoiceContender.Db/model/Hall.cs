using ChoiceContender.Db.entities;
using ChoiceContender.Db.exceptions;

namespace ChoiceContender.Db.model;

public class Hall
{
    public List<Contender> Contenders { get; }

    public int CurrentContender { get; private set; }
    //list checkedContenders
    //Hall(c1, c2)

    public Hall(List<Contender> contenders)
    {
        Contenders = contenders;
        CurrentContender = -1;
    }

    public int GetContendersCount()
    {
        return Contenders.Count;
    }

    public void CallNextContender()
    {
        ++CurrentContender;
        if (CurrentContender >= Contenders.Count)
        {
            throw new NoContendersInHallException();
        }
    }
}