using Notifications.Infrastructure.Domain.Common.Entities;
using Notifications.Infrastructure.Domain.Enums;

namespace Notifications.Infrastructure.Domain.Entities;

public class UserSettings : IEntity
{
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}