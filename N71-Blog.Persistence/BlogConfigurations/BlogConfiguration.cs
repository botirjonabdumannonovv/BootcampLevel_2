using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasIndex(blog =>  blog.Id).IsUnique();

        builder.HasData(new Blog
        {
            Id = Guid.Parse("8b77756d-d256-49bb-bdbb-4568fdcacb33"),
            Name = "None",
            CreatedDate = DateTime.UtcNow,
        });
    }
}
