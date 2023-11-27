namespace N71_Blog.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddHttpContextProvider()
            .AddPersistence()
            .AddExposers();

        return new(builder);
    }
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseBlogInfrastructure()
            .UseDevTools()
            .UseExposers();

        return new(app);
    }
}
