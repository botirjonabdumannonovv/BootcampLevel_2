using Library.Domain.Entites.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(book => book.Title).IsRequired().HasMaxLength(265);
        builder.Property(book => book.Description).IsRequired().HasMaxLength(265);

    }
}
