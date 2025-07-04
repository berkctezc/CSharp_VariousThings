namespace MediatRDemo_Library.DataAccess;

public class DemoDataAccess : IDataAccess
{
	private readonly List<PersonModel> _people = new();

	public DemoDataAccess()
	{
		_people.Add(
			new PersonModel
			{
				Id = 1,
				FirstName = "David",
				LastName = "Bowie"
			}
		);
		_people.Add(
			new PersonModel
			{
				Id = 2,
				FirstName = "Angus",
				LastName = "Young"
			}
		);
	}

	public List<PersonModel> GetPeople()
	{
		// use normal dataaccess methods here dapper, ef ...
		return _people;
	}

	public PersonModel InsertPerson(string fname, string lname)
	{
		PersonModel personToCreate = new();
		personToCreate.Id = _people.Max(x => x.Id) + 1;
		_people.Add(personToCreate);

		return personToCreate;
	}
}