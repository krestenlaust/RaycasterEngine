using System.Globalization;

namespace Engine.MathTypes;

/// <summary>
/// TODO: Decide conventions for 3D axis.
/// A spacial type that represents standard 3D cartesian coordinates.
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <param name="z"></param>
public readonly struct Vector3D(float x, float y, float z) : IEquatable<Vector3D>, IVector<Vector3D>
{
    static readonly int GridTolerance = 3;

    /// <summary>
    /// Gets the ??? component of the vector-type.
    /// </summary>
    public float X { get; } = x;

    /// <summary>
    /// Gets the ??? component of the vector-type.
    /// </summary>
    public float Y { get; } = y;

    /// <summary>
    /// Gets the ??? component of the vector-type.
    /// </summary>
    public float Z { get; } = z;

    /// <summary>
    /// Gets the magnitude of the vector.
    /// </summary>
    public float Length =>
        MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Floor(float)"/>.
    /// </summary>
    public Vector3D Floor =>
        new (MathF.Floor(X), MathF.Floor(Y), MathF.Floor(Z));

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Round(float)"/>.
    /// </summary>
    public Vector3D Round =>
        new (MathF.Round(X), MathF.Round(Y), MathF.Round(Z));

    /// <summary>
    /// Gets a normalized version.
    /// </summary>
    public Vector3D Normalized =>
        this / Length;

    public static Vector3D operator *(Vector3D vector, float factor) =>
    new (vector.X * factor, vector.Y * factor, vector.Z * factor);

    public static Vector3D operator /(Vector3D vector, float divisor) =>
        new (vector.X / divisor, vector.Y / divisor, vector.Z / divisor);

    public static Vector3D operator +(Vector3D vector1, Vector3D vector2) =>
        new (vector1.X + vector2.X,
            vector1.Y + vector2.Y,
            vector1.Z + vector2.Z);

    public static Vector3D operator -(Vector3D vector1, Vector3D vector2) =>
        new (vector1.X - vector2.X,
            vector1.Y - vector2.Y,
            vector1.Z - vector2.Z);

    public static bool operator ==(Vector3D vector1, Vector3D vector2) =>
        vector1.X == vector2.X &&
        vector1.Y == vector2.Y &&
        vector1.Z == vector2.Z;

    public static bool operator !=(Vector3D vector1, Vector3D vector2) =>
        vector1.X != vector2.X ||
        vector1.Y != vector2.Y ||
        vector1.Z != vector2.Z;

    /// <inheritdoc/>
    public override string ToString()
    {
        CultureInfo info = CultureInfo.InvariantCulture;
        return $"({X.ToString(info)}, {Y.ToString(info)}, {Z.ToString(info)})";
    }

    /// <summary>
    /// Accounts for floating-point errors, and floors the position to a cartesian cube.
    /// </summary>
    /// <param name="roundingToleranceDigits">The amount of digits of significance to round according to.</param>
    /// <returns>Returns the integer 3D-vector coordinates.</returns>
    public Vector3D GetCartesianCube(int roundingToleranceDigits) =>
        new(
            MathF.Floor(MathF.Round(X, roundingToleranceDigits)),
            MathF.Floor(MathF.Round(Y, roundingToleranceDigits)),
            MathF.Floor(MathF.Round(Z, roundingToleranceDigits))
            );

    /// <summary>
    /// Accounts for floating-point errors rounding down to 3 significant digits, and floors the position to a cartesian whole cube.
    /// </summary>
    /// <returns>Returns the integer 3D-vector coordinates.</returns>
    public Vector3D GetCartesianCube() => GetCartesianCube(GridTolerance);

    /// <inheritdoc/>
    public bool Equals(Vector3D other) => this == other;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Vector3D vector && Equals(vector);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
}
