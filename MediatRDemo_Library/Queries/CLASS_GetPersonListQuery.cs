using System.Collections.Generic;
using MediatR;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.Queries;

public class CLASS_GetPersonListQuery : IRequest<List<PersonModel>>
{
}