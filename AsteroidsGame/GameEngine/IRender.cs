namespace AsteroidsGame.GameEngine;

// Defines functions for any objects that wants to be rendered on the screen
public interface IRender
{
    Point Location { get; }
    int Velocity { get; }
}