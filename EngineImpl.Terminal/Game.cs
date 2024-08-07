﻿using CommunityToolkit.HighPerformance;
using Engine.MathTypes;
using Engine.SpaceRepresentation;

namespace EngineImpl.Terminal;

public class Game : IWindow<char>
{
    static readonly CartesianPlane<char> map = new CartesianPlane<char>(new char?[,]
    {
            { 'P', 'A',     'B',      'C', 'D', 'K', 'R', 'R', 'R' },
            { 'O', null, null, null, null, '#', null, null,    'E' },
            { 'N', null, null, 'M', null, null, null, null,   'F' },
            { 'M', null, null, null, null, '#', null, null,   'G' },
            { 'L', 'K',     'J',      'I', 'D', 'E', 'S', 'S', 'S' },
    });

    readonly RaycastWindow<char> raycastWindow;
    readonly MinimapWindow minimapWindow;
    readonly CompositWindow<char> compositWindow;

    public Game(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        raycastWindow = new RaycastWindow<char>(width, height, map);
        raycastWindow.NothingUnit = '_';
        raycastWindow.CeilingUnit = ' ';
        raycastWindow.FloorUnit = '.';

        minimapWindow = new MinimapWindow(map);

        raycastWindow.Camera.Position = new Vector2D(1, 1);

        compositWindow = new CompositWindow<char>();
        compositWindow.RenderedWindows.Add(((0, 0), raycastWindow));
        compositWindow.RenderedWindows.Add(((0, 0), minimapWindow));
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public float MovementSpeed { get; set; } = 0.5f;

    public void Render(Span2D<char> region)
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
                raycastWindow.Camera.Orientation -= Angle.FullRotation / 16;
                break;
            case ConsoleKey.E:
                raycastWindow.Camera.Orientation += Angle.FullRotation / 16;
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
