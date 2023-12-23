namespace Engine;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation2D(float radians)
{
    public float Radians { get; } = radians;
    public float Degrees { get; } = (180 / (float)Math.PI) * radians;
    public bool Upperhalf { get; } = radians < Math.PI;
    public bool Lefthalf { get; } = radians > (Math.PI / 2) && radians < ((Math.PI / 2) * 3);
}
