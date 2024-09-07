namespace MoqDemo_Library.Models;

public class PersonModel
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public double HeightInInches { get; set; }

	public string FullName => $"{FirstName} {LastName}";
}
