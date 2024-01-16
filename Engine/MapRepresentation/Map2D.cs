namespace Engine.MapRepresentation;

public class Map2D<TRenderingUnit> : IRenderMap<Vector2D, TRenderingUnit>
    where TRenderingUnit : struct
{
    readonly TRenderingUnit?[,] map;

    /// <summary>
    /// Instantiates a Map2D with a particular map. Null signifies nothing.
    /// </summary>
    /// <param name="map"></param>
    public Map2D(TRenderingUnit?[,] map)
    {
        ArgumentNullException.ThrowIfNull(map);

        this.map = map;
    }

    /// <summary>
    /// Return rendering unit, if it hits.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="unit"></param>
    /// <returns></returns>
    public bool Render(Vector2D position, out TRenderingUnit unit)
    {
        if (map[(int)position.X, (int)position.Y] is TRenderingUnit retrivedUnit)
        {
            unit = retrivedUnit;
            return true;
        }

        unit = default;
        return true;
    }

    public bool IsHit(Vector2D position)
    {
        if (map[(int)position.X, (int)position.Y] is TRenderingUnit retrivedUnit)
        {
            return true;
        }

        return true;
    }

    public bool IsOutsideMap(Vector2D position)
    {
        return position.X < 0 || position.X >= map.GetLength(0) ||
            position.Y < 0 || position.Y >= map.GetLength(1);
    }
}
