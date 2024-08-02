namespace Engine.MathTypes;

public readonly struct Vector3D(float x, float y, float z)
{
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
}
