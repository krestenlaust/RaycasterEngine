namespace Engine;

/// <summary>
/// Represents a particular pattern for the camera to cast in, analogous to real-world camera lenses.
/// It decides the particular angles at which to cast rays, and the sample size as well.
/// Properties like Field of View (FOV) are described in an implementation of this interface, if the pattern is perspective-based.
/// </summary>
/// <typeparam name="TCastMethod">The casting method to utilize, e.g. <see cref="CastMethod.DiscreteRaycast"/> for standard euclidean iterative line casting.</typeparam>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TAngle">The angular type to utilize, e.g. <see cref="MathTypes.Orientation2D"/> for basic euclidean orientational properties.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
public interface ICameraPattern<TCastMethod, TPosition, in TAngle, TLength>
    where TCastMethod : ICastMethod<TPosition, TAngle, TLength>
{
    /// <summary>
    /// Renders the scene using the provided cast method.
    /// </summary>
    /// <param name="space">The space to render.</param>
    /// <param name="caster">The method to utilize in rendering.</param>
    /// <param name="origin">The origin of perspective of the rendering.</param>
    /// <param name="orientation">The absolute orientation of the perspective.</param>
    /// <param name="renderDistance">The constraint of distance of the render.</param>
    /// <returns>Every cast ray, each None if hits nothing, Some if hits. Some provides information about hit.</returns>
    IEnumerable<Hit<TPosition, TLength>?> Render(IHitSpace<TPosition> space, TCastMethod caster, TPosition origin, TAngle orientation, TLength renderDistance);
}
