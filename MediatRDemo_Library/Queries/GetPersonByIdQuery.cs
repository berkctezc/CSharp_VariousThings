using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

#region class

// CLASS EQUIVALENT OF RECORD
public class CLASS_GetPersonByIdQuery : IRequest<PersonModel>
{
    public int Id { get; }

    public CLASS_GetPersonByIdQuery(int id)
    {
        Id = id;
    }
}

#endregion