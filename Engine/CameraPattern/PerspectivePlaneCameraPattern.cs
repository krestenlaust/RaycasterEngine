using Engine.MathTypes;

namespace Engine.CameraPattern;

// TODO: The angle type needs to be spherical instead of planarly.
public class PerspectivePlaneCameraPattern<TCastMethod, TPosition, TLength>(Angle fieldOfView, int sampleSize) : ICameraPattern<TCastMethod, TPosition, Angle, TLength>
    where TCastMethod : ICastMethod<TPosition, Angle, TLength>
{
    /// <summary>
    /// Gets or sets the vertical field of view, of the camera pattern.
    /// </summary>
    public Angle FieldOfViewVertical { get; set; } = fieldOfView;

    /// <summary>
    /// Gets or sets the horizontal field of view, of the camera pattern.
    /// </summary>
    public Angle FieldOfViewHorizontal { get; set; } = fieldOfView;

    /// <summary>
    /// Gets or sets the amount of vertical samples to take within the field of view.
    /// </summary>
    public int SampleSizeVertical { get; set; } = sampleSize;

    /// <summary>
    /// Gets or sets the amount of horizontal samples to take within the field of view.
    /// </summary>
    public int SampleSizeHorizontal { get; set; } = sampleSize;

    public IEnumerable<Hit<TPosition, TLength>?> Render(IHitSpace<TPosition> space, TCastMethod caster, TPosition origin, Angle orientation, TLength renderDistance)
    {
        float startRadiansVertical = orientation.Radians - (FieldOfViewVertical.Radians / 2);
        float stepSizeRadiansVertical = FieldOfViewVertical.Radians / SampleSizeVertical;

        for (int y = 0; y < SampleSizeVertical; y++)
        {
            float startRadiansHorizontal = orientation.Radians - (FieldOfViewHorizontal.Radians / 2);
            float stepSizeRadiansHorizontal = FieldOfViewHorizontal.Radians / SampleSizeHorizontal;

            for (int x = 0; x < SampleSizeHorizontal; x++)
            {
                var currentDirection = new Angle(startRadiansHorizontal + (stepSizeRadiansHorizontal * x));

                if (caster.Cast(space, origin, currentDirection, renderDistance, out Hit<TPosition, TLength>? hit))
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
}
