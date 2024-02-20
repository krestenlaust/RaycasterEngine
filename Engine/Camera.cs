using Engine;
using Engine.MathTypes;

namespace EngineImpl;

/// <summary>
/// This entity utilizes a <see cref="ICameraPattern{TCastMethod, TPosition, TAngle, TLength}"/>,
/// to project a <see cref="IRenderSpace{TPosition, TRenderingUnit}"/> into another space.
/// </summary>
/// <typeparam name="TCastMethod">The casting method to utilize, e.g. <see cref="CastMethod.DiscreteRaycast"/> for standard euclidean iterative line casting.</typeparam>
/// <typeparam name="TCameraPattern">The camera casting pattern to utilize, describes the way the camera casts its rays. E.g. <see cref="CameraPattern.CartesianPlaneToCartesianLineCamera{TCastMethod, TPosition, TLength}"/> to cast into 1D.</typeparam>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TAngle">The angular type to utilize, e.g. <see cref="MathTypes.Orientation2D"/> for basic euclidean orientational properties.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
/// <typeparam name="TRenderingUnit">The unit to represent what a raycaster sees.</typeparam>
/// <param name="cameraPattern">The provided camera pattern for the camera to utilize.</param>
/// <param name="castMethod">The provided casting method for the camera to utilize.</param>
public class Camera<TCastMethod, TCameraPattern, TPosition, TAngle, TLength, TRenderingUnit>(TCameraPattern cameraPattern, TCastMethod castMethod, TLength renderDistance)
    where TCastMethod : ICastMethod<TPosition, TAngle, TLength>
    where TCameraPattern : ICameraPattern<TCastMethod, TPosition, TAngle, TLength>
    where TPosition : struct
    where TAngle : struct
{
    /// <summary>
    /// Gets or sets the camera pattern for the camera to utilize.
    /// </summary>
    public TCameraPattern CameraPattern { get; set; } = cameraPattern;

    /// <summary>
    /// Gets or sets the casting method for the camera to utilize.
    /// </summary>
    public TCastMethod CastMethod { get; set; } = castMethod;

    public TLength RenderDistance { get; set; } = renderDistance;

    public TAngle Orientation { get; set; } = default;

    public TPosition Position { get; set; } = default;

    /// <summary>
    /// Renders the scene using the provided cast method.
    /// </summary>
    /// <param name="space">The space to render.</param>
    /// <returns>Every cast ray, each None if hits nothing, Some if hits. Some provides information about hit.</returns>
    public IEnumerable<Hit<TPosition, TLength>?> Render(IHitSpace<TPosition> space) =>
        CameraPattern.Render(space, CastMethod, Position, Orientation, RenderDistance);
}
