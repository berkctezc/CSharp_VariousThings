using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo_Library.DataAccess;
using MediatRDemo_Library.Models;
using MediatRDemo_Library.Queries;

namespace MediatRDemo_Library.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly IDataAccess _data;

    public GetPersonListHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.GetPeople());
    }
}