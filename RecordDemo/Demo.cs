namespace RecordDemo;

public class Demo
{
	// Immutable - the values cannot be changed
	public record Record1(string FirstName, string LastName);

	public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName);

	public record Record2(string FirstName, string LastName)
	{
		private readonly string _firstName = FirstName;

		public string FirstName
		{
			get => _firstName[..1] + "...";
			init { }
		}

		// public string FirstName { get; init; } = FirstName;
		public string FullName => $"{FirstName} {LastName}";

		public string Greet()
		{
			return $"Hello {FirstName}";
		}
	}

	public class Class1(string firstName, string lastName)
	{
		public string FirstName { get; init; } = firstName;

		public string LastName { get; init; } = lastName;
	}
}
