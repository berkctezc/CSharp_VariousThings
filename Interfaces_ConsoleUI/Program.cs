namespace Interfaces_ConsoleUI;

internal class Program
{
	private static void Main(string[] args)
	{
		var cart = AddSampleData();
		var customer = GetCustomer();

		foreach (var prod in cart)
		{
			prod.ShipItem(customer);

			if (prod is IDigitalProductModel digital)
				Console.WriteLine(
					$"For the {digital.Title} you have {digital.TotalDownloadsLeft} downloads left."
				);
		}
	}

	private static CustomerModel GetCustomer()
	{
		return new CustomerModel
		{
			FirstName = "Berkcan",
			LastName = "Tezcaner",
			City = "Istanbul",
			EmailAddress = "berkcantezcaner@gmail.com",
			PhoneNumber = "1234567"
		};
	}

	private static List<IProductModel> AddSampleData()
	{
		var output = new List<IProductModel>();

		output.Add(new PhysicalProductModel {Title = "Earbuds"});
		output.Add(new PhysicalProductModel {Title = "Gym Membership Card"});
		output.Add(new PhysicalProductModel {Title = "Tripod"});

		output.Add(new DigitalProductModel {Title = "Amazon Membership"});
		output.Add(new DigitalProductModel {Title = "WinRar Software Key"});

		var digitalProduct = new DigitalProductModel {Title = "A Digital Video Game"};
		output.Add(digitalProduct);
		output.Add(digitalProduct);
		output.Add(digitalProduct);
		output.Add(digitalProduct);
		output.Add(digitalProduct);

		output.Add(new CourseProductModel {Title = ".NET Core Programming"});

		return output;
	}
}