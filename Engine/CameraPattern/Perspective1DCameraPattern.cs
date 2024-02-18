using Engine.MathTypes;

namespace Engine.CameraPattern;

/// <summary>
/// Casts another space into 1D.
/// </summary>
/// <typeparam name="TCastMethod">The casting method to utilize, e.g. <see cref="CastMethod.DiscreteRaycast"/> for standard euclidean iterative line casting.</typeparam>
/// <typeparam name="TPosition">The spacial type to utilize, e.g. <see cref="MathTypes.Vector2D"/> for standard cartesian coordinate.</typeparam>
/// <typeparam name="TLength">The distance type to utilize, e.g. <see cref="float"/>.</typeparam>
/// <param name="fieldOfView">The field of view, of the camera pattern.</param>
/// <param name="sampleSize">The amount of samples to take within the field of view.</param>
public class Perspective1DCameraPattern<TCastMethod, TPosition, TLength>(Orientation2D fieldOfView, int sampleSize) : ICameraPattern<TCastMethod, TPosition, Orientation2D, TLength>
    where TCastMethod : ICastMethod<TPosition, Orientation2D, TLength>
{
    /// <summary>
    /// Gets or sets the field of view, of the camera pattern.
    /// </summary>
    public Orientation2D FieldOfView { get; set; } = fieldOfView;

    /// <summary>
    /// Gets or sets the amount of samples to take within the field of view.
    /// </summary>
    public int SampleSize { get; set; } = sampleSize;

    /// <inheritdoc/>
    public IEnumerable<Hit<TPosition, TLength>?> Render(IHitSpace<TPosition> space, TCastMethod caster, TPosition origin, Orientation2D orientation, TLength renderDistance)
    {
        float startRadians = orientation.Radians - (FieldOfView.Radians / 2);
        float stepSizeRadians = FieldOfView.Radians / SampleSize;

        for (int i = 0; i < SampleSize; i++)
        {
            var currentDirection = new Orientation2D(startRadians + (stepSizeRadians * i));

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
