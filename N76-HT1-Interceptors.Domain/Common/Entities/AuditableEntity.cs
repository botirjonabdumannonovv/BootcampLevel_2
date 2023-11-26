
namespace N76_HT1_Interceptors.Domain.Common.Entities;

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
}
