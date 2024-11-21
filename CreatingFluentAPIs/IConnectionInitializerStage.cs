namespace CreatingFluentAPIs;

public interface IConnectionInitializerStage
{
	public IDbConnection Connect();
}