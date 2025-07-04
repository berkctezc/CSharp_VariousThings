Run();

static void Run()
{
	OptimizationAndSecurity();
	CapturingAndBalancingGroups();
	UnicodeAndCulture();
	AdvancedTopics();
	AnchorsAndBoundaries();
	RegexOptions();
	LookaheadsLookBehindsAndPruning();
	BacktrackingAndRunaways();
	GroupingAndSubstitution();
	CharacterClasses();
	Alternation();
	GroupingConstructs();
	BackreferenceConstructs();
	Pruning();
	PatternMatching();
	StringSplitting();
	PatternMatching2();
	Demo();
}

static void OptimizationAndSecurity()
{
	Console.WriteLine("Interpreted Regex:");
	const string input = "The quick brown fox jumps over the lazy dog.";
	var timer = new Stopwatch();
	timer.Start();
	var interpretedRegex = new Regex("(fox|dog)*");
	for (var i = 0; i < 1000000; i++)
	{
		Console.WriteLine(interpretedRegex.Match(input));
	}

	timer.Stop();
	Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds.ToString());
	Console.WriteLine("\tCache size: {0}", Regex.CacheSize.ToString());

	Console.WriteLine("Compiled Regex:");
	timer.Reset();
	timer.Start();
	var compiledRegex = new Regex(
		"(fox|dog)*",
		System.Text.RegularExpressions.RegexOptions.Compiled
	);
	for (var i = 0; i < 1000000; i++)
	{
		Console.WriteLine(compiledRegex.Match(input));
	}

	timer.Stop();
	Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds.ToString());

	Console.WriteLine("Slow Regex:");
	timer.Reset();
	timer.Start();
	Console.WriteLine(
		Regex.IsMatch("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "(a+(aa)+(aaa)+(aa)+a+)+b.")
	);
	timer.Stop();
	Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds.ToString());

	Console.WriteLine("Non-Capturing Regex:");
	timer.Reset();
	timer.Start();
	Console.WriteLine(
		Regex.IsMatch(
			"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
			"(?:a+(?:aa)+(?:aaa)+(?:aa)+a+)+b."
		)
	);
	timer.Stop();
	Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds.ToString());

	Console.WriteLine("Lazy Regex:");
	timer.Reset();
	timer.Start();
	Console.WriteLine(Regex.IsMatch("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "a+?b."));
	timer.Stop();
	Console.WriteLine("\tElapsed time: {0}ms", timer.ElapsedMilliseconds.ToString());

	Console.WriteLine("Timed Regex:");
	var timedRegex = new Regex(
		"(a+(aa)+(aaa)+(aa)+a+)+b.",
		System.Text.RegularExpressions.RegexOptions.None,
		TimeSpan.FromSeconds(1)
	);
	try
	{
		Console.WriteLine(timedRegex.IsMatch("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"));
	}
	catch (RegexMatchTimeoutException)
	{
		Console.WriteLine("\tThe match timed out.");
	}

	Console.ReadKey();
}

static void CapturingAndBalancingGroups()
{
	var input = "µ"; // Micro Sign
	var pattern = "μ"; // Greek Small Letter Mu

	Console.WriteLine("Micro and Mu Symbols:");
	Console.WriteLine(
		"\tDoes {0} match {1}? {2}",
		pattern,
		input,
		Regex.IsMatch(input, pattern).ToString()
	);

	Console.WriteLine("\tInput's code point: {0}", GetCodePoint(input, 0));
	Console.WriteLine("\tPattern's code point: {0}", GetCodePoint(pattern, 0));

	input = "مرحبا بالعالم مرحبا"; // مرحبا means hello and بالعالم means world, as read from right to left.
	pattern = @"مرحبا"; // مرحبا means hello.

	Console.WriteLine("Right to Left Option:");
	Console.WriteLine("\tWithout the RightToLeft option:");
	foreach (Match match in Regex.Matches(input, pattern))
	{
		Console.WriteLine(
			"\t\tMatch at index {0} of length {1}",
			match.Index.ToString(),
			match.Length.ToString()
		);
	}

	Console.WriteLine("\tWith the RightToLeft option:");
	foreach (
		Match match in Regex.Matches(
			input,
			pattern,
			System.Text.RegularExpressions.RegexOptions.RightToLeft
		)
	)
	{
		Console.WriteLine(
			"\t\tMatch at index {0} of length {1}",
			match.Index.ToString(),
			match.Length.ToString()
		);
	}

	input = "Hello world.";
	var patterns = new List<string> {@"\b\w+\b", @"\b(\w)+\b"};
	Console.WriteLine("Captures:");
	foreach (var examplePattern in patterns)
	{
		Console.WriteLine("\tInput: {0}", input);
		Console.WriteLine("\tPattern: {0}", examplePattern);
		foreach (Match match in Regex.Matches(input, examplePattern))
		{
			Console.WriteLine(
				"\t\t{0}: Match at index {1} of length {2}",
				match.Value,
				match.Index.ToString(),
				match.Length.ToString()
			);
			foreach (Group group in match.Groups)
			{
				Console.WriteLine(
					"\t\t\t{0}: Group at index {1} of length {2}",
					group.Value,
					group.Index.ToString(),
					group.Length.ToString()
				);
				foreach (Capture capture in group.Captures)
					Console.WriteLine(
						"\t\t\t\t{0}: Capture at index {1} of length {2}",
						capture.Value,
						capture.Index.ToString(),
						capture.Length.ToString()
					);
			}
		}
	}

	input = @"{}";
	pattern = @"^((?:[^{}]*)|(?<Open>{)|(?<-Open>}))*$";
	Console.WriteLine("Balancing Groups:");
	Console.WriteLine("\tInput: {0}", input);
	Console.WriteLine("\tPattern: {0}", pattern);
	Console.WriteLine("\tIs {0} balanced? {1}", input, Regex.IsMatch(input, pattern).ToString());
	input = @"{}}";
	Console.WriteLine("\tIs {0} balanced? {1}", input, Regex.IsMatch(input, pattern).ToString());
	input = @"{}{";
	Console.WriteLine("\tIs {0} balanced? {1}", input, Regex.IsMatch(input, pattern).ToString());
	input = @"}{";
	Console.WriteLine("\tIs {0} balanced? {1}", input, Regex.IsMatch(input, pattern).ToString());
	input = @"{ {} {   }}";
	Console.WriteLine("\tIs {0} balanced? {1}", input, Regex.IsMatch(input, pattern).ToString());

	Console.WriteLine("Nested Captures:");
	input = @"{ 1 { 2 3 } { 4 { 5 } 6 } 7 }";
	pattern = @"^((?:[^{}]*)|(?<Open>{)|(?<Contents-Open>}))*(?(Open)(?!))$";

	Console.WriteLine("\tInput: {0}", input);
	Console.WriteLine("\tPattern: {0}", pattern);
	var matches = Regex.Matches(input, pattern);
	var contents = matches[0].Groups["Contents"];
	Console.WriteLine("\t{0} Group:", contents.Name);
	foreach (Capture capture in contents.Captures)
		Console.WriteLine(
			"\t\t{0}: Capture at index {1} of length {2}",
			capture.Value,
			capture.Index.ToString(),
			capture.Length.ToString()
		);

	Console.ReadKey();
}

static void UnicodeAndCulture()
{
	var input = "❌";

	Console.WriteLine("Cross Mark");
	Console.WriteLine("\tCode point: {0}", GetCodePoint(input, 0));
	Console.WriteLine("\tLength: {0}", input.Length.ToString());

	Console.WriteLine(
		"\tDoes the input match \\u274C? {0}",
		Regex.IsMatch(input, "\u274C").ToString()
	);

	Console.WriteLine("\tIs in Dingbats? {0}", Regex.IsMatch(input, @"\p{IsDingbats}").ToString()); // Dingbats are from U+2700 to U+27BF.
	Console.WriteLine(
		"\tIs not in Dingbats? {0}",
		Regex.IsMatch(input, @"\P{IsDingbats}").ToString()
	);

	input = "😎";

	Console.WriteLine("Smiling Face with Sunglasses Emoji");
	Console.WriteLine("\tCode point: {0}", GetCodePoint(input, 0));
	Console.WriteLine("\tLength: {0}", input.Length.ToString()); // Two 16-bit code units.

	Console.WriteLine(
		"\tDoes the emoji match \\U0001F60E? {0}",
		Regex.IsMatch(input, "\U0001F60E").ToString()
	);

	Console.WriteLine(
		"\tIs the emoji in Dingbats? {0}",
		Regex.IsMatch(input, @"\p{IsDingbats}").ToString()
	);
	Console.WriteLine(
		"\tIs the emoji not in Dingbats? {0}",
		Regex.IsMatch(input, @"\P{IsDingbats}").ToString()
	);

	input = "İ"; // In Turkish, capital i is not I. It is İ.
	var pattern = "i";

	Console.WriteLine("Turkish Culture");
	Console.WriteLine(
		"\tMatches without CultureInvariant? {0}",
		Regex
			.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
			.ToString()
	);

	Console.WriteLine(
		"\tMatches with CultureInvariant? {0}",
		Regex
			.IsMatch(
				input,
				pattern,
				System.Text.RegularExpressions.RegexOptions.IgnoreCase
				| System.Text.RegularExpressions.RegexOptions.CultureInvariant
			)
			.ToString()
	);

	Console.ReadKey();
}

static string GetCodePoint(string input, int index)
{
	return char.IsSurrogatePair(input, index)
		? $"U+{char.ConvertToUtf32(input, 0):X8}"
		: $"U+{char.ConvertToUtf32(input, 0):X4}";
}

static void AdvancedTopics()
{
	var input = "a";

	Console.WriteLine(input);
	Console.WriteLine("\tCode point: {0}", GetCodePoint(input, 0));
	Console.WriteLine("\tLength: {0}", input.Length.ToString());

	Console.WriteLine("\tIs uppercase letter? {0}", Regex.IsMatch(input, @"\p{Lu}").ToString()); // Supported Unicode general categories, where Lu is Letter, Uppercase
	Console.WriteLine(
		"\tIs not an uppercase letter? {0}",
		Regex.IsMatch(input, @"\P{Lu}").ToString()
	);

	Console.ReadKey();
}

static void BacktrackingAndRunaways()
{
	var patterns = new List<string> {@"<.+>", @"<.+?>", @"(a+(aa)+(aaa)+(aa)+a+)+b."};
	var inputs = new List<string>
	{
		"a<tag>b</tag>c",
		"aaaaaaaaaaaaaaaaaaaab",
		"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
	};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var watch = new Stopwatch();
			watch.Start();
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch found at index {0}. Length: {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
			watch.Stop();
			Console.WriteLine(
				"\t\tRuntime: {0}ms",
				watch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)
			);
		});
	});
	Console.ReadKey();
}

static void LookaheadsLookBehindsAndPruning()
{
	var patterns = new List<string>
	{
		@"[A-Z]",
		"[A-Z-[Z]]",
		"a(?=b)",
		"a(?!b)",
		"(?<=c)a",
		"(?<!c)a"
	};
	var inputs = new List<string> {"", "a", "b", "ab", "ca", "cab", "A", "B", "Z", "AA"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch found at index {0}. Length: {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
	Console.ReadKey();
}

static void RegexOptions()
{
	var patterns = new List<string>
	{
		"(?x)Hey#This is a comment",
		"He(?# This is a comment...)y",
		"H(?i)e(?-i)y",
		@"(?m)^hey$",
		"(he)y",
		"(?n)(he)(?-n)y",
		"(?x) \r\n h e y"
	};
	var inputs = new List<string>
	{
		"hey\nhey",
		" hey\nhey",
		" hey\n hey",
		"Hey",
		"hey",
		"HEy",
		"HEY",
		" hey",
		"hey ",
		" hey "
	};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: \"{0}\"", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: \"{0}\"", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match match in results)
			{
				Console.WriteLine(
					"\t\tMatch found at index {0}. Length: {1}.",
					match.Index.ToString(),
					match.Length.ToString()
				);
				foreach (Group group in match.Groups)
					Console.WriteLine(
						"\t\t\tGroup at index {0} has value {1}",
						group.Index.ToString(),
						group.Value
					);
			}
		});
	});
	Console.ReadKey();
}

static void AnchorsAndBoundaries()
{
	var patterns = new List<string> {@"\b", @"\B", @"^hi", @"hi$"};
	var inputs = new List<string>
	{
		"a b",
		"a",
		" ",
		"",
		"hi",
		" hi",
		" hi",
		"him",
		" him",
		"him "
	};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch found at index {0}. Length: {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
	Console.ReadKey();
}

static void PatternMatching2()
{
	var patterns = new List<string> {"\\?", @"\?", Regex.Escape("?")};
	var inputs = new List<string> {"?"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch found at index {0}. Length: {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
	Console.ReadKey();
}

static void StringSplitting()
{
	var patterns = new List<string> {@"^\d\d\d-\d\d\d-\d\d\d\d$"};
	var inputs = new List<string>
	{
		"5555555555",
		"(555)-555-5555",
		"012-345-6789",
		"555-555-5555",
		"555-555-5555a",
		"5555-555-5555",
		"555555-5555",
		"555-5555555",
		"000-000-0000",
		"a",
		"5.55-555-5555",
		"...-...-...."
	};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var isMatch = regex.IsMatch(input);
			Console.WriteLine("\t\t{0}", isMatch ? "Accepted" : "Rejected");
			if (!isMatch)
				return;
			var splits = Regex.Split(input, @"-\d\d\d-").ToList();
			Console.WriteLine("\t\t\tArea code: {0}", splits[0]);
			Console.WriteLine("\t\t\tLast 4 digits: {0}", splits[1]);
		});
	});
	Console.ReadKey();
}

static void GroupingAndSubstitution()
{
	var patterns = new List<string> {@"([A-Za-z]+).*\$(\d+.\d+)"};
	var inputs = new List<string>
	{
		@"
                  |---------------------| 
                  | Receipt from        |
                  | Alexandru's shop    |
                  |                     |
                  | Thanks for shopping!|
                  |---------|-----------|
                  | Item    | Price $USD|
                  |---------|-----------|
                  | Shoes   |    $47.99 |
                  | Cabbage |     $2.99 |
                  | Carrots |     $1.23 |
                  | Chicken |     $9.99 |
                  | Beef    |    $12.47 |
                  | Shirt   |     $5.97 |
                  | Salt    |     $2.99 |
                  |---------|-----------|"
	};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var matches = regex.Matches(input);
			if (matches.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match match in matches)
			{
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}",
					match.Index.ToString(),
					match.Length.ToString()
				);
				foreach (Group group in match.Groups)
					Console.WriteLine(
						"\t\t\tGroup at index {0} has value {1}",
						group.Index.ToString(),
						group.Value
					);
			}

			Console.WriteLine(
				"Simple replacement results: {0}",
				Regex.Replace(input, @"(Chicken)(.*) \$(9.99)", @"$1$2 $$0.00")
			);
			var results = Regex.Replace(
				input,
				pattern,
				match =>
					match.Groups[1].Value == "Chicken"
						? match.Value.Replace(match.Groups[2].Value, "0.00")
						: match.Value
			);

			Console.WriteLine("Advanced replacement result: {0}", results);
		});
	});
	Console.ReadKey();
}

static void Pruning()
{
	var patterns = new List<string> {@"[\w-[ah]]"};
	var inputs = new List<string> {"ahhhhhhhhhhb"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
			{
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
				foreach (Group group in result.Groups)
					Console.WriteLine("\t\t\tGroup {0} has value {1}.", group.Name, group.Value);
			}
		});
	});
}

static void BackreferenceConstructs()
{
	var patterns = new List<string> {@"(\d)x\1F", @"(?<One>\d)x\k<One>F"};
	var inputs = new List<string> {"0x0F"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
			{
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
				foreach (Group group in result.Groups)
					Console.WriteLine("\t\t\tGroup {0} has value {1}.", group.Name, group.Value);
			}
		});
	});
}

static void GroupingConstructs()
{
	var patterns = new List<string>
	{
		@"(\d)x(\d)F",
		@"(?<DigitOne>\d)x(?<DigitTwo>\d)F",
		@"(?:\d)x(?:\d)F"
	};
	var inputs = new List<string> {"0x1F"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
			{
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
				foreach (Group group in result.Groups)
					Console.WriteLine("\t\t\tGroup {0} has value {1}.", group.Name, group.Value);
			}
		});
	});
}

static void Alternation()
{
	var patterns = new List<string> {@"him|her", @"(?(\wi\w)him|her)"};
	var inputs = new List<string> {"him", "her", "they", "them"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
}

static void CharacterClasses()
{
	var patterns = new List<string> {@"\w", @"\W", @"\d"};
	var inputs = new List<string> {"a", "1", ".", " "};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
}

static void PatternMatching()
{
	var patterns = new List<string> {"a*b", "a+b", "a?b", @"\?", Regex.Escape("?")};
	var inputs = new List<string> {"a", "b", "ab", "aab", "abb", @"a?b"};
	patterns.ForEach(pattern =>
	{
		Console.WriteLine("Regular expression: {0}", pattern);
		var regex = new Regex(pattern);
		inputs.ForEach(input =>
		{
			Console.WriteLine("\tInput pattern: {0}", input);
			var results = regex.Matches(input);
			if (results.Count <= 0)
				Console.WriteLine("\t\tNo matches found.");
			foreach (Match result in results)
				Console.WriteLine(
					"\t\tMatch found at index {0} with length {1}.",
					result.Index.ToString(),
					result.Length.ToString()
				);
		});
	});
}

static void Demo()
{
	/*
	 * ^ - Starts with
	 * $ - Ends with
	 * [] - Range
	 * () - Group
	 * . - Single character once
	 * + - one or more characters in a row
	 * ? - optional preceding character match
	 * \ - escape character
	 * \n - New line
	 * \d - Digit
	 * \D - Non-digit
	 * \s - White space
	 * \S - non-white space
	 * \w - alphanumeric/underscore character (word chars)
	 * \W - non-word characters
	 * {x,y} - Repeat low (x) to high (y) (no "y" means at least x, no ",y" means that many)
	 * (x|y) - Alternative - x or y
	 *
	 * [^x] - Anything but x (where x is whatever character you want)
	 */
	// (440) 555-1212
	// 12-34567890
	// 123 87876

	var toSearch = File.ReadAllText("test.txt");

	// This pattern matches phone numbers in the following patterns
	var pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

	var matches = Regex.Matches(toSearch, pattern);

	foreach (Match match in matches)
	{
		Console.WriteLine(match.Value);
	}

	//Regex test = new Regex(pattern);

	//for (int i = 0; i < 100000; i++)
	//{
	//    //Regex.IsMatch("Berkc Tezc", pattern);
	//    test.IsMatch("Berkc Tezc");
	//}

	//stopwatch.Stop();

	//Console.WriteLine($"Time Elapsed in ms: {stopwatch.ElapsedMilliseconds}");
}