using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N70_Entity.Domain.Entities;

namespace N70_Entity.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Role).WithMany().HasForeignKey(user => user.RoleId);

        builder.HasData(new User
        {
            Id = Guid.Parse("0238e5c5-28cd-4b5a-8e17-5700e5840983"),
            FirstName = "John",
            LastName = "Doe",
            Age = 1,
            EmailAddress = "thedavlativich@gmail.com",
            PasswordHash = "",
            IsEmailAddressVerified = true,
            RoleId = Guid.Parse("45467824-7527-4530-a7fe-6d38dd09a3c5")
        });
    }
}
