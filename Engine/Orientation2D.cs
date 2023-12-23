namespace Engine;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation2D(float radians)
{
    public const float MaxDegrees = 360;
    public const float MinDegrees = 0;

    public float Radians { get; } = radians;

    /// <summary>
    /// As opposed to radians, degrees can't express an angle outside 0 and 360.
    /// </summary>
    public float Degrees { get; } = ExtendedMath.Modulo((180 / (float)Math.PI) * radians, MaxDegrees);
    public bool Upperhalf { get; } = radians < Math.PI;
    public bool Lefthalf { get; } = radians > (Math.PI / 2) && radians < ((Math.PI / 2) * 3);
}
