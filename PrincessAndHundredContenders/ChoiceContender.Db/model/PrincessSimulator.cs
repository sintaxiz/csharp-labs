using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.repos;

namespace ChoiceContender.Db.model;

public static class PrincessSimulator
{
    private static readonly string Delimiter = new('-', 10);

    public static void SimulateBehavior(string attemptName)
    { 
        var attemptsRepo = new AttemptsRepo(new HallContext());
        var contendersRepo = new ContendersRepo(new HallContext());
        var attempts = attemptsRepo.GetSome(attempt => attempt.Name == attemptName);
        var attempt = attempts[0];
        attempt.Contenders = contendersRepo.GetSome(c => c.Attempt.Id == attempt.Id);
        Simulate(attempt);
    }

    public static void SimulateAll()
    {
        var repo = new AttemptsRepo(new HallContext());
        var attempts = repo.GetAll();
        attempts.ForEach(Simulate);
    }

    private static void Simulate(Attempt attempt)
    {
        Console.WriteLine("--Princess Behavior simulation--");
        Console.WriteLine("Attempt name: " + attempt.Name);
        Console.WriteLine("Contenders count: " + attempt.Contenders.Count);
        attempt.Contenders.ForEach(c => Console.WriteLine(c.Name + ":" + c.Rating));
        var contenders = attempt.Contenders;
        contenders.Sort((c1, c2) => c1.OrderIdx - c2.OrderIdx);
        var hall = new Hall(contenders);
        var friend = new Friend(contenders, hall);
        var princess = new Princess(hall, friend);
        var husbandIdx = princess.ChoseHusband();
        var happyLevel = 0;
        if (husbandIdx == -1)
        {
            happyLevel = 10;
        }
        else if (contenders[husbandIdx].Rating <= 50)
        {
            happyLevel = 0;
        }
        else
        {
            happyLevel = contenders[husbandIdx].Rating;
        }

        Console.WriteLine($"Chosen husband: {contenders[husbandIdx].Name}" +
                          $"/{contenders[husbandIdx].Rating}");
        Console.WriteLine($"Happy level: {happyLevel}");
        
        Console.WriteLine(Delimiter);
    }
}