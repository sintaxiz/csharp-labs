using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.repos;

namespace ChoiceContender.Db.model;

public static class AttemptGenerator
{
    public static void GenerateAttempt(string name)
    {
        Console.WriteLine("ATTEMPT GENERATOR v0.1");
        
        var repo = new BaseRepo<Attempt>();
        
        var contenders = ContendersGenerator.GenerateRandom(100);
        
        
        repo.Add(new Attempt { Name = name, Count = 100, Contenders = contenders });
    }
}