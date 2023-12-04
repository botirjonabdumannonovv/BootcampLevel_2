using Notifications.Infrastructure.Application.Common.Notifications.Models;
using Notifications.Infrastructure.Domain.Common.Exceptions;

namespace Notifications.Infrastructure.Application.Common.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}