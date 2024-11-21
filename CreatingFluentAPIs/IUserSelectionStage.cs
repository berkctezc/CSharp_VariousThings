namespace CreatingFluentAPIs;

public interface IUserSelectionStage
{
	public IPasswordSelectionStage AsUser(string? user);
}