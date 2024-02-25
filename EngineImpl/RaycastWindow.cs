using CommunityToolkit.HighPerformance;
using Engine;
using Engine.CameraPattern;
using Engine.CastMethod;
using Engine.MathTypes;

namespace EngineImpl;

public class RaycastWindow : IWindow
{
    public readonly Camera<DiscreteRaycast,
       PerspectiveLineCameraPattern<
           DiscreteRaycast,
           Vector2D,
           float>,
       Vector2D,
       Orientation2D,
       float,
       char> Camera;

    public RaycastWindow(IRenderSpace<Vector2D, char> mapToRaycast)
    {
        Camera =
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

        MapToRaycast = mapToRaycast;
    }

    public IRenderSpace<Vector2D, char> MapToRaycast { get; set; }

    public int Width => Console.WindowWidth;

    public int Height => Console.WindowHeight - 1;

    public void Render(Span2D<char> region)
    {
        Camera.CameraPattern.SampleSize = Width;

        int rayIndex = 0;
        int indexX;
        int indexY;

        // Read input to reorient camera.
        foreach (var ray in Camera.Render(MapToRaycast))
        {
            indexX = rayIndex;
            indexY = Height / 2;

            rayIndex++;

            if (ray is null)
            {
                region[indexY, indexX] = '_';
                continue;
            }

            int renderHeight = (int)((1 / ray.Value.Distance) * 9) + 1;

            if (MapToRaycast.Render(ray.Value.Point, out char renderedUnit))
            {
                region[indexY, indexX] = renderedUnit;

                region[indexY + 1, indexX] = renderHeight.ToString()[0];
            }
        }
    }
}
