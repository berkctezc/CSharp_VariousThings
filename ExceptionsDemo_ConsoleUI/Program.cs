using System;
using ExceptionsDemo_Library;

namespace ExceptionsDemo_ConsoleUI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var demo = new DemoCode();

            // higher the better to put try catch (UI)
            try
            {
                var result = demo.GrandparentMethod(4);
                Console.WriteLine($"The value at the given pos is {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Bad argument given!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                // access to inner exception and its data
                var inner = ex.InnerException;

                while (inner != null)
                {
                    Console.WriteLine(inner.StackTrace);
                    inner = inner.InnerException;
                }
            }
        }
    }
}
