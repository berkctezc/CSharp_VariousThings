namespace MoqDemo_Library.Logic;

public class PersonProcessor(ISqliteDataAccess database) : IPersonProcessor
{
	public PersonModel CreatePerson(string firstName, string lastName, string heightText)
	{
		PersonModel output = new();

		if (ValidateName(firstName))
			output.FirstName = firstName;
		else
			throw new ArgumentException("The value was not valid", nameof(firstName));

		if (ValidateName(lastName))
			output.LastName = lastName;
		else
			throw new ArgumentException("The value was not valid", nameof(lastName));

		var height = ConvertHeightTextToInches(heightText);

		if (height.isValid)
			output.HeightInInches = height.heightInInches;
		else
			throw new ArgumentException("The value was not valid", "heightText");

		return output;
	}

	public List<PersonModel> LoadPeople()
	{
		var sql = "select * from Person";

		var output = database.LoadData<PersonModel>(sql);

		return output;
	}

	public void SavePerson(PersonModel person)
	{
		var sql = "insert into Person (FirstName, LastName, HeightInInches) " +
				  "values (@FirstName, @LastName, @HeightInInches)";

		sql = sql.Replace("@FirstName", $"'{person.FirstName}'");
		sql = sql.Replace("@LastName", $"'{person.LastName}'");
		sql = sql.Replace("@HeightInInches", $"{person.HeightInInches}");

		database.SaveData(person, sql);
	}

	public void UpdatePerson(PersonModel person)
	{
		var sql = "update Person set FirstName = @FirstName, LastName = @LastName" +
				  ", HeightInInches = @HeightInInches where Id = @Id";

		database.UpdateData(person, sql);
	}

	public (bool isValid, double heightInInches) ConvertHeightTextToInches(string heightText)
	{
		var isValid = true;
		double heightInInches = 0;

		var feetMarkerLocation = heightText.IndexOf('\'');
		var inchesMarkerLocation = heightText.IndexOf('"');

		if (feetMarkerLocation < 0
			|| inchesMarkerLocation < 0
			|| inchesMarkerLocation < feetMarkerLocation)
			return (false, 0);

		// Split on both the feet and inches indicators
		var heightParts = heightText.Split('\'', '"');


		// Part 0 should be feet, part 1 should be inches
		if (int.TryParse(heightParts[0], out var feet) == false
			|| double.TryParse(heightParts[1], out var inches) == false)
			return (false, 0);

		heightInInches = feet * 12 + inches;

		return (isValid, heightInInches);
	}

	private bool ValidateName(string name)
	{
		var output = true;
		var invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

		if (name.Length < 2) output = false;

		if (name.IndexOfAny(invalidCharacters) >= 0) output = false;

		return output;
	}
}