using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.DataContexts;

public class BlogsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Blog> Blogs => Set<Blog>();

    public DbSet<Comment> Comments => Set<Comment>();

    public BlogsDbContext(DbContextOptions<BlogsDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogsDbContext).Assembly);
    }
}
