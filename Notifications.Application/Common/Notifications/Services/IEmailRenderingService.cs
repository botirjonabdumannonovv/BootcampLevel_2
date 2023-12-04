using Notifications.Infrastructure.Application.Common.Notifications.Models;

namespace Notifications.Infrastructure.Application.Common.Notifications.Services;

public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default
    );
}