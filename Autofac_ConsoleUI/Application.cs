namespace Autofac_ConsoleUI;

public class Application(IBusinessLogic businessLogic) : IApplication
{
	public void Run()
	{
		businessLogic.ProcessData();
	}
}
