namespace Engine;

public interface ICast<TPosition, in TAngle, in TLength, TRenderingUnit>
{
    (TPosition, TRenderingUnit)? Cast(IMap<TPosition, TRenderingUnit> map, TPosition origin, TAngle direction, TLength maxDistance);
}
