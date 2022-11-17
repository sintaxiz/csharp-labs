using Microsoft.EntityFrameworkCore;
using ChoiceContender.Db.entities;

namespace ChoiceContender.Db.db;

public class HallContext : DbContext
{
    #region Constructors

    internal HallContext()
    {
        Database.EnsureCreated();
    }

    public HallContext(DbContextOptions options) : base(options)
    {
    }

    #endregion

    public DbSet<Contender> Contenders => Set<Contender>();
    public DbSet<Attempt> Attempts => Set<Attempt>();

    #region OnConfiguring

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Username=lumia;Password=admin;Database=princessdb");
        }
    }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attempt>()
            .HasMany(a => a.Contenders)
            .WithOne(c => c.Attempt);
    }
}