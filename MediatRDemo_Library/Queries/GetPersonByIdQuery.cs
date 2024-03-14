namespace MediatRDemo_Library.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

#region class

// CLASS EQUIVALENT OF RECORD

#endregion
