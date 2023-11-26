namespace N76_HT1_Interceptors.Domain.Common.Entities;

public interface ISoftDeletedEntity : IEntity
{
    bool IsDeleted { get; set; }

    DateTimeOffset? DeletedTime { get; set; }
}
