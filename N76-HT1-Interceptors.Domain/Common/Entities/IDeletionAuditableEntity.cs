namespace N76_HT1_Interceptors.Domain.Common.Entities;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId {  get; set; } 
}
