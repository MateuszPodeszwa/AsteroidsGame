// ReSharper disable UnusedParameter.Local

using System;
using Spectre.Console;

namespace AsteroidsGame;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Create the layout
        var layout = new Layout("Root").SplitRows(
            new Layout("Top"),
            new Layout("Bottom"));

        // Update the left column
        layout["Top"].Update(new Panel
            (
                Align.Left
                (
                    new Markup($"Score: 898" ), 
                    VerticalAlignment.Middle
                )).Expand()).Size(5);
        
        layout["Bottom"].Update(new Panel
        (
            Align.Center
            (
                new Markup("I(^)I"), 
                VerticalAlignment.Bottom
            )).Expand());

        // Render the layout
        AnsiConsole.Write(layout);
        Console.Out.Flush();
        Console.ReadLine();
    }
}