using FileBaseContext.Abstractions.Models.FileSet;

using N63_HT1_FileUpload.Api.Models.Entites;

namespace N63_HT1_FileUpload.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<StorageFile, Guid> StorageFiles { get; }

    ValueTask SaveChangesAsync();
}
