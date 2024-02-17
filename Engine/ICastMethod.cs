namespace Engine;

/// <summary>
/// The algorithm to utilize for casting.
/// Typically (euclidian) straight line, but can be non-euclidian to for example represent a hyperbolic space.
/// </summary>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TAngle">The angular type to utilize, e.g. <see cref="MathTypes.Orientation2D"/> for basic euclidean orientational properties.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
public interface ICastMethod<TPosition, in TAngle, TLength>
{
    bool Cast(IHitMap<TPosition> map, TPosition origin, TAngle direction, TLength maxDistance, out Hit<TPosition, TLength>? hit);
}
