namespace MediatRDemo_Library.Queries;

public class CLASS_GetPersonByIdQuery : IRequest<PersonModel>
{
    public CLASS_GetPersonByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}