using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(token => token.UserId);
    }
}
