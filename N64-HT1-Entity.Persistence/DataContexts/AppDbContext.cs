using Microsoft.EntityFrameworkCore;

using N64_HT1_Entity.Domain.Entites;

namespace N64_HT1_Entity.Persistence.DataContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=IdentityDB;Username=postgres;Password=postgres");
    }
}
