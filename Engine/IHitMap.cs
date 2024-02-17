namespace Engine;

/// <summary>
/// Represents a collision map.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for a standard cartesian 2D-map.</typeparam>
public interface IHitMap<in TPosition>
{
    /// <summary>
    /// Returns whether the point is outside the allocated map.
    /// </summary>
    /// <param name="position">The point to check.</param>
    /// <returns>Whether the point is outside the map.</returns>
    bool IsOutsideMap(TPosition position);

    /// <summary>
    /// Returns whether the point is inside a collider.
    /// </summary>
    /// <param name="position">The point to check.</param>
    /// <returns>Whether the point is inside a collider.</returns>
    bool IsHit(TPosition position);
}
