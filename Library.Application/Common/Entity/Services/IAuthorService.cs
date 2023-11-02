using System.Linq.Expressions;

using Library.Domain.Entites.Models;

namespace Library.Application.Common.Entity.Services;

public interface IAuthorService
{
    ValueTask<ICollection<Author>> GetAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken = default);

    IQueryable<Author> Get(Expression<Func<Author, bool>>? pridicate = null);

    ValueTask<Author> GetByIdAsync(Guid autherId, CancellationToken cancellationToken = default);

    ValueTask<Author> CreateAsync(Author auther, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Author> UpdateAsync(Author auther, bool saveChance = true, CancellationToken cancellationToken = default);

    ValueTask<Author> DeleteByIdAsync(Guid autherId, bool saveChanges = true, CancellationToken cancellationToken = default);

}
