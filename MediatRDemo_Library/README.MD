# Working with MediatR to Implement CQRS (Command-Query Responsibility Segregation) and Mediator Pattern

## Data Access

- Firstly we need to create Data Access and models. In this project we used a fake In Memory database with two methods (Read and Create).
- *todo: move this to SQLite and Dapper.*

```cs
namespace Library.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new List<PersonModel>();
        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "David", LastName = "Bowie" });
            people.Add(new PersonModel { Id = 2, FirstName = "Angus", LastName = "Young" });
        }
        public List<PersonModel> GetPeople()
        {
            // use normal dataaccess methods here dapper, ef ...
            return people;
        }
        public PersonModel InsertPerson(string fname, string lname)
        {
            PersonModel personToCreate = new PersonModel() { FirstName = fname, LastName = lname };
            personToCreate.Id = people.Max(x => x.Id) + 1;
            people.Add(personToCreate);

            return personToCreate;
        }
    }
}
```

## Creating Queries and their Handlers

- Install **MediatR** NuGet package to project.
- Create Queries (As Record or Class) with `<QueryName>Query` naming convention for easy understanding and separation between handlers and commands.
- Queries should implement **IRequest<>** with return type.

```cs
namespace Library.Queries
{
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;

    #region class 
        // CLASS EQUIVALENT OF RECORD
        public class CLASS_GetPersonListQuery : IRequest<List<PersonModel>>
        {}
    #endregion
}
```

- A Query with parameter

```cs
namespace Library.Queries
{
    public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

    #region class 
    // CLASS EQUIVALENT OF RECORD
    public class CLASS_GetPersonByIdQuery : IRequest<PersonModel>
    {
        public int Id { get; }
        public CLASS_GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
    #endregion
}
```

- Create Handlers that implement **IRequestHandler** that with Query that should Handler handle and return type.
- Inject Data Access in Handler
- In Handle method access to Data Access method

```cs
namespace Library.Handlers
{
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
}
```

- A Handler with parameter

```cs
namespace Library.Handlers
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
```

## Creating Commands and Handlers

- Create commands same as queries

```cs
namespace Library.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName):IRequest<PersonModel>;

    #region class
        public class CLASS_InsertPersonCommand : IRequest<PersonModel>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public CLASS_InsertPersonCommand(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }
    #endregion
}
```

- Create handlers

```cs
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
```

## Calling from another service or layer (API)

- Install MediatR Dependency Injection package to layer from NuGet (**MediatR.Extensions.Microsoft.DependencyInjection**)

- Inject **Data Access** and add **MediatR** service in **ConfigureServices**

```cs
services.AddSingleton<IDataAccess, DemoDataAccess>();
services.AddMediatR(typeof(LibraryMediatREntrypoint).Assembly);
```

- And in controller inject **IMediator** as _mediator send requests to query 

```cs
namespace Api.Controllers
{
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
}
```

- That is it. Notice the mediatr decreases we need to make in Startup class of api and lets say that we need to create a blazor project, wpf project. In all of them the things we will need to do and implement will stay the same and we could focus on the Logic & DataAccess layer for testing and adding stuff.
- Resources used : Tim Corey https://www.youtube.com/watch?v=yozD5Tnd8nw

