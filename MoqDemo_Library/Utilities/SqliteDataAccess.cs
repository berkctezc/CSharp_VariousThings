namespace MoqDemo_Library.Utilities;

public class SqliteDataAccess : ISqliteDataAccess
{
    public List<T> LoadData<T>(string sql)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<T>(sql, new DynamicParameters());
        return output.ToList();
    }

    public void SaveData<T>(T person, string sql)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute(sql, person);
    }

    public void UpdateData<T>(T person, string sql)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute(sql, person);
    }

    private string LoadConnectionString(string id = "Default")
    {
        return "Data Source = ..\\..\\..\\..\\MoqDemo_ConsoleUI\\MoqDemoDb.db";
    }
}
