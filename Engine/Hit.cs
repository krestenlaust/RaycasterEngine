namespace Engine;

/// <summary>
/// Represents information related to ray hitting a collider.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
/// <param name="origin">The origin of the ray.</param>
/// <param name="point">The point the ray hit the collider.</param>
/// <param name="distance">The distance the ray has travelled from <see cref="origin"/> to <see cref="point"/>.</param>
public readonly struct Hit<TPosition, TLength>(TPosition origin, TPosition point, TLength distance)
{
    /// <summary>
    /// The origin of the ray.
    /// </summary>
    public readonly TPosition Origin = origin;

    /// <summary>
    /// The point the ray hit the collider.
    /// </summary>
    public readonly TPosition Point = point;

    /// <summary>
    /// The distance the ray has travelled.
    /// </summary>
    public readonly TLength Distance = distance;
}
