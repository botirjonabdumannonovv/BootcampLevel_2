using Microsoft.EntityFrameworkCore;
using N76_HT1_Interceptors.Domain.Entities;

namespace N76_HT1_Interceptors.Persistence.DataContexts;

public class InterceptorDbContext(DbContextOptions<InterceptorDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InterceptorDbContext).Assembly);
    }
}
