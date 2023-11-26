using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using N76_HT1_Interceptors.Domain.Common.Entities;

namespace N76_HT1_Interceptors.Persistence.Interceptors;

public class UpdateAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
        )
    {
        var auditableEntities = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();

        auditableEntities.ForEach(
            entry =>
            {
                if (entry.State == EntityState.Added)
                    entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTimeOffset.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTimeOffset.UtcNow;
            });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
