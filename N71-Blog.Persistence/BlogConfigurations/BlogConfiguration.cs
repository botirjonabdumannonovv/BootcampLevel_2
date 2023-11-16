using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasOne(blog => blog.User).WithMany(user => user.Blogs).HasForeignKey(blog => blog.UserId);
    }
}
