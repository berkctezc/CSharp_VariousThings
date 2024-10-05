namespace SerilogDemo.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public void OnGet()
    {
        logger.LogInformation("You requested the Index Page");

        try
        {
            throw new Exception("");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "exception caught in Index");
        }
    }
}
