namespace N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Models;

public class RequestContext
{
    public Guid? UserId { get; set; }

    public string IpAddress { get; set; } = default!;

    public string UserAgent { get; set; } = default!;
}
