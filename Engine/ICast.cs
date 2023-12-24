namespace Engine;

public interface ICast<TPosition, TOrientation, TLength, TRenderingUnit>
{
    (TPosition, TRenderingUnit)? Cast(IMap<TPosition, TRenderingUnit> map, TPosition origin, TOrientation direction, TLength maxDistance);
}
