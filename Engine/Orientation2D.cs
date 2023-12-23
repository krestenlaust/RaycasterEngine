namespace Engine;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation2D(float radians)
{
    public static readonly Orientation2D FullRotation = new Orientation2D(MathF.PI * 2);
    public static readonly Orientation2D NoRotation = new Orientation2D(0);

    public float Radians { get; } = radians;
    public Orientation2D Normalized { get => new Orientation2D(ExtendedMath.Modulo(Radians, FullRotation.Radians)); }

    public float Degrees { get => (180 / MathF.PI) * Radians; }

    public bool Upperhalf { get => Normalized.Radians < MathF.PI; }

    public bool Lefthalf { get => new Orientation2D(Radians - (FullRotation.Radians / 4)).Upperhalf; }

    public static Orientation2D FromDegrees(float degrees) =>
        new Orientation2D(degrees * (MathF.PI / 180));

    public Vector2D Vector { get => new Vector2D(MathF.Cos(Radians), MathF.Sin(Radians)); }
}
