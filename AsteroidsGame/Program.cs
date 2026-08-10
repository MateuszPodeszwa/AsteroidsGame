using AsteroidsGame.Core;
using AsteroidsGame.Engine.Rendering;

namespace AsteroidsGame;

internal static class Program
{
    private static void Main()
    {
        // Composition root: dependencies are constructed here and passed down by hand.
        IRenderer renderer = new ConsoleRenderer();
        Game game = new(renderer);

        game.Run();
    }
}
