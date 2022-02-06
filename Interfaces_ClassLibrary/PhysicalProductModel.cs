using System;

namespace Interfaces_ClassLibrary;

public class PhysicalProductModel : IProductModel
{
    public string Title { get; set; }
    public bool HasOrderBeenCompleted { get; set; }

    public void ShipItem(CustomerModel customer)
    {
        if (HasOrderBeenCompleted == false)
        {
            Console.WriteLine($"Simulating shipping {Title} to {customer.FirstName} in {customer.City}");
            Console.WriteLine("========");

            HasOrderBeenCompleted = false;
        }
    }
}