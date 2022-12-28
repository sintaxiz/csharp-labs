using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using ChoiceContender.Db.model;
using ChoiceContender.Db.repos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestsInMemory;

using Xunit;

public class GenerationWorldBehaviour
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions _contextOptions;

    #region ConstructorAndDispose

    public GenerationWorldBehaviour()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _contextOptions = new DbContextOptionsBuilder<HallContext>()
            .UseSqlite(_connection)
            .Options;

        using var context = new HallContext(_contextOptions);

        context.Database.EnsureCreated();

        context.AddRange(
            new Attempt() { Name = "A1" },
            new Attempt() { Name = "A2" });
        context.SaveChanges();
    }

    HallContext CreateContext() => new HallContext(_contextOptions);

    public void Dispose() => _connection.Dispose();

    #endregion

    [Fact]
    public void GenerateAttempt_noerror()
    {
        AttemptGenerator.GenerateAttempt("GenerateAttempt_noerror", CreateContext());
    }

    [Fact]
    public void GenerateAttempt_correctname()
    {
        using var context = CreateContext();
        var repo = new AttemptsRepo(context);
        AttemptGenerator.GenerateAttempt("testattempt", context);

        Assert.Equal(0,
            repo.GetSome(a => a.Name == "testattempt").Capacity);
    }

    [Fact]
    public void GenerateAttempt_notzerocontenders()
    {
        using var context = CreateContext();
        var attempt = AttemptGenerator.GenerateAttempt("GenerateAttempt_notzerocontenders", context);

        Assert.NotEmpty(attempt.Contenders);
    }
}