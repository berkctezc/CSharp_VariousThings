namespace MediatRDemo_Library.Handlers;

public class GetPersonByIdHandler(IMediator mediator)
    : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    public async Task<PersonModel> Handle(
        GetPersonByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        // when working with real data use the proepr DataAccess method instead of this
        var results = await mediator.Send(new GetPersonListQuery(), cancellationToken);

        var output = results.FirstOrDefault(x => x.Id == request.Id);

        return output;
    }
}
