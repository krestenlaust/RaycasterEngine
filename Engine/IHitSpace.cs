namespace Engine;

/// <summary>
/// Represents a space containing colliders.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for a standard cartesian 2D-space.</typeparam>
public interface IHitSpace<in TPosition>
{
    /// <summary>
    /// Returns whether the point is outside the allocated space.
    /// </summary>
    /// <param name="position">The point to check.</param>
    /// <returns>Whether the point is outside the space.</returns>
    bool IsOutsideSpace(TPosition position);

    /// <summary>
    /// Returns whether the point is inside a collider.
    /// </summary>
    /// <param name="position">The point to check.</param>
    /// <returns>Whether the point is inside a collider.</returns>
    bool IsHit(TPosition position);
}
