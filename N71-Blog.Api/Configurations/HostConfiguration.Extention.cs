using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace N71_Blog.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddHttpContextProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this  WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DbContext>(options => options.UseNpgsql("DefaultConnection"));

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }
    private static WebApplication UseBlogInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
