async Task Demo1(ChannelBase channel)
{
	var input = new HelloRequest {Name = "Berkc"};

	var client = new Greeter.GreeterClient(channel);

	var reply = await client.SayHelloAsync(input);

	Console.WriteLine(reply.Message);
}

const string serverUri = "http://localhost:5001";
var channel = GrpcChannel.ForAddress(serverUri);

await Demo1(channel);

Console.WriteLine("----");

var customerClient = new Customer.CustomerClient(channel);

var clientRequested = new CustomerLookupModel {UserId = 1};

var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

Console.WriteLine($"{customer.FirstName} {customer.LastName}");

using var call = customerClient.GetNewCustomers(new NewCustomerRequest());
while (await call.ResponseStream.MoveNext())
{
	var currentCustomer = call.ResponseStream.Current;
	Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} {currentCustomer.EmailAddress} {currentCustomer.Age} {currentCustomer.IsAlive}");
}
