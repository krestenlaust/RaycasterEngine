namespace Engine.CastMethod;

public class CleverRaycast : ICast<Vector2D, Orientation2D, float>
{
    public Vector2D? Cast(IMap<Vector2D> map, Vector2D origin, Orientation2D direction, float maxDistance)
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
