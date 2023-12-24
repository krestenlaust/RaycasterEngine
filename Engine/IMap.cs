namespace Engine;

public interface IMap<in T> where T : struct
{
    bool IsOutsideMap(T position);

    bool IsWall(T position);
}
