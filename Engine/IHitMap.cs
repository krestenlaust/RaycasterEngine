namespace Engine;

public interface IHitMap<in TPosition>
{
    bool IsOutsideMap(TPosition position);

    bool IsHit(TPosition position);
}
