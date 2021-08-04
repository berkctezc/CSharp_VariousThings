using System;

namespace Interfaces_ClassLibrary
{
    public class DigitalProductModel : IDigitalProductModel
    {
        public string Title { get; set; }
        public bool HasOrderBeenCompleted { get; private set; }
        public int TotalDownloadsLeft { get; private set; } = 5;
         
        public void ShipItem(CustomerModel customer)
        {
            Console.WriteLine($"Simulating shipping {Title} to {customer.FirstName} in {customer.City}");
            Console.WriteLine("========");

            TotalDownloadsLeft -= 1;
            if (TotalDownloadsLeft < 1)
            {
                HasOrderBeenCompleted = true;
                TotalDownloadsLeft = 0;
            }

        }
    }
}
