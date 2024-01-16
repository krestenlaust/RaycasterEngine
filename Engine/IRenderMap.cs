namespace Engine;

public interface IRenderMap<in TPosition, TRenderingUnit> : IHitMap<TPosition>
{
    bool Render(TPosition position, out TRenderingUnit renderedUnit);
}
