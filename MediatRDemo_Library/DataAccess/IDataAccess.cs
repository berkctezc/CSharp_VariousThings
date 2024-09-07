namespace MediatRDemo_Library.DataAccess;

public interface IDataAccess
{
	List<PersonModel> GetPeople();
	PersonModel InsertPerson(string fname, string lname);
}
