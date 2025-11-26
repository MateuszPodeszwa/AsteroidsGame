using System;
using System.Collections.Generic;
using AsteroidsGame.Engine.Input;

namespace AsteroidsGame;

public class Game
{
    // Define List of allowed keystrokes
    internal static readonly HashSet<ConsoleKey> AllowedKeys =
    [
        ConsoleKey.W,
        ConsoleKey.S,
        ConsoleKey.A,
        ConsoleKey.D,
        ConsoleKey.UpArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.Spacebar,
        ConsoleKey.Z,
        ConsoleKey.X,
        ConsoleKey.C,
        ConsoleKey.Escape,
        ConsoleKey.Enter
    ];
    

    internal Game()
    {
        
    }
}