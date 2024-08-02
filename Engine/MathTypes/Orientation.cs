namespace Engine.MathTypes;

/// <summary>
/// Orientation based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Orientation(float radians)
{
    public static readonly Orientation FullRotation = new (MathF.PI * 2);
    public static readonly Orientation IdentityRotation = new (0);
    public static readonly Orientation UpRotation = new (MathF.PI / 2);
    public static readonly Orientation LeftRotation = new (MathF.PI);
    public static readonly Orientation DownRotation = new ((MathF.PI * 2) - (MathF.PI / 2));
    public static readonly Orientation RightRotation = new (0);

    /// <summary>
    /// Gets the radians measure.
    /// </summary>
    public float Radians { get; } = radians;

    /// <summary>
    /// Gets a normalized instance of the orientation (only a single revolution).
    /// </summary>
    public Orientation Normalized =>
        new (ExtendedMath.Modulo(Radians, FullRotation.Radians));

    /// <summary>
    /// Gets the angle orientation converted to an angle in degrees.
    /// NOTE: Does not treat values above 360 or below 0 differently.
    /// </summary>
    public float Degrees =>
        180 / MathF.PI * Radians;

    /// <summary>
    /// Gets a value indicating whether the angle is in the upper semi-circle of a circle.
    /// </summary>
    public bool Upperhalf =>
        Normalized.Radians < MathF.PI;

    /// <summary>
    /// Gets a value indicating whether the angle is in the lower semi-circle of a circle.
    /// </summary>
    public bool Lefthalf =>
        new Orientation(Radians - (FullRotation.Radians / 4)).Upperhalf;

    /// <summary>
    /// Gets the cartesian directional unit-vector.
    /// </summary>
    public Vector2D Vector =>
        new (MathF.Cos(Radians), MathF.Sin(Radians));

    public static Orientation operator /(Orientation orientation, float divisor) =>
        new (orientation.Radians / divisor);

    public static Orientation operator *(Orientation orientation, float factor) =>
        new (orientation.Radians * factor);

    public static Orientation operator +(Orientation orientation1, Orientation orientation2) =>
        new (orientation1.Radians + orientation2.Radians);

    public static Orientation operator -(Orientation orientation1, Orientation orientation2) =>
        new (orientation1.Radians - orientation2.Radians);

    /// <summary>
    /// Instantiates an <see cref="Orientation"/> based on angular degrees.
    /// NOTE: Does not treat values above 360 or below 0 differently.
    /// </summary>
    /// <param name="degrees">The angular degree measure.</param>
    /// <returns>The newly instantiated orientation-object.</returns>
    public static Orientation FromDegrees(float degrees) =>
        new (degrees * (MathF.PI / 180));
}
