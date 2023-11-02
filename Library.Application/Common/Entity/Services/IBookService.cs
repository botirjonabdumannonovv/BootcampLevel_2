using System.Linq.Expressions;

using Library.Domain.Entites.Models;

namespace Library.Application.Common.Entity.Services;

public interface IBookService
{
    ValueTask<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken = default);

    IQueryable<Book> Get(Expression<Func<Book, bool>>? pridicate = null);

    ValueTask<Book> CreateAsync(Book book, bool saveChanges, CancellationToken cancellationToken = default);

    ValueTask<Book> UpdateAsync(Book book, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Book> DeleteByIdAsync(Guid bookId, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<ICollection<Book>> GetAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken = default);
}
