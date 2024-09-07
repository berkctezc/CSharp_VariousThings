namespace LoggingDemo.Pages;

public class IndexModel(ILoggerFactory factory) : PageModel
{
	private readonly ILogger _logger = factory.CreateLogger("CustomCategory");

	// When index page loads
	public void OnGet()
	{
		_logger.LogTrace("TRACE.");
		_logger.LogDebug("DEBUG.");
		_logger.LogInformation("INFORMATION.");
		_logger.LogWarning("WARNING.");
		_logger.LogError("ERROR.");
		_logger.LogCritical("CRITICAL.");

		_logger.LogError("Server went down temporarily at {Time}", DateTime.UtcNow);

		try
		{
			throw new Exception("Unhandled");
		}
		catch (Exception ex)
		{
			_logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.UtcNow);
		}
	}
}

public class LoggingId
{
	public const int DemoCode = 1001;
}
