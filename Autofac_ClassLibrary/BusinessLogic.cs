namespace Autofac_ClassLibrary;

public class BusinessLogic : IBusinessLogic
{
    private readonly IDataAccess _dataAccess;
    private readonly ILogger _logger;

    public BusinessLogic(ILogger logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    public void ProcessData()
    {
        _logger.Log("starting the processing of data");
        Console.WriteLine("processing the data");
        _dataAccess.LoadData();
        _dataAccess.SaveData("processed info");
        _logger.Log("finished processing of data");
    }
}