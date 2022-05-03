namespace CreatingFluentAPIs;

public interface IServerSelectionStage
{
    public IDatabaseSelectionStage ForServer(string server);
}