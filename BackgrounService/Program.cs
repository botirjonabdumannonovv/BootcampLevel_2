using BackgrounService.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
{
    builder.Services
        .AddHostedService<BackgroundServiceHostedService>()
        .AddHostedService<LifcycleHostedService>()
        .AddHostedService<BackgroundServiceExample>();
}

IHost host = builder.Build();
host.Run();