namespace Engine.MathTypes;

/// <summary>
/// A kind of orientation-type.
/// Direction described using two angles in a sphere, called polar and azimuthal.
/// </summary>
public readonly struct SphericalDirection(Angle azimuthal, Angle polar) : IEquatable<SphericalDirection>
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
    /// It follows the RIGHT-UP-TOWARDS VIEWER - orientation.
    /// </summary>
    public Vector3D Vector => new (
        MathF.Cos(Azimuth.Radians) * MathF.Sin(Inclination.Radians),
        MathF.Sin(Azimuth.Radians) * MathF.Sin(Inclination.Radians),
        MathF.Cos(Inclination.Radians));

    public static bool operator ==(SphericalDirection left, SphericalDirection right) => left.Equals(right);

    public static bool operator !=(SphericalDirection left, SphericalDirection right) => !(left == right);

    /// <summary>
    /// Converts a vector (unit or otherwise) into the spherical direction representation.
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static SphericalDirection FromVector(Vector3D vector) => throw new NotImplementedException();

    /// <inheritdoc/>
    public bool Equals(SphericalDirection other) => Azimuth.Equals(other.Azimuth) && Inclination.Equals(other.Inclination);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SphericalDirection direction && Equals(direction);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Azimuth, Inclination);
}
