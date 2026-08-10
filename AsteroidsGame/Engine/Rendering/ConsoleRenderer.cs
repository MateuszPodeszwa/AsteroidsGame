using System;

namespace AsteroidsGame.Engine.Rendering;

/// <summary>
/// Draws to the system console.
/// </summary>
public sealed class ConsoleRenderer : IRenderer
{
    public void Draw(string text) => Console.WriteLine(text);
}
