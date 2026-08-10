using AsteroidsGame.Engine.Rendering;

namespace AsteroidsGame.Core;

/// <summary>
/// The game itself. Everything it needs arrives through the constructor.
/// </summary>
public sealed class Game(IRenderer renderer)
{
    public void Run() => renderer.Draw("Hello World");
}
