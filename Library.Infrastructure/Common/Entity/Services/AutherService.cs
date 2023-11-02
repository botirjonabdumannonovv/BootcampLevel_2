using System.Linq.Expressions;
using System;
using Library.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using Library.Persistence.DataContext;
using Library.Application.Common.Entity.Services;

public class AutherService : IAuthorService
{
    private readonly AppDBContext _appDBContext;

    public AutherService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public ValueTask<ICollection<Author>> GetAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Author> Get(Expression<Func<Author, bool>>? pridicate = null)
     => pridicate != null ? _appDBContext.Authors.Where(pridicate) : _appDBContext.Authors;

    public ValueTask<Author> GetByIdAsync(Guid autherId, CancellationToken cancellationToken = default)
    {
        var auther = _appDBContext.Authors.FirstOrDefault(auther => auther.Id == autherId);

        if (auther is null) throw new InvalidOperationException("Auther not found");

        return new ValueTask<Author>(auther);
    }

    public async ValueTask<Author> CreateAsync(Author auther, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        auther.Id = Guid.NewGuid();
        await _appDBContext.Authors.AddAsync(auther, cancellationToken);

        if (saveChanges) await _appDBContext.SaveChangesAsync(cancellationToken);

        return auther;
    }

    public async ValueTask<Author> UpdateAsync(Author auther, bool saveChance = true, CancellationToken cancellationToken = default)
    {
        var foundAuther = await GetByIdAsync(auther.Id);

        foundAuther.FirstName = auther.FirstName;
        foundAuther.LastName = auther.LastName;

        _appDBContext.Authors.Update(foundAuther);

        if (saveChance) await _appDBContext.SaveChangesAsync(cancellationToken);

        return foundAuther;
    }

    public async ValueTask<Author> DeleteByIdAsync(Guid autherId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundAuther = _appDBContext.Authors.Find(autherId);

        if (foundAuther is null)
            throw new InvalidOperationException($"User with id {foundAuther} not found.");

        _appDBContext.Authors.Remove(foundAuther);

        if (saveChanges) await _appDBContext.SaveChangesAsync(cancellationToken);

        return foundAuther;
    }
}
