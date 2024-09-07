namespace CSv11;

public static class ExtendedNameOf
{
	private class MyClass
	{
		[Name(nameof(text))]
		public void Test(string text) { }
	}

	private class NameAttribute : Attribute
	{
		public NameAttribute(string text)
		{
			Console.WriteLine($"mytext: {text}");
		}
	}
}
