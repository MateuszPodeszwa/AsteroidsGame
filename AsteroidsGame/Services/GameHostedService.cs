using System;
using System.Threading;
using System.Threading.Tasks;
using AsteroidsGame.Core;
using Microsoft.Extensions.Hosting;

namespace AsteroidsGame.Services;

public class GameHostedService(Game game) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await game.Run(stoppingToken);
                Console.WriteLine($"Game running at {DateTime.Now}");
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            Console.WriteLine($"Something went wrong, {ex.Message}");
        }
        finally
        {
            Console.WriteLine($"Game stopped at {DateTime.Now}");
            game.Stop();
        }
    }
}