using System.Reflection;

using Drives.Application.Common.Brokers;
using Drives.Infrastructure.FileStorage.Brokers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSingleton<IDriveBroker, DriveBroker>();

var assemblies = Assembly
    .GetExecutingAssembly() // hozirgi run qilingan assemblyni olish
    .GetReferencedAssemblies() // bu shu projectga reference qilingan assemblylarni olish
    .Select(Assembly.Load)
    .ToList();

assemblies.Add(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(assemblies);


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.MapControllers();

app.Run();
