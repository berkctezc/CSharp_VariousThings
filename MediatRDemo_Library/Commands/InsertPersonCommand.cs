using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

    #region class
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
    #endregion
}