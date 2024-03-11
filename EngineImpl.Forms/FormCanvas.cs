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

        //game.Render()
    }
}
