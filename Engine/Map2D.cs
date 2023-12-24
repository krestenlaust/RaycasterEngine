namespace Engine;

public class Map2D
{
    public bool IsWall(int x, int y)
    {
        int[,] map =
        {
            { 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1 }
        };

        return map[x, y] == 1;
    }

    public bool Outside(int x, int y)
    {
        return x < 0 || x > 5 || y < 0 || y > 5;
    }

    public Vector2D? Cast(Vector2D origin, Orientation2D direction, float maxDistance)
    {
        // Calculate offset to nearby grid.

        // Extrapolate position by grid unit, till something is hit.

        throw new NotImplementedException();
    }

    /// <summary>
    /// Casts using the basic incremental method.
    /// TODO: Make each casting method have its own class via a interface.
    /// This would make it easier to change raycast method to a non-euclidian method in the future.
    /// </summary>
    /// <returns></returns>
    public Vector2D? CastIncremental(Vector2D origin, Orientation2D direction, float maxDistance, float stepSize)
    {
        Vector2D directionVector = direction.Vector;

        for (float dist = 0; dist < maxDistance; dist += stepSize)
        {
            Vector2D hit = directionVector * dist + origin;
            Vector2D hitCell = hit.Floor;

            
        }


        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the first hit along horizontal grid lines.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    /// <param name="maxDistance"></param>
    /// <returns></returns>
    Vector2D? CastHorizontal(Vector2D origin, Orientation2D direction, float maxDistance)
    {
        throw new NotImplementedException();
    }
}
