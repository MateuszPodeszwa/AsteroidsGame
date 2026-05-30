using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsteroidsGame.Core;

public sealed class Game
{
    public async Task Run(CancellationToken stoppingToken)
    {
        await Task.Delay(50, stoppingToken);
        Console.WriteLine("Game is running...");
    }
    
    public void Stop()
    {
        Console.WriteLine("Game Stopped.");
    }
}