namespace Engine.MathTypes;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation2D(float radians)
{
    public static readonly Orientation2D FullRotation = new(MathF.PI * 2);
    public static readonly Orientation2D NoRotation = new(0);
    public static readonly Orientation2D UpRotation = new(MathF.PI / 2);
    public static readonly Orientation2D LeftRotation = new(MathF.PI);
    public static readonly Orientation2D DownRotation = new(MathF.PI * 2 - MathF.PI / 2);
    public static readonly Orientation2D RightRotation = new(0);

    public float Radians { get; } = radians;

    public static Orientation2D FromDegrees(float degrees) =>
        new(degrees * (MathF.PI / 180));

    public static Orientation2D operator /(Orientation2D orientation, float divisor) =>
        new(orientation.Radians / divisor);

    public static Orientation2D operator *(Orientation2D orientation, float factor) =>
        new(orientation.Radians * factor);

    public static Orientation2D operator +(Orientation2D orientation1, Orientation2D orientation2) =>
        new(orientation1.Radians + orientation2.Radians);

    public static Orientation2D operator -(Orientation2D orientation1, Orientation2D orientation2) =>
        new(orientation1.Radians - orientation2.Radians);

    public Orientation2D Normalized =>
        new(ExtendedMath.Modulo(Radians, FullRotation.Radians));

    public float Degrees =>
        180 / MathF.PI * Radians;

    public bool Upperhalf =>
        Normalized.Radians < MathF.PI;

    public bool Lefthalf =>
        new Orientation2D(Radians - FullRotation.Radians / 4).Upperhalf;

    public Vector2D Vector =>
        new(MathF.Cos(Radians), MathF.Sin(Radians));
}
