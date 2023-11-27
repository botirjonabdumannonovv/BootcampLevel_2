using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using N76_HT1_Interceptors.Persistence.DataContexts;
using N76_HT1_Interceptors.Persistence.Interceptors;
using N76_HT1_Interceptors.Persistence.Repositories;
using N76_HT1_Interceptors.Persistence.Repositories.Interfaces;
using N76_HT1_Interceptors.Application.Common.Identity;
using N76_HT1_Interceptors.Infrastructure.Common.Identity;
using N76_HT1_Interceptors.Application.Common.Identity.Services;
using N76_HT1_Interceptors.Infrastructure.Common.Identity.Services;
using N76_HT1_Interceptors.Infrastructure.Common.Settings;
using N76_HT1_Interceptors.Domain.Brokers;
using N76_HT1_Interceptors.Infrastructure.Common.RequestContexts.Brokers;

namespace N76_HT1_Interceptors.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RequestUserContextSettings>(builder.Configuration.GetSection(nameof(RequestUserContextSettings)));
        
        builder.Services.AddHttpContextAccessor();
        
        builder.Services.AddScoped<IRequestUserContextProvider, RequestUserContextProvider>()
            .AddScoped<IRequestContextProvider, RequestContextProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<UpdateAuditableInterceptor>()
            .AddScoped<UpdatePrimaryKeyInterceptor>();
            
        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<InterceptorDbContext>(
            (provider, options) =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

                var serviceScope = provider.CreateScope().ServiceProvider;
                options.AddInterceptors(provider.GetRequiredService<UpdateAuditableInterceptor>());
                options.AddInterceptors(provider.GetRequiredService<UpdatePrimaryKeyInterceptor>());
            }
        );

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        builder.Services.AddFluentValidationAutoValidation();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
