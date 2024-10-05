namespace MediatRDemo_Library.Queries;

public class CLASS_GetPersonByIdQuery(int id) : IRequest<PersonModel>
{
    public int Id { get; } = id;
}
