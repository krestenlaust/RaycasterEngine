namespace Engine;

/// <summary>
/// This entity utilizes a <see cref="ICameraPattern{TCastMethod, TPosition, TAngle, TLength}"/>,
/// to project a <see cref="IRenderMap{TPosition, TRenderingUnit}"/> onto a 2D? screen.
/// </summary>
public interface ICamera<TCastMethod, TCameraPattern, TPosition, in TAngle, TLength, TRenderingUnit>
    where TCastMethod : ICastMethod<TPosition, TAngle, TLength>
    where TCameraPattern : ICameraPattern<TCastMethod, TPosition, TAngle, TLength>
{
}
