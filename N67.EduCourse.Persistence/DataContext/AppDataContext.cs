using Microsoft.EntityFrameworkCore;

using N67.EduCourse.Domain.Entities;

namespace N67.EduCourse.Persistence.DataContext;

public class AppDataContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<StudentCourse> Students => Set<StudentCourse>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

}
