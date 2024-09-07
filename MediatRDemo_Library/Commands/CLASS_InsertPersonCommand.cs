namespace MediatRDemo_Library.Commands;

public class CLASS_InsertPersonCommand(string firstName, string lastName) : IRequest<PersonModel>
{
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
}
