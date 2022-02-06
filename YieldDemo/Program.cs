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

        foreach (var person in people) Console.WriteLine($"Read {person.Name}");
    }

    private static void Demo2()
    {
        var primeNumbers = Generators.GetPrimeNumbers().Take(10000);

        foreach (var prime in primeNumbers) Console.WriteLine(prime);
    }
}

public static class Generators
{
    public static IEnumerable<int> GetPrimeNumbers()
    {
        // By using yield and .Take() you only get what you need and dont use memory for the data you will not use

        var counter = 1;

        while (true)
        {
            if (IsPrimeNumber(counter)) yield return counter;

            counter++;
        }
    }

    private static bool IsPrimeNumber(int value)
    {
        var output = true;

        for (var i = 2; i < value / 2; i++)
            if (value % i == 0)
            {
                output = false;
                break;
            }

        return output;
    }
}