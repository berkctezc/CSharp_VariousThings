namespace InMemoryCachingDataAccess;

public class SampleDataAccess
{
    private readonly IMemoryCache _cache;

    private readonly List<EmployeeModel> Data = new()
    {
        new EmployeeModel("David", "Bowie"),
        new EmployeeModel("Freddie", "Mercury"),
        new EmployeeModel("Alice", "Cooper")
    };

    public SampleDataAccess(IMemoryCache cache)
    {
        _cache = cache;
    }

    public List<EmployeeModel> GetEmployees()
    {
        Thread.Sleep(3000);

        return Data;
    }

    public async Task<List<EmployeeModel>> GetEmployeesAsync()
    {
        await Task.Delay(3000);

        return Data;
    }

    public async Task<List<EmployeeModel>?> GetEmployeesCache()
    {
        var output = _cache.Get<List<EmployeeModel>>("employees");

        if (output is null)
        {
            await Task.Delay(3000);

            _cache.Set("employees", Data, TimeSpan.FromMinutes(1));
        }

        return _cache.Get<List<EmployeeModel>>("employees");
    }
}