namespace Interfaces_ClassLibrary;

public class CourseProductModel : IProductModel
{
	public bool HasOrderBeenCompleted { get; set; }
	public string Title { get; set; }

	public void ShipItem(CustomerModel customer)
	{
		if (!HasOrderBeenCompleted)
		{
			Console.WriteLine($"Added the {Title} course to {customer.FirstName}'s account.");
			HasOrderBeenCompleted = true;
		}
	}
}