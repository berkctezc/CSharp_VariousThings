using System;

namespace Interfaces_ClassLibrary;

public class CustomerModel : ICustomerModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}

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