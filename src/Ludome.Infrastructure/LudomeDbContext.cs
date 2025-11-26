using Ludome.Domain;
using Ludome.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ludome.Infrastructure;

public class LudomeDbContext : DbContext
{
    public LudomeDbContext(DbContextOptions<LudomeDbContext> options) : base(options)
    {
    }

    public LudomeDbContext() : base()
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=ludome.database;Port=5432;Username=postgres;Password=1234;Database=ludome");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new UserConfiguration().Configure(modelBuilder.Entity<User>());
    }
}