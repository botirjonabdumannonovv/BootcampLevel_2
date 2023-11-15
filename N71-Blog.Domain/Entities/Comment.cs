namespace N71_Blog.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public Guid UserId { get; set; }

    public Guid BlogId { get; set; }
}
