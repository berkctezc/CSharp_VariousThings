namespace CreatingFluentAPIs;

public interface IServerSelectionStage
{
	IDatabaseSelectionStage ForServer(string? server);
}