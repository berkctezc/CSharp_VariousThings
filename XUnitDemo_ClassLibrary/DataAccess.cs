namespace XUnitDemo_ClassLibrary;

public static class DataAccess
{
	private static readonly string personTextFile = "..\\..\\..\\PersonText.txt";

	public static void AddNewPerson(PersonModel person)
	{
		var people = GetAllPeople();
		AddPersonToPeopleList(people, person);

		var lines = ConvertModelsToCSV(people);

		File.WriteAllLines(personTextFile, lines);
	}

	public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
	{
		if (string.IsNullOrWhiteSpace(person.FirstName))
			throw new ArgumentException("You passed in an invalid parameter", "FirstName");

		if (string.IsNullOrWhiteSpace(person.LastName))
			throw new ArgumentException("You passed in an invalid parameter", "LastName");

		people.Add(person);
	}

	public static List<string> ConvertModelsToCSV(List<PersonModel> people)
	{
		List<string> output = new();

		foreach (var user in people)
			output.Add($"{user.FirstName},{user.LastName}");

		return output;
	}

	public static List<PersonModel> GetAllPeople()
	{
		List<PersonModel> output = new();
		var content = File.ReadAllLines(personTextFile);

		foreach (var line in content)
		{
			var data = line.Split(',');
			output.Add(new PersonModel {FirstName = data[0], LastName = data[1]});
		}

		return output;
	}
}