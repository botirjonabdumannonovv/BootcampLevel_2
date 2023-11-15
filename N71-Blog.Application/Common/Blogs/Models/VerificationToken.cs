using N71_Blog.Application.Common.Enums;

namespace N71_Blog.Application.Common.Blogs.Models;

public class VerificationToken
{
    public Guid UserId { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }  
}
