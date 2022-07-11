using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Commands;

public class CLASS_InsertPersonCommand : IRequest<PersonModel>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CLASS_InsertPersonCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}