﻿namespace Interfaces_ClassLibrary;

public class CustomerModel : ICustomerModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}