using Engine.MathTypes;

namespace Engine.CameraPattern;

public class Perspective1DCameraPattern<TCastMethod, TPosition, TLength>(Orientation2D fieldOfView, int sampleSize) : ICameraPattern<TCastMethod, TPosition, Orientation2D, TLength>
    where TCastMethod : ICastMethod<TPosition, Orientation2D, TLength>
{
    public Orientation2D FieldOfView { get; set; } = fieldOfView;

    public int SampleSize { get; set; } = sampleSize;

    public IEnumerable<Hit<TPosition, TLength>?> Render(IHitMap<TPosition> map, TCastMethod caster, TPosition origin, Orientation2D orientation, TLength renderDistance)
    {
        float startRadians = orientation.Radians - (FieldOfView.Radians / 2);
        float stepSizeRadians = FieldOfView.Radians / SampleSize;

        for (int i = 0; i < SampleSize; i++)
        {
            var currentDirection = new Orientation2D(startRadians + (stepSizeRadians * i));

            if (caster.Cast(map, origin, currentDirection, renderDistance, out Hit<TPosition, TLength>? hit))
            {
                yield return hit;
            }
            else
            {
                yield return null;
            }
        }
    }
}
