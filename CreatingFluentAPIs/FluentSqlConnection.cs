namespace CreatingFluentAPIs;

public class FluentSqlConnection
	: IServerSelectionStage,
		IDatabaseSelectionStage,
		IUserSelectionStage,
		IPasswordSelectionStage,
		IConnectionInitializerStage
{
	private string? _database;
	private string? _password;
	private string? _server;
	private string? _user;

	private FluentSqlConnection() { }

	public IDbConnection Connect()
	{
		var conn = new SqlConnection(
			$"Server={_server};Database={_database};User Id={_user};Password={_password}"
		);
		conn.Open();
		return conn;
	}

	public IUserSelectionStage AndDatabase(string? database)
	{
		_database = database;
		return this;
	}

	public IConnectionInitializerStage WithPassword(string? password)
	{
		_password = password;
		return this;
	}

	public IDatabaseSelectionStage ForServer(string? server)
	{
		_server = server;
		return this;
	}

	public IPasswordSelectionStage AsUser(string? user)
	{
		_user = user;
		return this;
	}

	public static IServerSelectionStage CreateConnection(Action<ConnectionConfiguration> config)
	{
		var configuration = new ConnectionConfiguration();
		config?.Invoke(configuration);
		return new FluentSqlConnection();
	}
}
