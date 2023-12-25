namespace Engine.Camera;

public class PerspectiveCamera1D<TCastMethod, TPosition, TLength, TRenderingUnit>(Orientation2D fieldOfView, int sampleSize) : ICamera<TCastMethod, TPosition, Orientation2D, TLength, TRenderingUnit>
    where TCastMethod : ICastMethod<TPosition, Orientation2D, TLength, TRenderingUnit>
{
    public Orientation2D FieldOfView { get; set; } = fieldOfView;
    public int SampleSize { get; set; } = sampleSize;

    public IEnumerable<(TPosition, TRenderingUnit)?> Render(IMap<TPosition, TRenderingUnit> map, TCastMethod caster, TPosition origin, Orientation2D orientation, TLength renderDistance)
    {
        float startRadians = orientation.Radians - (FieldOfView.Radians / 2);
        float stepSizeRadians = FieldOfView.Radians / SampleSize;

        for (int i = 0; i < SampleSize; i++)
        {
            var currentDirection = new Orientation2D(startRadians + stepSizeRadians * i);
            yield return caster.Cast(map, origin, currentDirection, renderDistance);
        }
    }
}
