namespace YieldDemo;

public static class Generators
{
    public static IEnumerable<int> GetPrimeNumbers()
    {
        // By using yield and .Take() you only get what you need and dont use memory for the data you will not use

        var counter = 1;

        while (true)
        {
            if (IsPrimeNumber(counter))
                yield return counter;

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
