namespace Engine;

public interface ICast<TPosition, in TOrientation, in TLength, TRenderingUnit>
{
    (TPosition, TRenderingUnit)? Cast(IMap<TPosition, TRenderingUnit> map, TPosition origin, TOrientation direction, TLength maxDistance);
}
