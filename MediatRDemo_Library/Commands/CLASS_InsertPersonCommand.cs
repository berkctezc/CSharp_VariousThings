namespace MediatRDemo_Library.Commands;

public class ClassInsertPersonCommand(string firstName, string lastName) : IRequest<PersonModel>
{
	public string FirstName { get; set; } = firstName;
	public string LastName { get; set; } = lastName;
}