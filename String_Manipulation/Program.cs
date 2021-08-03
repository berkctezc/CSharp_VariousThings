using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace String_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START POINT");
            StringConversion();
            StringAsArray();
            EscapeString();
            AppendingStrings();
            InterpolationAndLiteral();
            StringBuilderDemo();
            WorkingWithArrays();
            PadAndTrim();
            SearchingString();
            OrderingStrings();
            TestingEquality();
            GettingASubstring();
            ReplacingText();
            InsertingText();
            RemovingText();
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

            Console.WriteLine(seperator);
        }

        private static void StringAsArray()
        {
            // array operations can be done on strings
            string testString = "Berkcan";

            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }

            Console.WriteLine(seperator);
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

            Console.WriteLine(seperator);
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

            Console.WriteLine(seperator);
        }

        private static void InterpolationAndLiteral()
        {
            string testString = "Berkcan Tezcaner";
            string results = $@"C:\Demo\{testString}\{"\""}Test{"\""}.txt";
            Console.WriteLine(results);

            Console.WriteLine(seperator);
        }

        private static void StringBuilderDemo()
        {
            int iterations = 30000;
            Stopwatch regularStopwatch = new();
            regularStopwatch.Start();

            string test = "";

            for (int i = 0; i < iterations; i++)
            {
                test += i;
            }
            regularStopwatch.Stop();


            Stopwatch builderStopwatch = new();
            builderStopwatch.Start();

            StringBuilder sb = new();

            for (int i = 0; i < iterations; i++)
            {
                sb.Append(i);
            }
            builderStopwatch.Stop();

            Console.WriteLine($"Regular Stopwatch: {regularStopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"Builder Stopwatch: {builderStopwatch.ElapsedMilliseconds}ms");

            Console.WriteLine(seperator);
        }

        private static void WorkingWithArrays()
        {
            int[] ages = new int[] { 6, 7, 8, 3, 5 };
            string results;

            results = String.Concat(ages);
            Console.WriteLine(results);

            results = String.Join(",", ages);
            Console.WriteLine(results);

            string testString = "Ali,Veli,Ayşe,Fatma";
            string[] resultsArray = testString.Split(','); // use character or string with multiple characters like a comma with space (", ")

            Array.ForEach(resultsArray, x => Console.WriteLine(x));

            Console.WriteLine(seperator);
        }

        private static void PadAndTrim()
        {
            string testString = "    Hello World   ";
            string results;

            results = testString.Trim(); // TrimStart, TrimEnd
            Console.WriteLine($"|{results}|");


            // only chars are acceptible
            testString = "1.15";
            results = testString.PadLeft(10, '*'); // add *s to left till string length is 10
            Console.WriteLine(results);

            testString = "1.15";
            results = testString.PadRight(10, '0'); // add 0s till string length is 10
            Console.WriteLine(results);

            Console.WriteLine(seperator);
        }

        private static void SearchingString()
        {
            string testString = "This is a test of the search. Let's see how its testing works out.";
            bool resultsBoolean;
            int resultsInt;

            resultsBoolean = testString.StartsWith("This is");
            Console.WriteLine($"Starts with \"This is\": {resultsBoolean} ");

            resultsBoolean = testString.StartsWith("ThIs is");
            Console.WriteLine($"Starts with \"ThIs is\": {resultsBoolean} ");

            resultsBoolean = testString.EndsWith("works out.");
            Console.WriteLine($"Ends with \"works out.\": {resultsBoolean} ");

            resultsBoolean = testString.EndsWith("work out.");
            Console.WriteLine($"Ends with \"works out.\": {resultsBoolean} ");

            resultsBoolean = testString.Contains("test");
            Console.WriteLine($"Contains with \"test\": {resultsBoolean} ");

            resultsBoolean = testString.Contains("tests");
            Console.WriteLine($"Contains with \"tests\": {resultsBoolean} ");

            resultsInt = testString.IndexOf("test");
            Console.WriteLine($"Index of \"test\": {resultsInt}");

            resultsInt = testString.IndexOf("test", 11);
            Console.WriteLine($"Index of \"test\" after character 10: {resultsInt}");

            resultsInt = testString.IndexOf("test", 48);
            Console.WriteLine($"Index of \"test\" after character 48: {resultsInt}"); // returns -1 meaning not found

            resultsInt = testString.LastIndexOf("test"); // starts from end
            Console.WriteLine($"Last Index of \"test\": {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 48);
            Console.WriteLine($"Last Index of \"test\" before character 48: {resultsInt}");

            resultsInt = testString.IndexOf("test", 10);
            Console.WriteLine($"Index of \"test\" before character 10: {resultsInt}"); // returns -1 meaning not found

            Console.WriteLine(seperator);
        }

        private static void OrderingStrings()
        {
            CompareToHelper("Mary", "Bob");
            CompareToHelper("Mary", null);
            CompareToHelper("Adam", "Bob");
            CompareToHelper("Bob", "Bob");
            CompareToHelper("Bob", "Bobby");

            Console.WriteLine("----");

            CompareHelper("Mary", "Bob");
            CompareHelper("Mary", null);
            CompareHelper(null, "Bob");
            CompareHelper("Adam", "Bob");
            CompareHelper("Bob", "Bob");
            CompareHelper("Bob", "Bobby");
            CompareHelper(null, null);

            Console.WriteLine(seperator);
        }

        private static void CompareToHelper(string testA, string? testB)
        {
            int resultsInt = testA.CompareTo(testB);
            switch (resultsInt)
            {
                case > 0:
                    Console.WriteLine($"CompareTo: {testB ?? "null"} comes before {testA}");
                    break;
                case < 0:
                    Console.WriteLine($"CompareTo: {testA} comes before {testB}");
                    break;
                case 0:
                    Console.WriteLine($"CompareTo: {testA} is the same as {testB}");
                    break;
            }
        }

        private static void CompareHelper(string? testA, string? testB)
        {
            int resultsInt = String.Compare(testA, testB);
            switch (resultsInt)
            {
                case > 0:
                    Console.WriteLine($"Compare: {testB ?? "null"} comes before {testA}");
                    break;
                case < 0:
                    Console.WriteLine($"Compare: {testA ?? "null"} comes before {testB}");
                    break;
                case 0:
                    Console.WriteLine($"Compare: {testA ?? "null"} is the same as {testB ?? "null"}");
                    break;
            }

        }

        private static void TestingEquality()
        {
            EqualityHelper("Bob", "Mary");
            EqualityHelper(null, "");
            EqualityHelper("", " ");
            EqualityHelper("Bob", "bob");
        }

        private static void EqualityHelper(string? testA, string? testB)
        {
            bool resultsBoolean;

            resultsBoolean = string.Equals(testA, testB);
            if (resultsBoolean)
            {
                Console.WriteLine($"Equals: '{testA ?? "null"}' equals '{testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($"Equals: '{testA ?? "null"}' does not equal '{testB ?? "null"}'");
            }

            resultsBoolean = string.Equals(testA, testB, StringComparison.InvariantCultureIgnoreCase);
            if (resultsBoolean)
            {
                Console.WriteLine($"Equals (ignore case): '{testA ?? "null"}' equals '{testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($"Equals (ignore case): '{testA ?? "null"}' does not equal '{testB ?? "null"}'");
            }

            resultsBoolean = testA == testB;
            if (resultsBoolean)
            {
                Console.WriteLine($"==: '{testA ?? "null"}' equals '{testB ?? "null"}'");
            }
            else
            {
                Console.WriteLine($"==: '{testA ?? "null"}' does not equal '{testB ?? "null"}'");
            }
            Console.WriteLine("---");
        }

        private static void GettingASubstring()
        {
            string testString = "This is a test of substring. Let's see how its testing works out.";
            string results;

            results = testString.Substring(5); // start from 5 to end
            Console.WriteLine(results);

            results = testString.Substring(5, 4);  // start from 5 , go 4 characters
            Console.WriteLine(results);


            Console.WriteLine(seperator);
        }

        private static void ReplacingText()
        {
            string testString = "This is a test of replace. Let's see how its testing Works out for test.";
            string results;

            results = testString.Replace("test", "trial");
            Console.WriteLine(results);

            results = testString.Replace(" test ", " trial ");
            Console.WriteLine(results);

            results = testString.Replace("works", "makes", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine(results);

            Console.WriteLine(seperator);
        }

        private static void InsertingText()
        {
            string testString = "This is a test of insert. Let's see how its testing Works out for test.";
            string results;

            results = testString.Insert(5, "(test) ");
            Console.WriteLine(results);
        }

        private static void RemovingText()
        {
            string testString = "This is a test of remove. Let's see how its testing Works out for test.";
            string results;

            results = testString.Remove(25);
            Console.WriteLine(results);

            results = testString.Remove(14,10);
            Console.WriteLine(results);
        }


        //  variables
        public static string seperator = "===========";
    }
}
