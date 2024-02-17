﻿using Engine.MathTypes;

namespace Engine.CastMethod;

/// <summary>
/// Euclidian casting method, which simply takes a smal stepsize to look for hits.
/// </summary>
/// <param name="stepSize"></param>
public class DiscreteRaycast(float stepSize) : ICastMethod<Vector2D, Orientation2D, float>
{
    public float StepSize { get; set; } = stepSize;

    /// <inheritdoc/>
    public bool Cast(IHitMap<Vector2D> map, Vector2D origin, Orientation2D direction, float maxDistance, out Hit<Vector2D, float>? hit)
    {
        if (CastIncremental(map, origin, direction, maxDistance, StepSize, out Vector2D hitPoint, out float distance))
        {
            hit = new Hit<Vector2D, float>(origin, hitPoint, distance);
            return true;
        }
        else
        {
            hit = default;
            return false;
        }
    }

    static bool CastIncremental(IHitMap<Vector2D> map, Vector2D origin, Orientation2D direction, float maxDistance, float stepSize, out Vector2D hitPoint, out float distance)
    {
        hitPoint = default;
        distance = default;
        Vector2D directionVector = direction.Vector;

        for (float dist = 0; dist < maxDistance; dist += stepSize)
        {
            Vector2D point = (directionVector * dist) + origin;

            if (map.IsOutsideMap(point))
            {
                return false;
            }

            if (map.IsHit(point))
            {
                distance = dist;
                hitPoint = point;
                return true;
            }
        }

        return false;
    }
}
