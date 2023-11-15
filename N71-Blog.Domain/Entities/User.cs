namespace N71_Blog.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public Guid BlogId { get; set; }

    public virtual Blog Blog { get; set; }
}
