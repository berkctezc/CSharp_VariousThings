namespace Abstract_Classes_ClassLibrary;

public abstract class DataAccess
{
	public virtual string LoadConnectionString(string name)
	{
		Console.WriteLine("Load connection string");
		return "testConnectionString";
	}

	public abstract void LoadData(string sql);
	public abstract void SaveData(string sql);
}
