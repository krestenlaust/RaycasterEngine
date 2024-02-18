namespace Engine;

/// <summary>
/// This entity utilizes a <see cref="ICameraPattern{TCastMethod, TPosition, TAngle, TLength}"/>,
/// to project a <see cref="IRenderSpace{TPosition, TRenderingUnit}"/> into another space.
/// </summary>
/// <typeparam name="TCastMethod">The casting method to utilize, e.g. <see cref="CastMethod.DiscreteRaycast"/> for standard euclidean iterative line casting.</typeparam>
/// <typeparam name="TCameraPattern">The camera casting pattern to utilize, describes the way the camera casts its rays. E.g. <see cref="CameraPattern.Perspective1DCameraPattern{TCastMethod, TPosition, TLength}"/> to cast into 1D.</typeparam>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TAngle">The angular type to utilize, e.g. <see cref="MathTypes.Orientation2D"/> for basic euclidean orientational properties.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
/// <typeparam name="TRenderingUnit">The unit to represent what a raycaster sees.</typeparam>
public interface ICamera<TCastMethod, TCameraPattern, TPosition, in TAngle, TLength, TRenderingUnit>
    where TCastMethod : ICastMethod<TPosition, TAngle, TLength>
    where TCameraPattern : ICameraPattern<TCastMethod, TPosition, TAngle, TLength>
{
}
