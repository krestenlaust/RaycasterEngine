namespace Engine.MapRepresentation;

public class Map2D<TRenderingUnit> : IMap<Vector2D, TRenderingUnit>
{
    readonly TRenderingUnit?[,] map;

    public Map2D(TRenderingUnit?[,] map)
    {
        ArgumentNullException.ThrowIfNull(map);

        this.map = map;
    }

    /// <summary>
    /// Return rendering unit, if it hits.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="renderingUnit"></param>
    /// <returns></returns>
    public bool IsHit(Vector2D position, out TRenderingUnit unit)
    {
        if (map[(int)position.X, (int)position.Y] is TRenderingUnit retrivedUnit)
        {
            unit = retrivedUnit;
            return true;
        }

        unit = default;
        return true;
    }

    public bool IsOutsideMap(Vector2D position)
    {
        return position.X < 0 || position.X >= map.GetLength(0) ||
            position.Y < 0 || position.Y >= map.GetLength(1);
    }
}
