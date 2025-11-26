using System;

namespace AsteroidsGame.Engine.Input;

internal sealed partial class InputHandler
{
    /// <summary>
    /// Represents a validated keystroke that has passed input validation checks.
    /// </summary>
    /// <remarks>
    /// This readonly record struct wraps <see cref="ConsoleKeyInfo"/> to distinguish 
    /// validated input from raw console input, providing type safety for game input processing.
    /// </remarks>
    /// <param name="ConsoleKeyInfo">
    /// The underlying console key information for the validated keystroke.
    /// </param>
    public readonly record struct KeyPress(ConsoleKeyInfo ConsoleKeyInfo)
    {
        /// <summary>
        /// Implicitly converts a <see cref="ConsoleKeyInfo"/> to a <see cref="KeyPress"/>.
        /// </summary>
        /// <param name="keyInfo">The console key information to convert.</param>
        /// <returns>A new <see cref="KeyPress"/> instance wrapping the provided key information.</returns>
        public static implicit operator KeyPress(ConsoleKeyInfo keyInfo) => new(keyInfo);
        
        /// <summary>
        /// Gets the specific console key that was pressed, extracted from the underlying <see cref="ConsoleKeyInfo"/>.
        /// </summary>
        /// <value>
        /// The <see cref="ConsoleKey"/> enumeration value representing the pressed key.
        /// </value>
        public readonly ConsoleKey ConsoleKey => ConsoleKeyInfo.Key;
    }
}