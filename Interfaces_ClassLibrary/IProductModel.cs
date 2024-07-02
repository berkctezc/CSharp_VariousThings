namespace Interfaces_ClassLibrary;

public interface IProductModel
{
	string Title { get; set; }
	bool HasOrderBeenCompleted { get; }

	void ShipItem(CustomerModel customer);
}