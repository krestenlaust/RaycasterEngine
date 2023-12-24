namespace Engine;

public interface ICast<TPosition, TOrientation, TLength, TRenderingUnit>
    where TLength : struct
{
    (TPosition, TRenderingUnit)? Cast(IMap<TPosition, TRenderingUnit> map, TPosition origin, TOrientation direction, TLength maxDistance);
}
