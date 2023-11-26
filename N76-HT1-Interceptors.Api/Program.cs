using N76_HT1_Interceptors.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();
await app.RunAsync();