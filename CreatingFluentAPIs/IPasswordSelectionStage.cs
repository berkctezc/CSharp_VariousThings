namespace CreatingFluentAPIs;

public interface IPasswordSelectionStage
{
	IConnectionInitializerStage WithPassword(string? password);
}