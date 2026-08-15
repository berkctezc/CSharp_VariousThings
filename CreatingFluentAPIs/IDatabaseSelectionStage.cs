namespace CreatingFluentAPIs;

public interface IDatabaseSelectionStage
{
	IUserSelectionStage AndDatabase(string? database);
}