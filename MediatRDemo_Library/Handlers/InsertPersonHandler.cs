using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo_Library.Commands;
using MediatRDemo_Library.DataAccess;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDataAccess _data;

    public InsertPersonHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
    }
}