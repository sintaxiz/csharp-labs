using ChoiceContender.Db.entities;
using Microsoft.EntityFrameworkCore;

namespace ChoiceContender.Db.db;

public class HallInitializer
{

    public static void RecreateDatabase(HallContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public static void InitData(HallContext context)
    {
        //List<Contender> contenders = ContendersGenerator.GenerateRandom(100);
        //contenders.ForEach(c => context.Contenders.Add(new entities.Contender{Name = c.Name, Rating = c.Rating}));
        context.Attempts.Add(new Attempt { Count = 5, Name = "attemp1"});
        context.SaveChanges();
        context.Database.CloseConnection();
    }
}
