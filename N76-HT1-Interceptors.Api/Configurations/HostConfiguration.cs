namespace N76_HT1_Interceptors.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddRequestContextTools()
            .AddPersistence()
            .AddIdentityInfrastructure()
            .AddDevTools()
            .AddExposers();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseExposers();

        return new(app);
    }
}
