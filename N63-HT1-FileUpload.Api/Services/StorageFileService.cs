using N63_HT1_FileUpload.Api.DataAccess;
using System.Linq.Expressions;

using N63_HT1_FileUpload.Api.Interfaces;
using N63_HT1_FileUpload.Api.Models.Entites;

namespace N63_HT1_FileUpload.Api.Services;

public class StorageFileService : IStorageFileService
{
    private readonly IDataContext _context;

    public StorageFileService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<StorageFile> CreateAsync(StorageFile storageFile)
    {
        await _context.StorageFiles.AddAsync(storageFile);
        await _context.SaveChangesAsync();

        return storageFile;
    }

    public IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate)
        => _context.StorageFiles.Where(predicate.Compile()).AsQueryable();
}
