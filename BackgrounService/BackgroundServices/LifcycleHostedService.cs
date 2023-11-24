using Microsoft.Extensions.Hosting;

namespace BackgrounService.BackgroundServices;
public class LifcycleHostedService : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle start");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle service started");
        return Task.CompletedTask;
    }

    public async Task StartingAsync(CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested)
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine($"LifecycleBackgroundService : {i}");
                }
                await Task.Delay(300);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle service stop");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle service stopped");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle service stopping");
        return Task.CompletedTask;
    }
}
