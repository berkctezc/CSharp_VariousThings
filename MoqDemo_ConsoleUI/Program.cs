namespace MoqDemo_ConsoleUI;

internal static class Program
{
	private static void Main(string[] args)
	{
		var container = ContainerConfig.Configure();

		using var scope = container.BeginLifetimeScope();
		var app = scope.Resolve<IApplication>();
		app.Run();
	}
}