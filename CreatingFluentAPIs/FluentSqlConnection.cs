using System.Data;
using System.Data.SqlClient;

namespace CreatingFluentAPIs;

public class FluentSqlConnection
    : IServerSelectionStage,
        IDatabaseSelectionStage,
        IUserSelectionStage,
        IPasswordSelectionStage,
        IConnectionInitializerStage
{
    private string? _server;
    private string? _database;
    private string? _user;
    private string? _password;

    private FluentSqlConnection()
    {
    }


    public static IServerSelectionStage CreateConnection(Action<ConnectionConfiguration> config)
    {
        var configuration = new ConnectionConfiguration();
        config?.Invoke(configuration);
        return new FluentSqlConnection();
    }

    public IDatabaseSelectionStage ForServer(string? server)
    {
        _server = server;
        return this;
    }

    public IUserSelectionStage AndDatabase(string? database)
    {
        _database = database;
        return this;
    }

    public IPasswordSelectionStage AsUser(string? user)
    {
        _user = user;
        return this;
    }

    public IConnectionInitializerStage WithPassword(string? password)
    {
        _password = password;
        return this;
    }

    public IDbConnection Connect()
    {
        var conn = new SqlConnection($"Server={_server};Database={_database};User Id={_user};Password={_password}");
        conn.Open();
        return conn;
    }
}