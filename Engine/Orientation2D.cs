namespace Engine;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation2D(float radians)
{
    public const float MaxDegrees = 360;
    public const float MinDegrees = 0;
    public static readonly Orientation2D FullRotation = new Orientation2D((float)Math.PI * 2);
    public static readonly Orientation2D NoRotation = new Orientation2D(0);

    public float Radians { get; } = radians;
    public float NormalizedRadians { get; } = ExtendedMath.Modulo(radians, FullRotation.Radians);

    /// <summary>
    /// As opposed to radians, degrees can't express an angle outside 0 and 360.
    /// </summary>
    public float Degrees { get; } = ExtendedMath.Modulo((180 / (float)Math.PI) * radians, MaxDegrees);
    public bool Upperhalf { get; } = ExtendedMath.Modulo(radians, FullRotation.Radians) < Math.PI;
    public bool Lefthalf { get; } = ExtendedMath.Modulo(radians, FullRotation.Radians) > (Math.PI / 2) &&
        ExtendedMath.Modulo(radians, FullRotation.Radians) < ((Math.PI / 2) * 3);

    public static Orientation2D FromDegrees(float degrees) =>
        new Orientation2D(degrees * ((float)Math.PI / 180));
}
