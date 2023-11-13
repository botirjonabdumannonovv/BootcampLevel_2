using Microsoft.EntityFrameworkCore;

using N70_Entity.Apii.Configurations;
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

var adminPassword = passwordHasherService.HashPassword("AdminTest1");
var guestPassword = passwordHasherService.HashPassword("GuestTest1");

var user = await dbContext.Users.Include(user => user.Role).OrderBy(user => user.Id).FirstOrDefaultAsync();
string token = tokenGeneratorService.GetToken(user);

await app.RunAsync();