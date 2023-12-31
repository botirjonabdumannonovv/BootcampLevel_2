﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Application.Common.Notifications.Services;
using N70_Entity.Application.Common.Settings;
using N70_Entity.Infrastructure.Common.Identity.Services;
using N70_Entity.Infrastructure.Common.Notifications.Services;
using N70_Entity.Persistence.DataContexts;
using N70_Entity.Persistence.Repositories;
using N70_Entity.Persistence.Repositories.Interfaces;

namespace N70_Entity.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
        builder.Services.Configure<VerificationTokenSettings>(
            builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services.AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IVerificationTokenGeneratorService, VerificationTokenGeneratorService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();

        builder.Services.AddScoped<IAccountService, AccountService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IRoleService, RoleService>();

        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

        builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();

        return builder;
    }


    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseIdentityInfrastructure(this WebApplication app)
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
