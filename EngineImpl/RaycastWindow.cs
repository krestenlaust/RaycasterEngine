using CommunityToolkit.HighPerformance;
using Engine;
using Engine.CameraPattern;
using Engine.CastMethod;
using Engine.MathTypes;

namespace EngineImpl;

public class RaycastWindow<TRenderingUnit>(int width, int height, IRenderSpace<Vector2D, TRenderingUnit> mapToRaycast) : IWindow<TRenderingUnit>
{
    public readonly Camera<DiscreteRaycast,
       PerspectiveLineCameraPattern<
           DiscreteRaycast,
           Vector2D,
           float>,
       Vector2D,
       Orientation2D,
       float,
       TRenderingUnit> Camera =
            new Camera<
                DiscreteRaycast,
                PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>,
                Vector2D,
                Orientation2D,
                float,
                TRenderingUnit>
                (new PerspectiveLineCameraPattern<
                    DiscreteRaycast,
                    Vector2D,
                    float>
                    (Orientation2D.FromDegrees(90), 10), new DiscreteRaycast(0.1f), 15);

    public IRenderSpace<Vector2D, TRenderingUnit> MapToRaycast { get; set; } = mapToRaycast;

    public TRenderingUnit CeilingUnit { get; set; }
    public TRenderingUnit FloorUnit { get; set; }
    public TRenderingUnit NothingUnit { get; set; }

    public int Width { get; } = width;

    public int Height { get; } = height;

    public float Z { get; set; } = 0.5f;

    public void Render(Span2D<TRenderingUnit> region)
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
                region[indexY, indexX] = NothingUnit;
                continue;
            }

            int maxWallRenderHeight = Height;

            float upperHalf = (1 - Z) / ray.Value.Distance;
            float lowerHalf = (Z) / ray.Value.Distance;

            int renderStart = (Height / 2) - (int)(upperHalf * maxWallRenderHeight);
            int renderEnd = (Height / 2) + (int)(lowerHalf * maxWallRenderHeight);

            // Get character to render
            if (!MapToRaycast.Render(ray.Value.Point, out TRenderingUnit renderedUnit))
            {
                continue;
            }

            for (int y = 0; y < Height; y++)
            {
                if (y < renderStart)
                {
                    region[y, indexX] = CeilingUnit;
                    continue;
                }

                if (y > renderEnd)
                {
                    region[y, indexX] = FloorUnit;
                    continue;
                }

                region[y, indexX] = renderedUnit;
            }
        }
    }
}
