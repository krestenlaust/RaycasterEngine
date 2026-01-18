using CommunityToolkit.HighPerformance;
using Microsoft.AspNetCore.Components;

namespace EngineImpl.WebApp;

using Microsoft.JSInterop;

public class CanvasWindow : IWindow<(byte, byte, byte)>
{
    private readonly IJSRuntime _js;
    private readonly ElementReference _canvas;

    public int Width { get; }
    public int Height { get; }

    public CanvasWindow(IJSRuntime js, ElementReference canvas, int width, int height)
    {
        _js = js;
        _canvas = canvas;
        Width = width;
        Height = height;
    }

    public void Render(Span2D<(byte, byte, byte)> region)
    {
        byte[] buffer = new byte[Width * Height * 4]; // RGBA

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int idx = (y * Width + x) * 4;
                buffer[idx + 0] = region[x, y].Item1; // R
                buffer[idx + 1] = region[x, y].Item2; // G
                buffer[idx + 2] = region[x, y].Item3; // B
                buffer[idx + 3] = 255; // A
            }
        }

        _js.InvokeVoidAsync("canvasInterop.render", _canvas, buffer, Width, Height);
    }
}
