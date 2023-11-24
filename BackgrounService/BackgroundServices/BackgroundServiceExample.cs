using Microsoft.Extensions.Hosting;

namespace BackgrounService.BackgroundServices;

public class BackgroundServiceExample : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            for(int i = 0; i < 1_000_000; i++)
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine($"BackgroundService: {i}");
                }
                await Task.Delay(300);
            }
        }
    }
}
