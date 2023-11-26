namespace N76_HT1_Interceptors.Domain.Brokers;

public interface IRequestUserContextProvider
{
    Guid GetUserIdAsync (CancellationToken cancellationToken = default);
}
