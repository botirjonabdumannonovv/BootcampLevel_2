using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using N76_HT1_Interceptors.Domain.Common.Entities;
using N76_HT1_Interceptors.Domain.Brokers;

namespace N76_HT1_Interceptors.Persistence.Interceptors;

public class UpdateAuditableInterceptor(IRequestUserContextProvider requestUserContextProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
        )
    {
        var auditableEntities = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();
        var creationAuditableEntities = eventData.Context!.ChangeTracker.Entries<ICreationAuditableEntity>().ToList();
        var modificationAuditableEntities = eventData.Context!.ChangeTracker.Entries<IModificationAuditableEntity>().ToList();
        var deletionAuditableEntities = eventData.Context!.ChangeTracker.Entries<IDeletionAuditableEntity>().ToList();
        var isDeletedEntities = eventData.Context!.ChangeTracker.Entries<ISoftDeletedEntity>().ToList();

        auditableEntities.ForEach(
            entry =>
            {
                if (entry.State == EntityState.Added)
                    entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTimeOffset.UtcNow;
                
                if (entry.State == EntityState.Modified)
                    entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTimeOffset.UtcNow;
            });

         creationAuditableEntities.ForEach(
             entry =>
             {
                 if (entry.State == EntityState.Added)
                     entry.Property(nameof(ICreationAuditableEntity.CreatedByUserId)).CurrentValue = requestUserContextProvider.GetUserIdAsync();
             }
         );

         modificationAuditableEntities.ForEach(
             entry =>
             {
                 if (entry.State == EntityState.Modified)
                     entry.Property(nameof(IModificationAuditableEntity.ModifiedByUserId)).CurrentValue = requestUserContextProvider.GetUserIdAsync();
             }
         );

         deletionAuditableEntities.ForEach(
             entry =>
             {
                 if (entry.State == EntityState.Deleted)
                     entry.Property(nameof(IDeletionAuditableEntity.DeletedByUserId)).CurrentValue = requestUserContextProvider.GetUserIdAsync();
             }
         );
        isDeletedEntities.ForEach(
            entry =>
        {
            if (entry.State == EntityState.Deleted)
                entry.Property(nameof(ISoftDeletedEntity.IsDeleted)).CurrentValue = requestUserContextProvider.GetUserIdAsync();

            if (entry.State == EntityState.Deleted)
                entry.Property(nameof(ISoftDeletedEntity.DeletedTime)).CurrentValue = requestUserContextProvider.GetUserIdAsync();
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
