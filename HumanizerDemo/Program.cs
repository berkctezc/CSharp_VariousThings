var turkishCulture = new CultureInfo("tr-TR");

Vocabularies.Default.AddPlural("boost", "boosters");

var strings = new Func<string>[]
{
	// general
	() => "user_not_found",
	() => "user_not_found".Humanize(),
	() => "user_not_found".Humanize(LetterCasing.Sentence),
	() => "CSS".Humanize(),
	() => "User not found".Dehumanize(),
	() => "User not found".Underscore(),
	() => "A very long collection of words".Truncate(12, "..."),
	() => DemoEnum.EnumValue.Humanize(),
	() => "person".Pluralize(),
	() => "woman".Pluralize(),
	() => "Boost".Pluralize(), // customized
	() => "---",
	// dates
	() => DateTime.UtcNow.AddHours(-24).Humanize(),
	() => DateTime.UtcNow.AddHours(-36).Humanize(),
	() => DateTime.UtcNow.AddMinutes(-36).Humanize(),
	() => DateTime.UtcNow.AddMinutes(77).Humanize(),
	() => "---",
	// timespans
	() => TimeSpan.FromMilliseconds(252000).Humanize(2),
	() => TimeSpan.FromDays(7).Humanize(maxUnit: TimeUnit.Day),
	() => "---",
	// case stuff
	() => "Berkc Tezc".Pascalize(),
	() => "Berkc Tezc".Camelize(),
	() => "Berkc Tezc".Underscore(),
	() => "Berkc Tezc".Dasherize(),
	() => "Berkc Tezc".Hyphenate(),
	() => "Berkc Tezc".Kebaberize(),
	() => "---",
	// numbers
	() => 1.ToWords(),
	() => 1.ToOrdinalWords(),
	() => 1.Millions().ToString(),
	() => 66.Billions().ToString(),
	() => "---",
	// culture
	() => 1.ToWords(turkishCulture),
	() => 1.ToOrdinalWords(turkishCulture),
	() => DateTime.UtcNow.AddHours(-24).Humanize(culture: turkishCulture),
	() => DateTime.UtcNow.AddHours(24).Humanize(culture: turkishCulture),
	() => "---",
};

foreach (var textFunc in strings)
	Console.WriteLine(textFunc());