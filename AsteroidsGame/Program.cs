using System.Threading.Tasks;
using AsteroidsGame.Core;
using AsteroidsGame.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsteroidsGame;

internal static class Program
{
    private static async Task Main(string[] args) //
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        
        builder.Services.AddHostedService<GameHostedService>();
        builder.Services.AddSingleton<Game>();
        
        IHost app = builder.Build();
        await app.RunAsync();
    }
}