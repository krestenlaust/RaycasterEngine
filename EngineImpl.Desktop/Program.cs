using System.Drawing;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.OpenGL;

namespace EngineImpl.Desktop;

public class Program
{
	private static IWindow window;
	private static GL gl;

	public static void Main(string[] args)
	{
		var options = WindowOptions.Default;
		options = WindowOptions.Default with
		{
			Title = "Raycaster Demo"
		};
		window = Window.Create(options);

		window.Load += OnLoad;
		window.Update += OnUpdate;
		window.Render += OnRender;

		window.Run();
	}

	private static void OnLoad()
	{
		gl = window.CreateOpenGL();
		Console.WriteLine("Load!");
	}

	private static void OnUpdate(double deltaTime)
	{

	}

	private static void OnRender(double deltaTime)
	{

	}
}

