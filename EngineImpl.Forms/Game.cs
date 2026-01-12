using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl.Forms;

public class Game : IWindow<Color>
{
    static readonly CartesianPlane<Color> map = new CartesianPlane<Color>(new Color?[,]
    {
            { Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue },
            { Color.Green, null, null, null, null, Color.Red, null, null, Color.Green },
            { Color.Blue, null, null, Color.Red, null, null, null, null, Color.Blue },
            { Color.Green, null, null, null, null, Color.Red, null, null, Color.Green },
            { Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue, Color.Green, Color.Blue },
    });

    readonly RaycastWindow<Color> raycastWindow;
    readonly CompositWindow<Color> compositWindow;

    public Game(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        raycastWindow = new RaycastWindow<Color>(width, height, map)
        {
            NothingUnit = Color.Transparent,
            CeilingUnit = Color.White,
            FloorUnit = Color.Gray
        };

        raycastWindow.Camera.Position = new Vector2D(1, 1);

        compositWindow = new CompositWindow<Color>();
        compositWindow.RenderedWindows.Add(((0, 0), raycastWindow));
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public float MovementSpeed { get; set; } = 0.5f;

    public void Render(Span2D<Color> region)
    {
        compositWindow.Render(region);

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
    }
}
