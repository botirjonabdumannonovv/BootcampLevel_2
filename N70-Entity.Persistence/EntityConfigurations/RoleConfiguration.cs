using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N70_Entity.Domain.Entities;
using N70_Entity.Domain.Enums;

namespace N70_Entity.Persistence.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasIndex(role => role.Type).IsUnique();

        builder.HasData(new Role
            {
                Id = Guid.Parse("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                Type = RoleType.Admin,
                CreatedDate = DateTime.UtcNow,
            },
            new Role
            {
                Id = Guid.Parse("fb05f885-807c-445a-aaff-673ee99f46f3"),
                Type = RoleType.Guest,
                CreatedDate = DateTime.UtcNow,
            },
            new Role
            {
                Id = Guid.Parse("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                Type = RoleType.Host,
                CreatedDate = DateTime.UtcNow
            });
        
    }
}
