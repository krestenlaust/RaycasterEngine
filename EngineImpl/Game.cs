using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl;

public class Game : IWindow
{
    static readonly CartesianPlane<char> map = new CartesianPlane<char>(new char?[,]
    {
            { 'P', 'A',     'B',      'C', 'D' },
            { 'O', null, null, null,    'E' },
            { 'N', null, null, null,    'F' },
            { 'M', null, null, null,    'G' },
            { 'L', 'K',     'J',      'I', 'H' },
    });

    readonly List<((int row, int column), IWindow)> renderedWindows = new();
    readonly RaycastWindow raycastWindow;
    readonly MinimapWindow minimapWindow;

    public Game()
    {
        raycastWindow = new RaycastWindow(map);
        minimapWindow = new MinimapWindow(map);

        renderedWindows.Add(((0, 0), raycastWindow));
        renderedWindows.Add(((0, 0), minimapWindow));
    }

    public int Width => Console.WindowWidth;

    public int Height => Console.WindowHeight - 1;

    public void Render(Span2D<char> region)
    {
        foreach (((int, int) pos, IWindow win) in renderedWindows)
        {
            var windowRegion = region.Slice(pos.Item1, pos.Item2, win.Height, win.Width);

            win.Render(windowRegion);
        }

        if (!Console.KeyAvailable)
        {
            return;
        }

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.W:
                raycastWindow.Camera.Position += new Vector2D(0, -1);
                break;
            case ConsoleKey.S:
                raycastWindow.Camera.Position += new Vector2D(0, 1);
                break;
            case ConsoleKey.A:
                raycastWindow.Camera.Position += new Vector2D(-1, 0);
                break;
            case ConsoleKey.D:
                raycastWindow.Camera.Position += new Vector2D(1, 0);
                break;
            case ConsoleKey.Q:
                raycastWindow.Camera.Orientation -= Orientation2D.FullRotation / 12;
                break;
            case ConsoleKey.E:
                raycastWindow.Camera.Orientation += Orientation2D.FullRotation / 12;
                break;
            default:
                break;
        }

        minimapWindow.PlayerLocation = raycastWindow.Camera.Position;
    }
}
