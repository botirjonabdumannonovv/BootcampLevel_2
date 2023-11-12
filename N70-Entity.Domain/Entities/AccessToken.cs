using N70_Entity.Domain.Common;

namespace N70_Entity.Domain.Entities;

public class AccessToken : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }    

    public string Value { get; set; } = default!;

    public bool IsRevorked { get; set; }

    public DateTime CreatedDate { get; set; }
}
