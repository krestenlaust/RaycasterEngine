namespace Engine;

public interface ICastMethod<TPosition, in TAngle, TLength, TRenderingUnit>
{
    bool Cast(IMap<TPosition, TRenderingUnit> map, TPosition origin, TAngle direction, TLength maxDistance, out Hit<TPosition, TLength, TRenderingUnit>? hit);
}
