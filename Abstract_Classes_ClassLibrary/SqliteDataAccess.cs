namespace Abstract_Classes_ClassLibrary;

public class SqliteDataAccess : DataAccess
{
	public override string LoadConnectionString(string name)
	{
		var output = base.LoadConnectionString(name);

		output += " (from SQLite)";

		return output;
	}

	public override void LoadData(string sql)
	{
		Console.WriteLine("Loading SQLite Data");
	}

	public override void SaveData(string sql)
	{
		Console.WriteLine("Saving data to SQLite");
	}
}
