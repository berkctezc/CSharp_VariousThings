namespace Abstract_Classes_ConsoleUI;

internal class Program
{
	private static void Main(string[] args)
	{
		List<DataAccess> databases = new()
		{
			new SqlDataAccess(),
			new SqliteDataAccess()
		};

		foreach (var db in databases)
		{
			db.LoadConnectionString("demo");
			db.LoadData("select * from table");
			db.SaveData("insert into table");
			Console.WriteLine();
		}

		Console.WriteLine();
	}
}
