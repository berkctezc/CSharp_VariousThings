namespace CreatingFluentAPIs;

public interface IDatabaseSelectionStage
{
    public IUserSelectionStage AndDatabase(string? database);
}