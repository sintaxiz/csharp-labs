using Microsoft.EntityFrameworkCore;
using ChoiceContender.Db.entities;

namespace ChoiceContender.Db.db;
public class HallContext : DbContext
{
    internal HallContext()
    {
        Database.EnsureCreated();
    }

    public HallContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contender> Contenders { get; set; }
    public DbSet<Attempt> Attempts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Host=localhost;Username=lumia;Password=admin;Database=princessdb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attempt>()
            .HasMany(a => a.Contenders).WithOne();
    }
}