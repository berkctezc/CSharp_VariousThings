using System;

namespace ExtensionDemo;

internal class Program
{
    private static void Main(string[] args)
    {
        "this is a demo".PrintToConsole();

        ISimpleLogger logger = new SimpleLogger();

        logger.LogError("This is an error");
        logger.LogWarning("This is an error");

        Console.WriteLine("good bye");
    }
}