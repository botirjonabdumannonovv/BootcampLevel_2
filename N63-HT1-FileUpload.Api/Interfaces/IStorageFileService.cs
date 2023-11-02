using System.Linq.Expressions;

using N63_HT1_FileUpload.Api.Models.Entites;

namespace N63_HT1_FileUpload.Api.Interfaces;

public interface IStorageFileService
{
    ValueTask<StorageFile> CreateAsync(StorageFile storageFile);

    IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate);
}
