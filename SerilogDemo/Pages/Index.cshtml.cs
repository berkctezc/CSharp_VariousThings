using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the Index Page");

            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "exception caught in Index");
            }
        }
    }
}
