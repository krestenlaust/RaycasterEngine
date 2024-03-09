using CommunityToolkit.HighPerformance;

namespace EngineImpl;

public class CompositWindow<TRenderingUnit> : IWindow<TRenderingUnit>
{
    public List<((int row, int column), IWindow<TRenderingUnit>)> RenderedWindows { get; } = [];

    public int Width { get; set; }

    public int Height { get; set; }

    public void Render(Span2D<TRenderingUnit> region)
    {
        foreach (((int, int) pos, IWindow<TRenderingUnit> win) in RenderedWindows)
        {
            var windowRegion = region.Slice(pos.Item1, pos.Item2, win.Height, win.Width);

            win.Render(windowRegion);
        }
    }
}
