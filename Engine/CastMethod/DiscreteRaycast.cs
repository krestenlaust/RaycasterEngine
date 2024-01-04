namespace Engine.CastMethod;

/// <summary>
/// Euclidian casting method, which simply takes a smal stepsize to look for hits.
/// </summary>
/// <param name="stepSize"></param>
public class DiscreteRaycast<TRenderingUnit>(float stepSize) : ICastMethod<Vector2D, Orientation2D, float, TRenderingUnit>
{
    public float StepSize { get; set; } = stepSize;

    public bool Cast(IMap<Vector2D, TRenderingUnit> map, Vector2D origin, Orientation2D direction, float maxDistance, out Hit<Vector2D, float, TRenderingUnit>? hit)
    {
        if (CastIncremental(map, origin, direction, maxDistance, StepSize, out Vector2D hitPoint, out TRenderingUnit renderedUnit, out float distance))
        {
            hit = new Hit<Vector2D, float, TRenderingUnit>(origin, hitPoint, distance, renderedUnit);
            return true;
        }
        else
        {
            hit = default;
            return false;
        }
    }

    /// <summary>
    /// Casts using the basic incremental method.
    /// </summary>
    /// <returns></returns>
    public static bool CastIncremental(IMap<Vector2D, TRenderingUnit> map, Vector2D origin, Orientation2D direction, float maxDistance, float stepSize, out Vector2D hitPoint, out TRenderingUnit renderedUnit, out float distance)
    {
        hitPoint = default;
        renderedUnit = default;
        distance = default;
        Vector2D directionVector = direction.Vector;

        for (float dist = 0; dist < maxDistance; dist += stepSize)
        {
            Vector2D hit = directionVector * dist + origin;
            Vector2D hitCell = hit.Floor;

            if (map.IsOutsideMap(hitCell))
            {
                return false;
            }

            if (map.IsHit(hitCell, out TRenderingUnit unit))
            {
                distance = dist;
                hitPoint = hit;
                renderedUnit = unit;
                return true;
            }
        }

        return false;
    }
}
