using AutoMapper;

using Drives.Application.Common.Brokers;
using Drives.Application.Common.Models;

namespace Drives.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(driveInfo => _mapper.Map<StorageDrive>(driveInfo));
    }
}
