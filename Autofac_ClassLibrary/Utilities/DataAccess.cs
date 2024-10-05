namespace Autofac_ClassLibrary.Utilities;

public class DataAccess(ILogger logger) : IDataAccess
{
    public void LoadData()
    {
        Console.WriteLine("Loading Data");
        logger.Log("Loading");
    }

    public void SaveData(string name)
    {
        Console.WriteLine($"Saving {name}");
        logger.Log("Saving");
    }
}
