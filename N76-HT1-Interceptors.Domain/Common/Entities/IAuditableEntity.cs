namespace N76_HT1_Interceptors.Domain.Common.Entities;

public interface IAuditableEntity : IEntity
{
    DateTimeOffset CreatedTime { get; set; }

    DateTimeOffset? ModifiedTime { get; set; }
}
