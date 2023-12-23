namespace Engine;

public readonly struct Vector2D(float x, float y)
{
    public float X { get; } = x;
    public float Y { get; } = y;

    public float Length => MathF.Sqrt(X * X + Y * Y);

    public static Vector2D operator *(Vector2D vector, float factor) => new Vector2D(vector.X * factor, vector.Y * factor);

    public Vector2D Floor => new Vector2D(MathF.Floor(X), MathF.Floor(Y));
}
