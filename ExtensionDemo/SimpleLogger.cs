namespace ExtensionDemo;

public class SimpleLogger : ISimpleLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void Log(string message, string messageType)
    {
        Log($"{messageType}: {message}");
    }
}