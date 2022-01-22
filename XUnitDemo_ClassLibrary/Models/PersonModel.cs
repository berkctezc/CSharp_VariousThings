namespace XUnitDemo_ClassLibrary.Models;

public class PersonModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}