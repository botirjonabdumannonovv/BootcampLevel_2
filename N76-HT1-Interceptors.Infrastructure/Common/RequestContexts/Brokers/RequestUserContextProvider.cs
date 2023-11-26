using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using N76_HT1_Interceptors.Domain.Brokers;
using N76_HT1_Interceptors.Domain.Constants;
using N76_HT1_Interceptors.Infrastructure.Common.Settings;

namespace N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Brokers;

public class RequestUserContextProvider(
    IHttpContextAccessor httpContextAccessor,
    IOptions<RequestUserContextSettings> requestUserContextSettings
    ) : IRequestUserContextProvider
{
    private readonly RequestUserContextSettings _requestUserContextSettings = requestUserContextSettings.Value;
    public Guid GetUserIdAsync(CancellationToken cancellationToken = default)
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;
        return userClaim is not null ? Guid.Parse(userClaim) : _requestUserContextSettings.SystemUserId;
    }
}