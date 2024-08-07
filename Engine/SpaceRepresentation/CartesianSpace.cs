using Engine.MathTypes;

namespace Engine.SpaceRepresentation;

/// <summary>
/// Represents a 3D mapping of rendering units.
/// </summary>
/// <typeparam name="TRenderingUnit">The unit to represent a rendering atom.</typeparam>
public class CartesianSpace<TRenderingUnit> : IRenderSpace<Vector3D, TRenderingUnit>
    where TRenderingUnit : struct
{
    readonly TRenderingUnit?[,,] space;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartesianSpace{TRenderingUnit}"/> class.
    /// </summary>
    /// <param name="space">The instance of the 3D mapping to rendering units.</param>
    public CartesianSpace(TRenderingUnit?[,,] space)
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

    /// <summary>
    /// Gets the depth of the allocated space.
    /// </summary>
    public int Depth { get => space.GetLength(2); }

    /// <inheritdoc/>
    public bool Render(Vector3D position, out TRenderingUnit unit)
    {
        position = GetCorrectlyMappedCell(position.GetCartesianCube());

        if (space[(int)position.X, (int)position.Y, (int)position.Z] is TRenderingUnit retrivedUnit)
        {
            unit = retrivedUnit;
            return true;
        }

        unit = default;
        return false;
    }

    /// <inheritdoc/>
    public bool IsHit(Vector3D position) =>
        Render(position, out _);

    /// <inheritdoc/>
    public bool IsOutsideSpace(Vector3D position)
    {
        position = GetCorrectlyMappedCell(position.GetCartesianCube());

        return position.X < 0 || position.X >= Width ||
            position.Y < 0 || position.Y >= Height ||
            position.Z < 0 || position.Z >= Depth;
    }

    Vector3D GetCorrectlyMappedCell(Vector3D position) =>
    new (
        position.X,
        position.Y,
        position.Z);
}
