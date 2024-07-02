namespace YieldDemo;

public static class DataAccess
{
	public static IEnumerable<PersonModel> GetPeople()
	{
		yield return new PersonModel("testName1");
		yield return new PersonModel("testName2");
		yield return new PersonModel("testName3");
		yield return new PersonModel("testName4");
		yield return new PersonModel("testName5");
		yield return new PersonModel("testName6");
		yield return new PersonModel("testName7");
		yield return new PersonModel("testName8");
	}
}