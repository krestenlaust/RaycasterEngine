namespace Engine.MapRepresentation;

public class Map2D : IMap<Vector2D>
{
    public bool IsOutsideMap(Vector2D position)
    {
        return position.X < 0 || position.X > 5 || position.Y < 0 || position.Y > 5;
    }

    public bool IsWall(Vector2D position) =>
        IsWall((int)position.X, (int)position.Y);

    bool IsWall(int x, int y)
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
}
