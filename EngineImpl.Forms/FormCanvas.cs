namespace EngineImpl.Forms;

public partial class FormCanvas : Form
{
    Graphics graphics;

    public FormCanvas()
    {
        InitializeComponent();
    }

    private void FormCanvas_Load(object sender, EventArgs e)
    {
        graphics = pictureBoxCanvas.CreateGraphics();
    }
}
