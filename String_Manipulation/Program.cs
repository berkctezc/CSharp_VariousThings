using System;
using System.Globalization;

namespace String_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            StringConversion();
            StringAsArray();
            EscapeString();
            AppendingStrings();
        }

        private static void StringConversion()
        {
            string testString = "tHis iS tHe FBI Calling";
            Console.WriteLine(
                testString + "\n" +
                testString.ToLower() + "\n" +
                testString.ToUpper() + "\n" +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(testString) + "\n" +
                new CultureInfo("tr-TR", false).TextInfo.ToTitleCase(testString) + "\n" + "");
            Console.WriteLine();
        }

        private static void StringAsArray()
        {
            // array operations can be done on strings
            string testString = "Berkcan";

            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }
            Console.WriteLine();
        }

        private static void EscapeString()
        {
            string results;

            //escape character
            results = "This is my \"test\" solution ";
            Console.WriteLine(results);

            //string literals
            results = @"C:\Demo\Test.txt";
            Console.WriteLine(results);

            Console.WriteLine();
        }

        private static void AppendingStrings()
        {
            string firstName = "Berkcan";
            string lastName = "Tezcaner";
            string results;

            results = firstName + ", my name is " + firstName + " " + lastName;
            Console.WriteLine(results);

            results = string.Format("{0}, my name is {0} {1}", firstName, lastName);
            Console.WriteLine(results);

            results = $"{firstName}, my name is {firstName} {lastName}";
            Console.WriteLine(results);

            Console.WriteLine();
        }
    }
}
