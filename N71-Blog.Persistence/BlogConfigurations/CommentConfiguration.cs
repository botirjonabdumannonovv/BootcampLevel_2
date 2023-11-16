using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using N71_Blog.Domain.Entities;

namespace N71_Blog.Persistence.BlogConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.Blog).WithMany(comment => comment.Comments).HasForeignKey(comment => comment.BlogId);

        builder.HasOne(comment => comment.User).WithMany(comment => comment.Comments).HasForeignKey(user => user.UserId);
    }
}
