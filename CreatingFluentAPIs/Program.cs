new SimpleFluentSqlConnection()
	.ForServer("localhost")
	.AndDatabase("localDb")
	.AsUser("postgres")
	.AndPassword("postgres")
	.Connect();

FluentSqlConnection
	.CreateConnection(configuration => configuration.ConnectionName = "test")
	.ForServer("localhost")
	.AndDatabase("postgres")
	.AsUser("postgres")
	.WithPassword("postgres")
	.Connect();