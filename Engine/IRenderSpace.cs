namespace Engine;

/// <summary>
/// Represents a space of <see cref="TRenderingUnit"/>-instances for projection.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TRenderingUnit">The unit to represent what a raycaster sees.</typeparam>
public interface IRenderSpace<in TPosition, TRenderingUnit> : IHitSpace<TPosition>
{
    /// <summary>
    /// Renders a particular point in space.
    /// </summary>
    /// <param name="position">The point in space to render.</param>
    /// <param name="renderedUnit">The render result.</param>
    /// <returns>Whether there was something to render.</returns>
    bool Render(TPosition position, out TRenderingUnit renderedUnit);
}
