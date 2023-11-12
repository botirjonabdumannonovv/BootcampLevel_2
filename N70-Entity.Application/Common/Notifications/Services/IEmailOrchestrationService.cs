namespace N70_Entity.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress,string message);
}
