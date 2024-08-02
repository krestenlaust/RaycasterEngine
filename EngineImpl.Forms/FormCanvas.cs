using CommunityToolkit.HighPerformance;
using System.Diagnostics;

namespace EngineImpl.Forms;

public partial class FormCanvas : Form
{
    Graphics graphics;
    System.Windows.Forms.Timer gameLoopTimer;
    Game game;

    public FormCanvas()
    {
        InitializeComponent();
    }

    private void FormCanvas_Load(object sender, EventArgs e)
    {
        graphics = pictureBoxCanvas.CreateGraphics();
        gameLoopTimer = new System.Windows.Forms.Timer();
        gameLoopTimer.Tick += GameLoopTimer_Tick;
    }

    private void GameLoopTimer_Tick(object? sender, EventArgs e)
    {
        Console.CursorVisible = false;

        Stopwatch sw = new Stopwatch();

        int windowWidth = ???;
        int windowHeight = ???;

        var game = new Game(windowWidth, windowHeight);

        while (true)
        {
            game.Width = windowWidth;
            game.Height = windowHeight;

            var screen = new Span2D<Color>(???, windowHeight, windowWidth);

            game.Render(screen);
            // Something write to buffer

            Text = $"FPS: {Math.Round(1 / sw.Elapsed.TotalSeconds)}";
            sw.Restart();
            Thread.Sleep(0);
        }
    }
}
