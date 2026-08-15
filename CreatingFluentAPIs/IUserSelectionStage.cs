namespace CreatingFluentAPIs;

public interface IUserSelectionStage
{
	IPasswordSelectionStage AsUser(string? user);
}