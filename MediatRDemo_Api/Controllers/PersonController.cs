using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo_Library.Commands;
using MediatRDemo_Library.Models;
using MediatRDemo_Library.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<PersonModel>> GetAll()
    {
        return await _mediator.Send(new GetPersonListQuery());
    }

    [HttpGet("{id}")]
    public async Task<PersonModel> GetById(int id)
    {
        return await _mediator.Send(new GetPersonByIdQuery(id));
    }

    [HttpPost]
    public async Task<PersonModel> AddPersonAsync([FromBody] PersonModel value)
    {
        return await _mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
    }
}