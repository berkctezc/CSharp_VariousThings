using System;

namespace Autofac_ClassLibrary.Utilities;

public class Logger : ILogger
{
    public void Log(string message) => Console.WriteLine($"Logging {message}");
}