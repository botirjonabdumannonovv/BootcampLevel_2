using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N70_Entity.Domain.Entities;

namespace N70_Entity.Persistence.EntityConfigurations;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        builder.HasOne<User>().WithOne().HasForeignKey<AccessToken>(token => token.UserId);
    }
}
