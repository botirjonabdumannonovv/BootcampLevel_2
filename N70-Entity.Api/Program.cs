using Microsoft.EntityFrameworkCore;
using N70_Entity.Api.Configurations;
using N70_Entity.Application.Common.Identity.Services;
using N70_Entity.Persistence.DataContexts;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();
await app.ConfigureAsync();

await app.RunAsync();