using System.Collections.Generic;
using System.Reflection.Emit;

using Library.Domain.Entites.Models;

using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.DataContext;

public class AppDBContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();


    public AppDBContext(DbContextOptions<AppDBContext> optoins) : base(optoins)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
    }
}
