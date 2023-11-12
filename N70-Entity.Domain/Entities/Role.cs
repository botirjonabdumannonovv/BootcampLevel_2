using N70_Entity.Domain.Common;
using N70_Entity.Domain.Enums;

namespace N70_Entity.Domain.Entities;

public class Role : IEntity
{
    public Guid Id {  get; set; }

    public RoleType Type { get; set; } 
    
    public bool IsDisabled { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

}
