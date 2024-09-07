namespace MediatRDemo_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<List<PersonModel>> GetAll()
	{
		return await mediator.Send(new GetPersonListQuery());
	}

	[HttpGet("{id}")]
	public async Task<PersonModel> GetById(int id)
	{
		return await mediator.Send(new GetPersonByIdQuery(id));
	}

	[HttpPost]
	public async Task<PersonModel> AddPersonAsync([FromBody] PersonModel value)
	{
		return await mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
	}
}
