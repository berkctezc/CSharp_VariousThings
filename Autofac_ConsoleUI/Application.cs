using Autofac_ClassLibrary;

namespace Autofac_ConsoleUI;

public interface IApplication
{
    void Run();
}

public class Application : IApplication
{
    private readonly IBusinessLogic _businessLogic;

    public Application(IBusinessLogic businessLogic)
    {
        _businessLogic = businessLogic;
    }

    public void Run()
    {
        _businessLogic.ProcessData();
    }
}