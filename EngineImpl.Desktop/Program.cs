using Silk.NET.Windowing;
using Silk.NET.Maths;

namespace EngineImpl.Desktop;

public class Program
{
	private static IWindow window;

	public static void Main(string[] args)
	{
		var options = WindowOptions.Default;
		options = WindowOptions.Default with
		{
			Title = "Raycaster Demo"
		};
		window = Window.Create(options);

		window.Run();
	}
}

