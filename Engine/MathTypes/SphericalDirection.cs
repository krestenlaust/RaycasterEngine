namespace Engine.MathTypes;

/// <summary>
/// A kind of orientation-type.
/// Direction described using two angles in a sphere, called polar and azimuthal.
/// </summary>
public readonly struct SphericalDirection(Angle azimuthal, Angle polar)
{
    /// <summary>
    /// Gets the azimuthal angle in the spherical direction.
    /// Also referred to as roll.
    /// </summary>
    public Angle Azimuth { get; } = azimuthal;

    /// <summary>
    /// Gets the polar angle in the spherical direction.
    /// Also referred to as pitch / tilt.
    /// </summary>
    public Angle Inclination { get; } = polar;

    /// <summary>
    /// Gets the cartesian directional unit-vector.
    /// </summary>
    public Vector3D Vector => new (
        MathF.Sin(Azimuth.Radians) * MathF.Cos(Inclination.Radians),
        MathF.Cos(Azimuth.Radians) * MathF.Cos(Inclination.Radians),
        MathF.Sin(Inclination.Radians));
}
