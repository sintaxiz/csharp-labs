using ChoiceContender.Db.entities;

namespace ChoiceContender.Web.Model;

public class HallModel
{
    private Dictionary<string, AttemptModel> _attempts;
    private static HallModel? _hallModel;

    private HallModel()
    {
        _attempts = new Dictionary<string, AttemptModel>();
    }

    public void ResetAttempts()
    {
        foreach (var (key, value) in _attempts)
        {
            _attempts[key].Reset();
        }
    }

    public string? CallNextContenderForAttempt(string attemptForNext)
    {
        if (!_attempts.ContainsKey(attemptForNext))
        {
            _attempts[attemptForNext] = new AttemptModel(attemptForNext);
        }
        return _attempts[attemptForNext].CallNextContender();
    }

    public int SelectContenderForAttempt(string attemptForSelect)
    {
        if (_attempts.ContainsKey(attemptForSelect))
        {
            return _attempts[attemptForSelect].ChooseCurrentContender();
        }
        _attempts[attemptForSelect] = new AttemptModel(attemptForSelect);
        return -1;

    }

    public string? CompareContendersForAttempt(string attemptForCompare, string contender1, string contender2
    )
    {
        if (!_attempts.ContainsKey(attemptForCompare))
        {
            _attempts[attemptForCompare] = new AttemptModel(attemptForCompare);
            return "";
        }

        return _attempts[attemptForCompare].CompareContenders(contender1, contender2);
    }

    public static HallModel? getInstance()
    {
        if (_hallModel == null)
        {
            _hallModel = new HallModel();
        }

        return _hallModel;
    }
}