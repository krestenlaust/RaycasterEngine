using CommunityToolkit.HighPerformance;
using System.Diagnostics;

namespace EngineImpl;

internal class Program
{
    static char[] internalScreenBuffer = [];

    static void Main(string[] args)
    {
        var game = new Game();
        Console.CursorVisible = false;

        Stopwatch sw = new Stopwatch();

        while (true)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight - 1;

            if (internalScreenBuffer.Length != windowWidth * windowHeight)
            {
                //internalScreenBuffer = new char[windowWidth * windowHeight];
                internalScreenBuffer = Enumerable.Repeat(' ', windowWidth * windowHeight).ToArray();
            }
            
            var screen = new Span2D<char>(internalScreenBuffer, windowHeight, windowWidth);

            game.Render(screen);

            Console.SetCursorPosition(0, 0);
            Console.Write(internalScreenBuffer);
            Console.SetWindowPosition(0, 0);

            Console.Title = $"FPS: {Math.Round(1 / sw.Elapsed.TotalSeconds)}";
            sw.Restart();
            Thread.Sleep(0);
        }
    }
}
