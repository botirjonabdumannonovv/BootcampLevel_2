using N76_HT1_Interceptors.Domain.Common.Entities;

namespace N76_HT1_Interceptors.Domain.Entities;

public class User : AuditableEntity, IDeletionAuditableEntity, IModificationAuditableEntity
{
    public string FirstName { get; set; } = default!;

    public Guid? DeletedByUserId { get; set; }
    
    public Guid? ModifiedByUserId { get; set; }
}
