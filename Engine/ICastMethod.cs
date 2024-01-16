namespace Engine;

public interface ICastMethod<TPosition, in TAngle, TLength>
{
    bool Cast(IHitMap<TPosition> map, TPosition origin, TAngle direction, TLength maxDistance, out Hit<TPosition, TLength>? hit);
}
