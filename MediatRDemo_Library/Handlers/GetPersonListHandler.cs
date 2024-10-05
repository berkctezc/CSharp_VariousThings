namespace MediatRDemo_Library.Handlers;

public class GetPersonListHandler(IDataAccess data)
    : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    public Task<List<PersonModel>> Handle(
        GetPersonListQuery request,
        CancellationToken cancellationToken
    )
    {
        return Task.FromResult(data.GetPeople());
    }
}
