using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N76_HT1_Interceptors.Domain.Entities;

namespace N76_HT1_Interceptors.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(64);
    }
}
