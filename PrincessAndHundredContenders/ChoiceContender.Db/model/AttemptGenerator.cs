using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.exceptions;
using ChoiceContender.Db.repos;

namespace ChoiceContender.Db.model;

public static class AttemptGenerator
{
    private static Hall _hall;
    private static List<Contender> _contenders;
    private static ContendersRepo _contendersRepo;
    private static AttemptsRepo _attemptRepo;
    private static Attempt _attempt;
    private static HallContext _context;

    public static void GenerateAttempt(string name)
    {
        Console.WriteLine("ATTEMPT GENERATOR v0.1");

        _attempt = new Attempt()
            { Name = name, Count = 100 };
        _attempt.Contenders = new List<Contender>();
        _context = new HallContext();
        _attemptRepo = new AttemptsRepo(_context);
        _contendersRepo = new ContendersRepo(_context);

        _contenders = ContendersGenerator.GenerateRandom(100);


        var hall = new Hall(_contenders);
        _hall = hall;
        var friend = new Friend(_contenders, _hall);

        var contendersCount = _hall.GetContendersCount();
        if (_hall.CurrentContender != -1)
        {
            throw new NoContendersInHallException();
        }

        while (_hall.CurrentContender != contendersCount / 2)
        {
            _hall.CallNextContender();
            saveContender(_hall.CurrentContender);
        }

        while (_hall.CurrentContender != contendersCount - 1)
        {
            var isBetterCount = 0;
            for (var i = 0; i < _hall.CurrentContender; i++)
            {
                var friendAnswer = friend.AskWhoBetter(i);
                if (friendAnswer)
                {
                    ++isBetterCount;
                }
            }

            if (isBetterCount >= contendersCount / 2)
            {
                break;
            }

            _hall.CallNextContender();
            saveContender(_hall.CurrentContender);
        }

        _attemptRepo.Add(_attempt);
        _context.SaveChanges();
    }

    private static void saveContender(int idx)
    {
        var contender = _contenders[_hall.CurrentContender];
        contender.Attempt = _attempt;
        contender.OrderIdx = idx;
        _contendersRepo.Add(contender);
        _attempt.Contenders.Add(contender);
    }
}