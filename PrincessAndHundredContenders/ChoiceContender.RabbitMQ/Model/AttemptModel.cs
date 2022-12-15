namespace ChoiceContender.RabbitMQ.Model;

using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.model;
using ChoiceContender.Db.repos;

public class AttemptModel
{
    private readonly Attempt _attempt;
    private int _currentContender;

    public AttemptModel(string attemptForNext)
    {
        var simulator = new AttemptSimulator(attemptForNext);
        _attempt = simulator.Attempt;
        _currentContender = -1;
    }


    public string? CallNextContender()
    {
        if (_currentContender < 0 && _currentContender >= _attempt.Contenders.Count)
        {
            return null;
        }
        _currentContender = _currentContender + 1;
        return _attempt.Contenders[_currentContender].Name;

    }


    public int ChooseCurrentContender()
    {
        return _attempt.Contenders[_currentContender].Rating;
    }

    public string? CompareContenders(string contender1, string contender2)
    {
        var contender1Rate = -1;
        var contender2Rate = -1;
        _attempt.Contenders.ForEach(delegate(Contender contender)
        {
            if (contender.Name == contender1)
            {
                contender1Rate = contender.Rating;
            }
            else if (contender.Name == contender2)
            {
                contender2Rate = contender.Rating;
            }
            
        });
        if (contender1Rate == -1 || contender2Rate == -1)
        {
            throw new Exception("Not existing contender!");
        }

        return contender1Rate > contender2Rate ? contender1 : contender2;
    }

    public void Reset()
    {
        _currentContender = -1;
    }
}