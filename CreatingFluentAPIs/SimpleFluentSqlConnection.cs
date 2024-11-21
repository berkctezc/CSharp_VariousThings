namespace CreatingFluentAPIs;

public class SimpleFluentSqlConnection
{
	private string? _database;
	private string? _password;
	private string? _server;
	private string? _user;

	public SimpleFluentSqlConnection ForServer(string server)
	{
		_server = server;
		return this;
	}

	public SimpleFluentSqlConnection AndDatabase(string database)
	{
		_database = database;
		return this;
	}

	public SimpleFluentSqlConnection AsUser(string user)
	{
		_user = user;
		return this;
	}

	public SimpleFluentSqlConnection AndPassword(string password)
	{
		_password = password;
		return this;
	}

	public SqlConnection Connect()
	{
		var conn = new SqlConnection(
			$"Server={_server};Database={_database};User Id={_user};Password={_password}"
		);
		conn.Open();
		return conn;
	}
}