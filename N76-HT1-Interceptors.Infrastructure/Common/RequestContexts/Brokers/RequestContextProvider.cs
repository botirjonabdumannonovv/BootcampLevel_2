using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using N76_HT1_Interceptors.Domain.Brokers;
using N76_HT1_Interceptors.Domain.Constants;
using N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Models;
using N76_HT1_Interceptors.Infrastructure.Common.Settings;

namespace N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Brokers;

public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public RequestContext GetRequestContext()
    {
        var httpContext = httpContextAccessor.HttpContext!;
        var userIdClaim = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;

        var requestContext = new RequestContext
        {
            UserId = userIdClaim is not null ? Guid.Parse(userIdClaim) : default,
            IpAddress = httpContext.Connection.RemoteIpAddress!.ToString(),
            UserAgent = httpContext.Request.Headers[HeaderNames.UserAgent].ToString()
        };

        return requestContext;
    }
}