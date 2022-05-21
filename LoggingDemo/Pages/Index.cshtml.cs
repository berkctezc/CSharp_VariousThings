using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingDemo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger _logger;

    // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }
    public IndexModel(ILoggerFactory factory)
    {
        _logger = factory.CreateLogger("CustomCategory");
    }

    public void OnGet()
        // When index page loads
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