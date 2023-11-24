using N71_Blog.Domain.Common;

namespace N71_Blog.Domain.Entities;

public class Blog : IEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }
    
    public Guid UserId { get; set; }
   
    public User User { get; set; }  

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
