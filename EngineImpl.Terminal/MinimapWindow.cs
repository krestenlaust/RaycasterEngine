﻿using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl.Terminal;

public class MinimapWindow(CartesianPlane<char> map) : IWindow<char>
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

        Vector2D starLocation = PlayerLocation.Round;

        if (starLocation.X < 0 || starLocation.Y < 0 || starLocation.X >= Map.Width || starLocation.Y >= Map.Height)
        {
            return;
        }

        region[(int)starLocation.Y, (int)starLocation.X] = '*';
    }
}
