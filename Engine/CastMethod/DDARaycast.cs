namespace Engine.CastMethod;

/// <summary>
/// Euclidian casting method, cast a ray using Digital Differential Analyzer.
/// https://www.geeksforgeeks.org/dda-line-generation-algorithm-computer-graphics/
/// </summary>
/// <typeparam name="TRenderingUnit"></typeparam>
public class DDARaycast<TRenderingUnit> : ICastMethod<Vector2D, Orientation2D, float, TRenderingUnit>
{
    public (Vector2D, TRenderingUnit)? Cast(IMap<Vector2D, TRenderingUnit> map, Vector2D origin, Orientation2D direction, float maxDistance)
    {
        // Calculate offset to nearby grid.

        // Extrapolate position by grid unit, till something is hit.

        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the first hit along horizontal grid lines.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    /// <param name="maxDistance"></param>
    /// <returns></returns>
    Vector2D? CastHorizontal(Vector2D origin, Orientation2D direction, float maxDistance)
    {
        throw new NotImplementedException();
    }
}
