using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N71_Blog.Domain.Common;

namespace N71_Blog.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => (TContext)_dbContext;
    private readonly DbContext _dbContext;

    public EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? predicate = default,
        bool asNoTracking = false
        )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if(predicate is not null) 
            initialQuery = initialQuery.Where(predicate);
        
        if(asNoTracking)
            initialQuery = initialQuery.AsNoTracking();
        
        return initialQuery;
    }
    public async ValueTask<TEntity?> GetByIdAsync(
        Guid id,
        bool asNoTracking = false, 
        CancellationToken cancellation = default
        )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();
        
        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellation);
    }

    public async ValueTask<IList<TEntity>> GetByIdAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellation = default
        ) 
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();
        
        initialQuery = initialQuery
            .Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellation);    

    }
    public async ValueTask<TEntity> CreateAsync(
        TEntity entity,
        bool saveChanges =  true,
        CancellationToken cancellationToken = default
        ) 
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if(saveChanges )
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }

    public async ValueTask<TEntity> UpdateAsync(
        TEntity entity,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var type = typeof(TEntity);

        DbContext.Set<TEntity>().Update(entity);

        if(saveChanges )
        {
            await DbContext.SaveChangesAsync( cancellationToken);
        }
        return entity;
    }
    
    public async ValueTask<TEntity> DeleteAsync(
        TEntity entity, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default
        )
    {
        DbContext.Set<TEntity>().Remove(entity);

        if(saveChanges )
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }
    
    public async ValueTask<TEntity?> DeleteByIdAsync(
        Guid id,
        bool saveChanges = true, 
        CancellationToken cancellation = default
        )
    {
        var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellation) ??
            throw new InvalidOperationException();

        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellation);
        }
        return entity;
    }
}
