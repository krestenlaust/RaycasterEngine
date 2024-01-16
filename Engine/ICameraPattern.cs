namespace Engine;

public interface ICameraPattern<TCastMethod, TPosition, in TAngle, TLength>
    where TCastMethod : ICastMethod<TPosition, TAngle, TLength>
{
    IEnumerable<Hit<TPosition, TLength>?> Render(IHitMap<TPosition> map, TCastMethod caster, TPosition origin, TAngle orientation, TLength renderDistance);
}
