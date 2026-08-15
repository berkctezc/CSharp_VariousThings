namespace Abstract_Classes_ClassLibrary;

public interface IDataAccess
{
	string LoadConnectionString(string name);
	void LoadData(string sql);
	void SaveData(string sql);
}