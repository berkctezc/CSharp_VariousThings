using System;
using Autofac_ClassLibrary.Utilities;

namespace Autofac_ClassLibrary;

public class BusinessLogic : IBusinessLogic
{
    private readonly ILogger _logger;
    private readonly IDataAccess _dataAccess;
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

public class BetterBusinessLogic : IBusinessLogic
{
    public void ProcessData()
    {
        Console.WriteLine("processing data with better business logic");
    }
}