namespace GrpcServer.Services;

public class CustomersService(ILogger<CustomersService> logger) : Customer.CustomerBase
{
	private readonly ILogger<CustomersService> _logger = logger;

	public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
	{
		var output = new CustomerModel();

		switch (request.UserId)
		{
			case 1:
				output.FirstName = "Test1";
				output.LastName = "Test1";
				break;
			case 2:
				output.FirstName = "Test2";
				output.LastName = "Test2";
				break;
		}

		return Task.FromResult(output);
	}

	public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
	{
		var customers = new List<CustomerModel>
		{
			new() {FirstName = "A", Age = 4},
			new() {IsAlive = false, FirstName = "B"},
			new() {FirstName = "C", EmailAddress = "d"}
		};

		foreach (var c in customers)
		{
			await Task.Delay(500);
			await responseStream.WriteAsync(c);
		}
	}
}