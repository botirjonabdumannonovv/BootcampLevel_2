using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user => user.Blog).WithMany().HasForeignKey(user => user.BlogId);

        builder.HasData(new User
        {
            Id = Guid.Parse("9c0c1672-543b-457b-931a-993d1cc57cde"),
            FirstName = "Botirjon",
            LastName = "Abdumannonov",
            EmailAddress = "thedavlativich@gmail.com",
            Password = "bilmayman",
            BlogId = Guid.Parse("8b77756d-d256-49bb-bdbb-4568fdcacb33")
        });
    }
}
