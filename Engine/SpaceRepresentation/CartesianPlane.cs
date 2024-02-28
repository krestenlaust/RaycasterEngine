using Engine.MathTypes;

namespace Engine.SpaceRepresentation;

/// <summary>
/// Represents a 2D mapping of rendering units.
/// </summary>
/// <typeparam name="TRenderingUnit">The unit to represent a rendering atom.</typeparam>
public class CartesianPlane<TRenderingUnit> : IRenderSpace<Vector2D, TRenderingUnit>
    where TRenderingUnit : struct
{
    readonly TRenderingUnit?[,] space;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartesianPlane{TRenderingUnit}"/> class with a particular space.
    /// Null signifies nothing.
    /// </summary>
    /// <param name="space">The instance of the 2D mapping to rendering units.</param>
    public CartesianPlane(TRenderingUnit?[,] space)
    {
        ArgumentNullException.ThrowIfNull(space);

        this.space = space;
    }

    /// <summary>
    /// Gets the width of the allocated space.
    /// </summary>
    public int Width { get => space.GetLength(0); }

    /// <summary>
    /// Gets the height of the allocated space.
    /// </summary>
    public int Height { get => space.GetLength(1); }

    /// <inheritdoc/>
    public bool Render(Vector2D position, out TRenderingUnit unit)
    {
        position = GetCorrectlyMappedCell(position.GetCartesianCell());

        if (space[(int)position.X, (int)position.Y] is TRenderingUnit retrivedUnit)
        {
            unit = retrivedUnit;
            return true;
        }

        unit = default;
        return false;
    }

    /// <inheritdoc/>
    public bool IsHit(Vector2D position) =>
        Render(position, out _);

    /// <inheritdoc/>
    public bool IsOutsideSpace(Vector2D position)
    {
        position = GetCorrectlyMappedCell(position.GetCartesianCell());

        return position.X < 0 || position.X >= space.GetLength(0) ||
            position.Y < 0 || position.Y >= space.GetLength(1);
    }

    Vector2D GetCorrectlyMappedCell(Vector2D position) =>
        new (
            position.X,
            space.GetLength(1) - 1 - position.Y);
}
