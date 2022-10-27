// See https://aka.ms/new-console-template for more information

using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.model;
using ChoiceContender.Db.repos;

Console.WriteLine("ATTEMPT GENERATOR v0.1");

using (var context = new HallContext())
{
    Console.WriteLine("Creating database...");
    HallInitializer.RecreateDatabase(context);
    Console.WriteLine("Initializing data...");
    HallInitializer.InitData(context);

    var repo = new BaseRepo<Attempt>(context);
    repo.Add(AttemptGenerator.GenerateAttempt(100, "attempt2"));
    context.SaveChanges();
}

