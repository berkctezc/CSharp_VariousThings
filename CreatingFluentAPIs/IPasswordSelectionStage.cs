namespace CreatingFluentAPIs;

public interface IPasswordSelectionStage
{
    public IConnectionInitializerStage WithPassword(string password);
}