namespace Engine;

public readonly struct Hit<TPosition, TLength>(TPosition origin, TPosition point, TLength distance)
{
    public readonly TPosition Origin = origin;
    public readonly TPosition Point = point;
    public readonly TLength Distance = distance;
}
