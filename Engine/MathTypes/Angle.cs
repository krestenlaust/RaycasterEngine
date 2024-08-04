namespace Engine.MathTypes;

/// <summary>
/// Angle based around the positive first-axis, going counterclockwise.
/// </summary>
/// <param name="radians"></param>
public readonly struct Angle(float radians) : IEquatable<Angle>
{
    public static readonly Angle FullRotation = new (MathF.PI * 2);
    public static readonly Angle IdentityRotation = new (0);
    public static readonly Angle UpRotation = new (MathF.PI / 2);
    public static readonly Angle LeftRotation = new (MathF.PI);
    public static readonly Angle DownRotation = new ((MathF.PI * 2) - (MathF.PI / 2));
    public static readonly Angle RightRotation = new (0);

    /// <summary>
    /// Gets the radians measure.
    /// </summary>
    public float Radians { get; } = radians;

    /// <summary>
    /// Gets a normalized instance of the orientation (only a single revolution).
    /// </summary>
    public Angle Normalized =>
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
        new Angle(Radians - (FullRotation.Radians / 4)).Upperhalf;

    /// <summary>
    /// Gets the cartesian directional unit-vector.
    /// </summary>
    public Vector2D Vector =>
        new (MathF.Cos(Radians), MathF.Sin(Radians));

    public static Angle operator /(Angle orientation, float divisor) =>
        new (orientation.Radians / divisor);

    public static Angle operator *(Angle orientation, float factor) =>
        new (orientation.Radians * factor);

    public static Angle operator +(Angle orientation1, Angle orientation2) =>
        new (orientation1.Radians + orientation2.Radians);

    public static Angle operator -(Angle orientation1, Angle orientation2) =>
        new (orientation1.Radians - orientation2.Radians);

    public static bool operator ==(Angle left, Angle right) => left.Equals(right);

    public static bool operator !=(Angle left, Angle right) => !(left == right);

    /// <summary>
    /// Instantiates an <see cref="Angle"/> based on angular degrees.
    /// NOTE: Does not treat values above 360 or below 0 differently.
    /// </summary>
    /// <param name="degrees">The angular degree measure.</param>
    /// <returns>The newly instantiated orientation-object.</returns>
    public static Angle FromDegrees(float degrees) =>
        new (degrees * (MathF.PI / 180));

    /// <inheritdoc/>
    public bool Equals(Angle other) => Radians.Equals(other.Radians);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Angle angle && Equals(angle);

    /// <inheritdoc/>
    public override int GetHashCode() => Radians.GetHashCode();
}
