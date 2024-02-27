using CommunityToolkit.HighPerformance;
using Engine;
using Engine.CameraPattern;
using Engine.CastMethod;
using Engine.MathTypes;

namespace EngineImpl;

public class RaycastWindow(int width, int height, IRenderSpace<Vector2D, char> mapToRaycast) : IWindow
{
    public readonly Camera<DiscreteRaycast,
       PerspectiveLineCameraPattern<
           DiscreteRaycast,
           Vector2D,
           float>,
       Vector2D,
       Orientation2D,
       float,
       char> Camera =
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
                    (Orientation2D.FromDegrees(90), 10), new DiscreteRaycast(0.2f), 10);

    public IRenderSpace<Vector2D, char> MapToRaycast { get; set; } = mapToRaycast;

    public int Width { get; } = width;

    public int Height { get; } = height;

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

            int maxWallRenderHeight = Height;

            int wallRenderHeight = (int)((1 / ray.Value.Distance) * maxWallRenderHeight);

            // Get character to render
            if (!MapToRaycast.Render(ray.Value.Point, out char renderedUnit))
            {
                continue;
            }

            int renderStart = Height / 2 - wallRenderHeight / 2;
            int renderEnd = renderStart + wallRenderHeight;

            for (int y = 0; y < Height; y++)
            {
                if (y < renderStart || y > renderEnd)
                {
                    region[y, indexX] = ' ';
                    continue;
                }

                region[y, indexX] = renderedUnit;
            }
        }
    }
}
