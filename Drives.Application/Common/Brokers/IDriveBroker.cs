using Drives.Application.Common.Models;

namespace Drives.Application.Common.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}
