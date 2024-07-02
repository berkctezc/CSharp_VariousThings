namespace MediatRDemo_Library.DataAccess;

public class DemoDataAccess : IDataAccess
{
	private readonly List<PersonModel> people = new();

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
		PersonModel personToCreate = new();
		personToCreate.Id = people.Max(x => x.Id) + 1;
		people.Add(personToCreate);

		return personToCreate;
	}
}