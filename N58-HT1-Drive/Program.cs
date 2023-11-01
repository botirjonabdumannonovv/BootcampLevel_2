var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CentralPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("CentralPolicy");

app.MapControllers();

await app.RunAsync();