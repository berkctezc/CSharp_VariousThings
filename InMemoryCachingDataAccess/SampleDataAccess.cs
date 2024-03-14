namespace InMemoryCachingDataAccess;

public class SampleDataAccess(IMemoryCache cache)
{
	private readonly List<EmployeeModel> Data = new()
	{
		new EmployeeModel("David", "Bowie"),
		new EmployeeModel("Freddie", "Mercury"),
		new EmployeeModel("Alice", "Cooper")
	};

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
		var output = cache.Get<List<EmployeeModel>>("employees");

		if (output is null)
		{
			await Task.Delay(3000);

			cache.Set("employees", Data, TimeSpan.FromMinutes(1));
		}

		return cache.Get<List<EmployeeModel>>("employees");
	}
}
