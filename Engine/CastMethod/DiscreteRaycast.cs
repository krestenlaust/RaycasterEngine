﻿namespace Engine.CastMethod;

/// <summary>
/// Euclidian casting method, which simply takes a smal stepsize to look for hits.
/// </summary>
/// <param name="stepSize"></param>
public class DiscreteRaycast<TRenderingUnit>(float stepSize) : ICast<Vector2D, Orientation2D, float, TRenderingUnit>
{
    public float StepSize { get; set; } = stepSize;

    public (Vector2D, TRenderingUnit)? Cast(IMap<Vector2D, TRenderingUnit> map, Vector2D origin, Orientation2D direction, float maxDistance) =>
        CastIncremental(map, origin, direction, maxDistance, StepSize);

    /// <summary>
    /// Casts using the basic incremental method.
    /// </summary>
    /// <returns></returns>
    public static (Vector2D, TRenderingUnit)? CastIncremental(IMap<Vector2D, TRenderingUnit> map, Vector2D origin, Orientation2D direction, float maxDistance, float stepSize)
    {
        Vector2D directionVector = direction.Vector;

        for (float dist = 0; dist < maxDistance; dist += stepSize)
        {
            Vector2D hit = directionVector * dist + origin;
            Vector2D hitCell = hit.Floor;

            if (map.IsOutsideMap(hitCell))
            {
                return null;
            }

            if (map.IsHit(hitCell, out TRenderingUnit unit))
            {
                return (hit, unit);
            }
        }

        return null;
    }
}
