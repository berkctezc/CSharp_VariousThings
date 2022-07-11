namespace Autofac_ClassLibrary.Utilities;

public class DataAccess : IDataAccess
{
    private readonly ILogger _logger;

    public DataAccess(ILogger logger)
    {
        _logger = logger;
    }

    public void LoadData()
    {
        Console.WriteLine("Loading Data");
        _logger.Log("Loading");
    }

    public void SaveData(string name)
    {
        Console.WriteLine($"Saving {name}");
        _logger.Log("Saving");
    }
}