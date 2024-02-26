using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl;

public class MinimapWindow(CartesianPlane<char> map) : IWindow
{
    public CartesianPlane<char> Map { get; set; } = map;
    public Vector2D PlayerLocation { get; set; }

    public int Width => Map.Width;

    public int Height => Map.Height;

    public void Render(Span2D<char> region)
    {
        for (int y = 0; y < Map.Height; y++)
        {
            for (int x = 0; x < Map.Width; x++)
            {
                if (Map.Render(new Vector2D(x, y), out char rendered))
                {
                    region[y, x] = rendered;
                }
                else
                {
                    region[y, x] = ' ';
                }
            }
        }

        region[(int)PlayerLocation.Round.Y, (int)PlayerLocation.Round.X] = '*';
    }
}
