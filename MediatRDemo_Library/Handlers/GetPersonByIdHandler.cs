using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo_Library.Models;
using MediatRDemo_Library.Queries;

namespace MediatRDemo_Library.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            // when working with real data use the proepr DataAccess method instead of this
            var results = await _mediator.Send(new GetPersonListQuery());

            var output = results.FirstOrDefault(x => x.Id == request.Id);

            return output;
        }
    }
}