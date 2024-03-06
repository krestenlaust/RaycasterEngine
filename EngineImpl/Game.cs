using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl;

public class Game : IWindow
{
    static readonly CartesianPlane<char> map = new CartesianPlane<char>(new char?[,]
    {
            { 'P', 'A',     'B',      'C', 'D', 'K', 'R', 'R', 'R' },
            { 'O', null, null, null, null, '#', null, null,    'E' },
            { 'N', null, null, 'M', null, null, null, null,   'F' },
            { 'M', null, null, null, null, '#', null, null,   'G' },
            { 'L', 'K',     'J',      'I', 'D', 'E', 'S', 'S', 'S' },
    });

    readonly List<((int row, int column), IWindow)> renderedWindows = new();
    readonly RaycastWindow raycastWindow;
    readonly MinimapWindow minimapWindow;

    public Game(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        raycastWindow = new RaycastWindow(width, height, map);
        minimapWindow = new MinimapWindow(map);

        raycastWindow.Camera.Position = new Vector2D(1, 1);

        renderedWindows.Add(((0, 0), raycastWindow));
        renderedWindows.Add(((0, 0), minimapWindow));
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public float MovementSpeed { get; set; } = 0.5f;

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
                raycastWindow.Camera.Position += raycastWindow.Camera.Orientation.Vector * MovementSpeed;
                break;
            case ConsoleKey.S:
                raycastWindow.Camera.Position -= raycastWindow.Camera.Orientation.Vector * MovementSpeed;
                break;
            case ConsoleKey.A:
                raycastWindow.Camera.Position += new Vector2D(raycastWindow.Camera.Orientation.Vector.Y, -raycastWindow.Camera.Orientation.Vector.X) * MovementSpeed;
                break;
            case ConsoleKey.D:
                raycastWindow.Camera.Position += new Vector2D(-raycastWindow.Camera.Orientation.Vector.Y, raycastWindow.Camera.Orientation.Vector.X) * MovementSpeed;
                break;
            case ConsoleKey.UpArrow:
                raycastWindow.Camera.Position += new Vector2D(0, -1) * MovementSpeed;
                break;
            case ConsoleKey.DownArrow:
                raycastWindow.Camera.Position += new Vector2D(0, 1) * MovementSpeed;
                break;
            case ConsoleKey.LeftArrow:
                raycastWindow.Camera.Position += new Vector2D(-1, 0) * MovementSpeed;
                break;
            case ConsoleKey.RightArrow:
                raycastWindow.Camera.Position += new Vector2D(1, 0) * MovementSpeed;
                break;
            case ConsoleKey.Q:
                raycastWindow.Camera.Orientation -= Orientation2D.FullRotation / 16;
                break;
            case ConsoleKey.E:
                raycastWindow.Camera.Orientation += Orientation2D.FullRotation / 16;
                break;
            case ConsoleKey.Z:
                raycastWindow.Z -= 0.1f;
                break;
            case ConsoleKey.X:
                raycastWindow.Z += 0.1f;
                break;
            default:
                break;
        }

        minimapWindow.PlayerLocation = raycastWindow.Camera.Position;
    }
}
