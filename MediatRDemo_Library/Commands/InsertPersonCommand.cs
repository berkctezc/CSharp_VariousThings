namespace MediatRDemo_Library.Commands;

public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

#region class

#endregion
