using N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Models;

namespace N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Brokers;

public interface IRequestContextProvider
{
    RequestContext GetRequestContext();
}
