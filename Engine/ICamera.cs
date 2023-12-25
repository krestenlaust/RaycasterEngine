namespace Engine;

public interface ICamera<TCastMethod, TPosition, in TAngle, in TLength, TRenderingUnit>
    where TCastMethod : ICast<TPosition, TAngle, TLength, TRenderingUnit>
{
    IEnumerable<(TPosition, TRenderingUnit)?> Render(IMap<TPosition, TRenderingUnit> map, TCastMethod caster, TPosition origin, TAngle orientation, TLength renderDistance);
}
