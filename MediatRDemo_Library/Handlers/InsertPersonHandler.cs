namespace MediatRDemo_Library.Handlers;

public class InsertPersonHandler(IDataAccess data) : IRequestHandler<InsertPersonCommand, PersonModel>
{
    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(data.InsertPerson(request.FirstName, request.LastName));
    }
}