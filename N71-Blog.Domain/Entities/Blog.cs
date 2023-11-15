namespace N71_Blog.Domain.Entities;

public class Blog
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid UserId { get; set; }
}
