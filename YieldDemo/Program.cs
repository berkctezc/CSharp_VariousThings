namespace YieldDemo;

internal static class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Start");

		Demo1();

		Console.WriteLine("=====");

		Demo2();

		Console.WriteLine("End");
	}

	private static void Demo1()
	{
		var people = DataAccess.GetPeople().Take(4);

		foreach (var person in people)
			Console.WriteLine($"Read {person.Name}");
	}

	private static void Demo2()
	{
		var primeNumbers = Generators.GetPrimeNumbers().Take(10000);

		foreach (var prime in primeNumbers)
			Console.WriteLine(prime);
	}
}
