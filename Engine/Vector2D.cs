﻿namespace Engine;

public readonly struct Vector2D(float x, float y)
{
    public float X { get; } = x;
    public float Y { get; } = y;

    public float Length =>
        MathF.Sqrt(X * X + Y * Y);

    public static Vector2D operator *(Vector2D vector, float factor) =>
        new(vector.X * factor, vector.Y * factor);

    public static Vector2D operator /(Vector2D vector, float divisor) =>
        new(vector.X / divisor, vector.Y / divisor);

    public static Vector2D operator +(Vector2D vector1, Vector2D vector2) =>
        new(vector1.X + vector2.X, vector1.Y + vector2.Y);

    public Vector2D Floor =>
        new(MathF.Floor(X), MathF.Floor(Y));

    public Vector2D Normalized =>
        this / Length;
}
