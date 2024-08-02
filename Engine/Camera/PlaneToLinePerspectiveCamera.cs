using Engine.CameraPattern;
using Engine.MathTypes;

namespace Engine.Camera;

/// <summary>
/// Camera to project a euclidean plane onto a euclidean line.
/// </summary>
/// <typeparam name="TCastMethod">The casting method to utilize, e.g. <see cref="CastMethod.DiscreteRaycast"/> for standard euclidean iterative line casting.</typeparam>
/// <typeparam name="TRenderingUnit">The unit to represent what a raycaster sees.</typeparam>
public class PlaneToLinePerspectiveCamera<TCastMethod, TRenderingUnit>(TCastMethod castMethod)
    where TCastMethod : ICastMethod<Vector2D, Orientation, float>
    where TRenderingUnit : struct
{
    Camera<TCastMethod, PerspectiveLineCameraPattern<TCastMethod, Vector2D, float>, Vector2D, Orientation, float, TRenderingUnit> internalCamera = new Camera<TCastMethod, PerspectiveLineCameraPattern<TCastMethod, Vector2D, float>, Vector2D, Orientation, float, TRenderingUnit>(
            new PerspectiveLineCameraPattern<TCastMethod, Vector2D, float>(Orientation.FromDegrees(90), 90),
            castMethod,
            10);
}
