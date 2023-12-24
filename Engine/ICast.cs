namespace Engine;

public interface ICast<TPosition, TOrientation, TLength>
    where TPosition : struct
    where TOrientation : struct
    where TLength : struct
{
    TPosition? Cast(IMap<TPosition> map, TPosition origin, TOrientation direction, TLength maxDistance);
}
