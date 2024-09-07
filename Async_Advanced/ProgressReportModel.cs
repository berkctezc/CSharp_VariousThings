namespace Async_Advanced;

public class ProgressReportModel
{
	public int PercentageComplete { get; set; } = 0;
	public List<WebsiteDataModel> SitesDownloaded { get; set; } = new();
}
