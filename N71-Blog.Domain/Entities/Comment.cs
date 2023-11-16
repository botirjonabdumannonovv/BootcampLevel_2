namespace N71_Blog.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public string Message { get; set; } = default!;

    public Guid UserId { get; set; }

    public Guid BlogId { get; set; }

    public virtual Blog Blog { get; set; }

    public virtual User User { get; set; }
}
