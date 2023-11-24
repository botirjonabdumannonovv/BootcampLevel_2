using Microsoft.Extensions.Hosting;

namespace BackgrounService.BackgroundServices;
public class BackgroundServiceHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("my BackgroundService start");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("my BackgroundService stop");
        return Task.CompletedTask;
    }
}
