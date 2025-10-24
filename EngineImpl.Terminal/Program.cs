using CommunityToolkit.HighPerformance;
using System.Diagnostics;

namespace EngineImpl.Terminal;

internal class Program
{
    static char[] internalScreenBuffer = [];

    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Stopwatch sw = new Stopwatch();

        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight - 1;

        var game = new Game(windowWidth, windowHeight);

        while (true)
        {
            windowWidth = Console.WindowWidth;
            windowHeight = Console.WindowHeight - 1;

            game.Width = windowWidth;
            game.Height = windowHeight;

            if (internalScreenBuffer.Length != windowWidth * windowHeight)
            {
                //internalScreenBuffer = new char[windowWidth * windowHeight];
                internalScreenBuffer = Enumerable.Repeat(' ', windowWidth * windowHeight).ToArray();
            }
            
            var screen = new Span2D<char>(internalScreenBuffer, windowHeight, windowWidth);

            game.Render(screen);

            if (OperatingSystem.IsWindows()){
                Console.SetCursorPosition(0, 0);
            } else {
                Console.Write("\u001b[H\u001b[2J");
            }

            Console.Write(internalScreenBuffer);

            Console.Title = $"FPS: {Math.Round(1 / sw.Elapsed.TotalSeconds)}";
            sw.Restart();
            Thread.Sleep(0);
        }
    }
}
