namespace Engine.MapRepresentation;

public class Map2D : IMap<Vector2D, char>
{
    public bool IsOutsideMap(Vector2D position)
    {
        return position.X < 0 || position.X > 5 || position.Y < 0 || position.Y > 5;
    }

    /// <summary>
    /// Return character as rendering unit, if it hits.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="renderingUnit"></param>
    /// <returns></returns>
    public bool IsHit(Vector2D position, out char renderingUnit)
    {
        int[,] map =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 }
        };

        int hit = map[(int)position.X, (int)position.Y];

        if (hit == 1)
        {
            renderingUnit = '#';
            return true;
        }

        renderingUnit = default;
        return false;
    }
}
