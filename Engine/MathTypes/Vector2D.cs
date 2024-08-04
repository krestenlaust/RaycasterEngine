using System.Globalization;

namespace Engine.MathTypes;

/// <summary>
/// A spacial type that represents standard 2D cartesian coordinates.
/// </summary>
/// <param name="x">The horizontal component of the vector-type.</param>
/// <param name="y">The vertical component of the vector-type.</param>
public readonly struct Vector2D(float x, float y) : IEquatable<Vector2D>, IVector<Vector2D>
{
    static readonly int GridTolerance = 3;

    /// <summary>
    /// Gets the horizontal component of the vector-type.
    /// </summary>
    public float X { get; } = x;

    /// <summary>
    /// Gets the vertical component of the vector-type.
    /// </summary>
    public float Y { get; } = y;

    /// <summary>
    /// Gets the magnitude of the vector.
    /// </summary>
    public float Length =>
        MathF.Sqrt((X * X) + (Y * Y));

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Floor(float)"/>.
    /// </summary>
    public Vector2D Floor =>
        new (MathF.Floor(X), MathF.Floor(Y));

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Round(float)"/>.
    /// </summary>
    public Vector2D Round =>
        new (MathF.Round(X), MathF.Round(Y));

    /// <summary>
    /// Gets a normalized version.
    /// </summary>
    public Vector2D Normalized =>
        this / Length;

    public static Vector2D operator *(Vector2D vector, float factor) =>
        new (vector.X * factor, vector.Y * factor);

    public static Vector2D operator /(Vector2D vector, float divisor) =>
        new (vector.X / divisor, vector.Y / divisor);

    public static Vector2D operator +(Vector2D vector1, Vector2D vector2) =>
        new (vector1.X + vector2.X, vector1.Y + vector2.Y);

    public static Vector2D operator -(Vector2D vector1, Vector2D vector2) =>
        new (vector1.X - vector2.X, vector1.Y - vector2.Y);

    public static bool operator ==(Vector2D vector1, Vector2D vector2) =>
        vector1.X == vector2.X && vector1.Y == vector2.Y;

    public static bool operator !=(Vector2D vector1, Vector2D vector2) =>
        vector1.X != vector2.X || vector1.Y != vector2.Y;

    /// <inheritdoc/>
    public override string ToString()
    {
        CultureInfo info = CultureInfo.InvariantCulture;
        return $"({X.ToString(info)}, {Y.ToString(info)})";
    }

    /// <summary>
    /// Accounts for floating-point errors, and floors the position to a cartesian cell.
    /// </summary>
    /// <param name="roundingToleranceDigits">The amount of digits of significance to round according to.</param>
    /// <returns>Returns the integer Vector2D coordinates.</returns>
    public Vector2D GetCartesianCell(int roundingToleranceDigits) =>
        new (
            MathF.Floor(MathF.Round(X, roundingToleranceDigits)),
            MathF.Floor(MathF.Round(Y, roundingToleranceDigits))
            );

    /// <summary>
    /// Accounts for floating-point errors rounding down to 3 significant digits, and floors the position to a cartesian whole cell.
    /// </summary>
    /// <returns>Returns the integer Vector2D coordinates.</returns>
    public Vector2D GetCartesianCell() => GetCartesianCell(GridTolerance);

    /// <inheritdoc/>
    public bool Equals(Vector2D other) => this == other;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector2D vector && Equals(vector);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y);
}
