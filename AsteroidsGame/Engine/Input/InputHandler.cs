// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
// ReSharper disable InconsistentNaming

using System;
using System.Collections.Generic;

namespace AsteroidsGame.Engine.Input;

/// <summary>
/// Handles console input validation for the Asteroids game engine.
/// Filters keystrokes against a whitelist of allowed keys and tracks the last valid input.
/// </summary>
/// <remarks>
/// This class provides centralized input validation to ensure only game-relevant keys are processed.
/// Invalid keystrokes are rejected, and the last valid key is preserved for reference.
/// </remarks>
internal sealed partial class InputHandler
{
    /// <summary>
    /// Gets the collection of console keys that are permitted for game input.
    /// </summary>
    /// <value>
    /// A hash set containing all allowed <see cref="ConsoleKey"/> values for the game.
    /// </value>
    internal HashSet<ConsoleKey> AllowedKeys { get; }
    
    /// <summary>
    /// Gets the most recently validated console key information, or <c>null</c> if no key has been validated yet.
    /// </summary>
    /// <value>
    /// <c>null</c> if no valid input has been captured; otherwise, the <see cref="ConsoleKeyInfo"/> 
    /// of the last successfully validated keystroke.
    /// </value>
    internal ConsoleKeyInfo? LastKey { get; private set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="InputHandler"/> class with the specified allowed keys.
    /// </summary>
    /// <param name="allowedKeys">
    /// A hash set of <see cref="ConsoleKey"/> values that the game engine will accept as valid input.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="allowedKeys"/> is <c>null</c>.
    /// </exception>
    /// <example>
    /// <code>
    /// var allowedKeys = new HashSet&lt;ConsoleKey&gt; 
    /// { 
    ///     ConsoleKey.W, 
    ///     ConsoleKey.A, 
    ///     ConsoleKey.S, 
    ///     ConsoleKey.D, 
    ///     ConsoleKey.Spacebar 
    /// };
    /// var inputHandler = new InputHandler(allowedKeys);
    /// </code>
    /// </example>
    internal InputHandler(HashSet<ConsoleKey> allowedKeys) 
        => AllowedKeys = allowedKeys ?? throw new ArgumentNullException(nameof(allowedKeys));
    
    /// <summary>
    /// Validates the provided console key input against the allowed keys and updates the last valid key.
    /// </summary>
    /// <param name="keyInfo">
    /// The <see cref="ConsoleKeyInfo"/> structure representing the keystroke to validate.
    /// </param>
    /// <returns>
    /// A <see cref="KeyPress"/> structure wrapping the validated input if the key is allowed; 
    /// otherwise, returns the last valid <see cref="ConsoleKeyInfo"/> wrapped in a <see cref="KeyPress"/>,
    /// or <c>default</c> if no valid key has been captured yet.
    /// </returns>
    /// <remarks>
    /// When an invalid key is provided, the method returns <see cref="LastKey"/> to maintain program continuity.
    /// Only keys present in <see cref="AllowedKeys"/> will update <see cref="LastKey"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// var keyInfo = Console.ReadKey();
    /// var validatedInput = inputHandler.Update(keyInfo);
    /// if (validatedInput.HasValue)
    /// {
    ///     // Process the validated keystroke
    ///     ProcessInput(validatedInput.Value.ConsoleKey);
    /// }
    /// </code>
    /// </example>
    internal KeyPress? Update(ConsoleKeyInfo keyInfo)
    {
        if (!AllowedKeys.Contains(keyInfo.Key))
            return LastKey ?? default(ConsoleKeyInfo); // Invalid key -> Return LastKey to ensure program continuity.
        
        LastKey = keyInfo;
        
        return new(keyInfo);
    }
}
