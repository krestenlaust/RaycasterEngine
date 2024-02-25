using Engine;
using Engine.CameraPattern;
using Engine.CastMethod;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl;

public class Game
{
    Camera<DiscreteRaycast,
           PerspectiveLineCameraPattern<
               DiscreteRaycast,
               Vector2D,
               float>,
           Vector2D,
           Orientation2D,
           float,
           char> player;

    static readonly IRenderSpace<Vector2D, char> Map = new CartesianPlane<char>(new char?[,]
    {
            { '#', '#',     '#',      '#', '#' },
            { '#', null, null, null,    '#' },
            { '#', null, null, null,    '#' },
            { '#', null, null, null,    '#' },
            { '#', '#',     '#',      '#', '#' },
    });

    public Game()
    {
        player =
            new Camera<
                DiscreteRaycast,
                PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>,
                Vector2D,
                Orientation2D,
                float,
                char>
                (new PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>
                    (Orientation2D.FromDegrees(90), 10), new DiscreteRaycast(0.05f), 10);

        player.Position = new Vector2D(2, 2);
    }

    public void Tick()
    {
        RenderMap();

        int displayWidth = Console.WindowWidth;
        int displayHeight = Console.WindowHeight;

        player.CameraPattern.SampleSize = displayWidth;

        int rayIndex = 0;

        // Read input to reorient camera.
        foreach (var ray in player.Render(Map))
        {
            Console.SetCursorPosition(rayIndex, displayHeight / 2);
            rayIndex++;

            if (ray is null)
            {
                Console.Write('_');
                continue;
            }

            int renderHeight = (int)((1 / ray.Value.Distance) * 9) + 1;

            if (Map.Render(ray.Value.Point, out char renderedUnit))
            {
                Console.Write(renderedUnit);
                Console.CursorTop += 1;
                Console.Write(renderHeight.ToString()[0]);
            }
        }

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.W:
                player.Position += new Vector2D(0, 1);
                break;
            case ConsoleKey.S:
                player.Position += new Vector2D(0, -1);
                break;
            case ConsoleKey.A:
                player.Position += new Vector2D(1, 0);
                break;
            case ConsoleKey.D:
                player.Position += new Vector2D(-1, 0);
                break;
            case ConsoleKey.Q:
                player.Orientation -= Orientation2D.FullRotation / 12;
                break;
            case ConsoleKey.E:
                player.Orientation += Orientation2D.FullRotation / 12;
                break;
            default:
                break;
        }
        Console.Clear();
    }

    void RenderMap()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Console.SetCursorPosition(x, y);

                if (Map.Render(new Vector2D(x, y), out char rendered))
                {
                    Console.Write(rendered);
                }
                else
                {
                    Console.Write(' ');
                }
            }
        }

        Console.SetCursorPosition((int)player.Position.Floor.X, (int)player.Position.Floor.Y);
        Console.Write('*');
    }
}
