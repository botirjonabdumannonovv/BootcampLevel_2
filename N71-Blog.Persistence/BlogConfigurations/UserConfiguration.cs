using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = Guid.Parse("9c0c1672-543b-457b-931a-993d1cc57cde"),
            FirstName = "Botirjon",
            LastName = "Abdumannonov",
            EmailAddress = "thedavlativich@gmail.com",
            PasswordHash = "bilmayman",
        });
    }
}
