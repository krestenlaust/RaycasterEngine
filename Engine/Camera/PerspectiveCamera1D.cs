namespace Engine.Camera;

public class PerspectiveCamera1D<TCastMethod, TPosition, TLength, TRenderingUnit>(Orientation2D fieldOfView, TLength renderDistance)
    where TCastMethod : ICast<TPosition, Orientation2D, TLength, TRenderingUnit>
{
    public Orientation2D FieldOfView { get; set; } = fieldOfView;
    public TPosition Position { get; set; }
    public Orientation2D Orientation { get; set; } = default;
    public TLength RenderDistance { get; set; } = renderDistance;

    public IEnumerable<(TPosition, TRenderingUnit)?> Render(TCastMethod caster, IMap<TPosition, TRenderingUnit> map, int sampleSize)
    {
        float startRadians = Orientation.Radians - (FieldOfView.Radians / 2);
        float stepSizeRadians = FieldOfView.Radians / sampleSize;

        for (int i = 0; i < sampleSize; i++)
        {
            Orientation2D orientation = new Orientation2D(startRadians + stepSizeRadians * i);
            yield return caster.Cast(map, Position, orientation, RenderDistance);
        }
    }
}
