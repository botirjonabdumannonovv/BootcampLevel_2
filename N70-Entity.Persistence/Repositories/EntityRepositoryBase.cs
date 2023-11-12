using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using N70_Entity.Domain.Common;

namespace N70_Entity.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => (TContext)_dbContext;
    private readonly DbContext _dbContext;

    public EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initailQuery = DbContext.Set<TEntity>().Where(entity => true);
        
        if(predicate is not null )
        {
            initailQuery = initailQuery.Where(predicate);
        }
        if(asNoTracking)
        {
            initailQuery = initailQuery.AsNoTracking(); 
        }
        return initailQuery;
    }
    public async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTraking = false, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if(asNoTraking)
        {
            initialQuery = initialQuery.AsNoTracking();
        }
        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken);
    }
    public async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default) 
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if(saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }
    public async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var type = typeof(TEntity);
        DbContext.Set<TEntity>().Update(entity);

        if(saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellation);
        }
        return entity;
    }
    public async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellation = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellation);
        }
        return entity;
    }
    public async ValueTask<TEntity?> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
            throw new InvalidOperationException();

        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }
}
