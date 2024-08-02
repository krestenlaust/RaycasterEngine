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
