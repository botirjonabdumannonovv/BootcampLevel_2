using Notifications.Infrastructure.Application.Common.Notifications.Models;

namespace Notifications.Infrastructure.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}