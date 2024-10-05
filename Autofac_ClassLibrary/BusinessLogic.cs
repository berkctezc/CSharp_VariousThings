namespace Autofac_ClassLibrary;

public class BusinessLogic(ILogger logger, IDataAccess dataAccess) : IBusinessLogic
{
    public void ProcessData()
    {
        logger.Log("starting the processing of data");
        Console.WriteLine("processing the data");
        dataAccess.LoadData();
        dataAccess.SaveData("processed info");
        logger.Log("finished processing of data");
    }
}
