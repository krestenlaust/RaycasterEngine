using Engine.MathTypes;

namespace Engine.CameraPattern;

public class PerspectivePlaneCameraPattern<TCastMethod, TPosition, TLength>(Angle fieldOfViewVertical, Angle fieldOfViewHorizontal, int sampleSize) : ICameraPattern<TCastMethod, TPosition, SphericalDirection, TLength>
    where TCastMethod : ICastMethod<TPosition, SphericalDirection, TLength>
{
    /// <summary>
    /// Gets or sets the vertical field of view, of the camera pattern.
    /// </summary>
    public Angle FieldOfViewVertical { get; set; } = fieldOfViewVertical;

    /// <summary>
    /// Gets or sets the horizontal field of view, of the camera pattern.
    /// </summary>
    public Angle FieldOfViewHorizontal { get; set; } = fieldOfViewHorizontal;

    /// <summary>
    /// Gets or sets the amount of vertical samples to take within the field of view.
    /// </summary>
    public int SampleSizeVertical { get; set; } = sampleSize;

    /// <summary>
    /// Gets or sets the amount of horizontal samples to take within the field of view.
    /// </summary>
    public int SampleSizeHorizontal { get; set; } = sampleSize;

    public IEnumerable<Hit<TPosition, TLength>?> Render(IHitSpace<TPosition> space, TCastMethod caster, TPosition origin, SphericalDirection orientation, TLength renderDistance)
    {
        float startRadiansVertical = orientation.Inclination.Radians - (FieldOfViewVertical.Radians / 2);
        float stepSizeRadiansVertical = FieldOfViewVertical.Radians / SampleSizeVertical;

        for (int y = 0; y < SampleSizeVertical; y++)
        {
            Angle polarAngle = new (startRadiansVertical + (stepSizeRadiansVertical * y));

            float startRadiansHorizontal = orientation.Azimuth.Radians - (FieldOfViewHorizontal.Radians / 2);
            float stepSizeRadiansHorizontal = FieldOfViewHorizontal.Radians / SampleSizeHorizontal;

            for (int x = 0; x < SampleSizeHorizontal; x++)
            {
                Angle azimuthalAngle = new (startRadiansHorizontal + (stepSizeRadiansHorizontal * x));

                SphericalDirection currentDirection = new (azimuthalAngle, polarAngle);

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
