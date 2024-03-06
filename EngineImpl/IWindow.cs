using CommunityToolkit.HighPerformance;

namespace EngineImpl
{
    internal interface IWindow
    {
        int Width { get; }

        int Height { get; }

        void Render(Span2D<char> region);
    }
}
