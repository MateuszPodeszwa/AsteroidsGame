// ReSharper disable CheckNamespace
using System;

namespace AsteroidsGame;

/// <summary>
/// Represents an immutable point in a two-dimensional plane with integer coordinates.
/// </summary>
/// <remarks>
/// <para>
/// This type is a <c>readonly record struct</c>, ensuring value semantics and immutability. 
/// It is designed for 2D spatial logic and supports standard vector arithmetic.
/// </para>
/// <para>
/// <strong>Initialization:</strong>
/// You can initialize a point via the constructor, or use implicit operators for cleaner syntax:
/// <list type="bullet">
///     <item><c>Point p = (10, 20);</c> (Tuple conversion)</item>
///     <item><c>Point p = 5;</c> (Uniform scalar conversion to 5,5)</item>
/// </list>
/// </para>
/// </remarks>
/// <example>
/// <code>
/// Point p1 = (10, 20);        // Implicit tuple conversion
/// Point p2 = p1 + (5, 5);     // Vector addition: Result (15, 25)
/// Point p3 = p1 * 2;          // Scalar multiplication: Result (20, 40)
/// 
/// // Non-destructive mutation
/// Point p4 = p1 with { X = 100 }; 
/// </code>
/// </example>
/// <param name="X">The horizontal coordinate.</param>
/// <param name="Y">The vertical coordinate.</param>
public readonly record struct Point(int X, int Y)
{
    /// <summary>
    /// Implicitly converts a single integer into a Point where both X and Y equal the value.
    /// </summary>
    public static implicit operator Point(int value) => new(value, value);

    /// <summary>
    /// Implicitly converts a ValueTuple (x, y) into a Point.
    /// </summary>
    public static implicit operator Point((int x, int y) xy) => new(xy.x, xy.y);
    
    #region Vector Math Operators
    
    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
    public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);
    public static Point operator *(Point p, int scale) => new(p.X * scale, p.Y * scale);
    public static Point operator /(Point p, int divisor) => new(p.X / divisor, p.Y / divisor);
    
    #endregion
    
    // --- Utility Methods ---

    #region Utility Methods
    
    /// <summary>
    /// Calculates the Euclidean distance to another point.
    /// </summary>
    /// <remarks>
    /// This method uses a square root operation ($d = \sqrt{(x_2 - x_1)^2 + (y_2 - y_1)^2}$). 
    /// If you only need to compare distances (e.g., checking collision radii), use <see cref="DistanceSquared"/> instead to avoid the performance cost of <c>Math.Sqrt</c>.
    /// </remarks>
    /// <param name="other">The target point.</param>
    /// <returns>The precise distance as a double.</returns>
    public double DistanceTo(Point other)
    {
        return Math.Sqrt(DistanceSquared(other));
    }

    /// <summary>
    /// Calculates the squared distance to another point.
    /// </summary>
    /// <remarks>
    /// This is significantly faster than <see cref="DistanceTo"/> because it avoids the expensive Square Root operation. 
    /// Useful for optimized collision detection.
    /// </remarks>
    /// <param name="other">The target point.</param>
    /// <returns>The squared distance as an integer ($dx^2 + dy^2$).</returns>
    public int DistanceSquared(Point other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        return (dx * dx) + (dy * dy);
    }
    
    #endregion
    
    public override string ToString() => $"({X}, {Y})";
}