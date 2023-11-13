using Microsoft.EntityFrameworkCore;

using N70_Entity.Api.Configurations;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Persistence.DataContexts;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();

var scope = app.Services.CreateScope().ServiceProvider;

var dbContext = scope.GetRequiredService<IdentityDbContext>();
var tokenGeneratorService = scope.GetRequiredService<ITokenGeneratorService>();
var passwordHasherService = scope.GetRequiredService<IPasswordHasherService>();


var user = await dbContext.Users
    .Include(user => user.Role)
    .OrderBy(user => user.Id).FirstOrDefaultAsync();
var token = tokenGeneratorService.GetToken(user);

await app.RunAsync();