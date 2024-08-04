namespace Engine.MathTypes;

/// <summary>
/// A spacial-type that typically represents a cartesian coordinate system.
/// </summary>
/// <typeparam name="T">The recurring Vector-type (self-type).</typeparam>
public interface IVector<T>
    where T : struct
{
    /// <summary>
    /// Gets the magnitude of the vector.
    /// </summary>
    float Length { get; }

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Floor(float)"/>.
    /// </summary>
    T Floor { get; }

    /// <summary>
    /// Gets the vector components as integers, according to <see cref="MathF.Round(float)"/>.
    /// </summary>
    T Round { get; }

    /// <summary>
    /// Gets a normalized version.
    /// </summary>
    T Normalized { get; }
}
