using System.Text;

using FileBaseContext.Context.Models.Configurations;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using N63_HT1_FileUpload.Api.DataAccess;
using N63_HT1_FileUpload.Api.Interfaces;
using N63_HT1_FileUpload.Api.Models.Constants;
using N63_HT1_FileUpload.Api.Models.Settings;
using N63_HT1_FileUpload.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();

    return context;
});

builder.Services.AddSingleton<FileService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IStorageFileService, StorageFileService>()
                .AddSingleton<PasswordHasherService>()
                .AddTransient<TokenGeneratorService>();

builder.Services.AddControllers();


builder.Services.AddRouting(options => options.LowercaseUrls = true);

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = jwtSettings.ValidateLifeTime,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
        };
    });


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(SwaggerConstants.SecurityDefinitionName, new OpenApiSecurityScheme
    {
        Name = SwaggerConstants.SecuritySchemeName,
        Type = SecuritySchemeType.ApiKey,
        Scheme = SwaggerConstants.SecurityScheme,
        In = ParameterLocation.Header,
        Description = SwaggerConstants.SwaggerAuthorizationDescription
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = SwaggerConstants.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();