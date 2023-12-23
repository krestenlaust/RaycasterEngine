namespace Engine;

public class Map2D
{
    public Vector2D Cast(Vector2D origin, Orientation2D direction, float maxDistance)
    {
        // Calculate offset to nearby grid.

        // Extrapolate position by grid unit, till something is hit.

        throw new NotImplementedException();
    }

    /// <summary>
    /// Casts using the basic incremental method.
    /// TODO: Make each casting method have its own class via a interface.
    /// This would make it easier to change raycast method to a non-euclidian method in the future.
    /// </summary>
    /// <returns></returns>
    public Vector2D CastIncremental(Vector2D origin, Orientation2D direction, float maxDistance, float stepSize)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the first hit along horizontal grid lines.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    /// <param name="maxDistance"></param>
    /// <returns></returns>
    Vector2D CastHorizontal(Vector2D origin, Orientation2D direction, float maxDistance)
    {
        throw new NotImplementedException();
    }
}
