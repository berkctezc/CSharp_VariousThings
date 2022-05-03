using CreatingFluentAPIs;

var connection1 = new SimpleFluentSqlConnection()
    .ForServer("localhost")
    .AndDatabase("localDb")
    .AsUser("postgres")
    .AndPassword("postgres")
    .Connect();

var connection2 = FluentSqlConnection
    .CreateConnection(configuration => configuration.ConnectionName = "test")
    .ForServer("localhost")
    .AndDatabase("postgres")
    .AsUser("postgres")
    .WithPassword("postgres")
    .Connect();

