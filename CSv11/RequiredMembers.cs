namespace CSv11;

public static class RequiredMembers
{
	private static void Test()
	{
		var user = new User {FullName = "BerkcTezc"};
	}

	class User
	{
		public required string FullName { get; init; }
	}
}