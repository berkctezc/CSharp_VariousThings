using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Queries;

public class CLASS_GetPersonByIdQuery : IRequest<PersonModel>
{
    public int Id { get; }

    public CLASS_GetPersonByIdQuery(int id)
    {
        Id = id;
    }
}