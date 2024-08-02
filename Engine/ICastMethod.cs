namespace Engine;

/// <summary>
/// The algorithm to utilize for casting.
/// Typically (euclidian) straight line, but can be non-euclidian to for example represent a hyperbolic space.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TOrientation">The angular type to utilize, e.g. <see cref="MathTypes.Angle"/> for basic euclidean orientational properties.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
public interface ICastMethod<TPosition, in TOrientation, TLength>
{
    bool Cast(IHitSpace<TPosition> space, TPosition origin, TOrientation direction, TLength maxDistance, out Hit<TPosition, TLength>? hit);
}
