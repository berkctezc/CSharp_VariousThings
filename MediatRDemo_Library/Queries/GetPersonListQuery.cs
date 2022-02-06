using System.Collections.Generic;
using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Queries;

public record GetPersonListQuery() : IRequest<List<PersonModel>>;

#region class

// CLASS EQUIVALENT OF RECORD
public class CLASS_GetPersonListQuery : IRequest<List<PersonModel>>
{
}

#endregion