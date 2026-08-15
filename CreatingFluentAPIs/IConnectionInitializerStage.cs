namespace CreatingFluentAPIs;

public interface IConnectionInitializerStage
{
	IDbConnection Connect();
}