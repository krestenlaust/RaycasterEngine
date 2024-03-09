using CommunityToolkit.HighPerformance;

namespace EngineImpl;

public interface IWindow<TRenderingUnit>
{
    int Width { get; }

    int Height { get; }

    void Render(Span2D<TRenderingUnit> region);
}
