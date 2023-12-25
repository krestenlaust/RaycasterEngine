namespace Engine;

public interface IMap<in TPosition, TRenderingUnit>
{
    bool IsOutsideMap(TPosition position);

    bool IsHit(TPosition position, out TRenderingUnit unit);
}
