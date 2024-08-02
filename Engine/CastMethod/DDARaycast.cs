using Engine.MathTypes;

namespace Engine.CastMethod;

/// <summary>
/// Euclidian casting method, cast a ray using Digital Differential Analyzer.
/// Reference: https://www.geeksforgeeks.org/dda-line-generation-algorithm-computer-graphics/.
/// </summary>
/// <typeparam name="TRenderingUnit"></typeparam>
public class DDARaycast : ICastMethod<Vector2D, Angle, float>
{
    /// <inheritdoc/>
    public bool Cast(IHitSpace<Vector2D> space, Vector2D origin, Angle direction, float maxDistance, out Hit<Vector2D, float>? hit)
    {
        // Calculate offset to nearby grid.
        // Extrapolate position by grid unit, till something is hit.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the first hit along horizontal grid lines.
    /// </summary>
    Vector2D? CastHorizontal(Vector2D origin, Angle direction, float maxDistance)
    {
        throw new NotImplementedException();
    }
}
