namespace Async_Advanced;

public static class DemoMethods
{
	public static List<string> PrepData()
	{
		List<string> output = new()
		{
			"https://www.stackoverflow.com/",
			"https://www.github.com",
			"https://www.facebook.com",
			"https://www.twitter.com",
			"https://www.linkedin.com",
			"https://www.codeproject.com",
			"https://www.google.com",
			"https://en.wikipedia.org/wiki/.NET_Framework",
			"https://www.microsoft.com",
			"https://tiko.es",
			"https://www.youtube.com"
		};

		return output;
	}

	[Obsolete("Obsolete")]
	public static List<WebsiteDataModel> RunDownloadSync()
	{
		var websites = PrepData();
		var output = new List<WebsiteDataModel>();

		foreach (var site in websites)
		{
			var results = DownloadWebsite(site);
			output.Add(results);
		}

		return output;
	}

	[Obsolete("Obsolete")]
	public static List<WebsiteDataModel> RunDownloadParallelSync()
	{
		var websites = PrepData();
		var output = new List<WebsiteDataModel>();

		Parallel.ForEach(websites, site =>
		{
			var results = DownloadWebsite(site);
			output.Add(results);
		});

		return output;
	}

	[Obsolete("Obsolete")]
	public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsyncV2(
		IProgress<ProgressReportModel> progress)
	{
		var websites = PrepData();
		var output = new List<WebsiteDataModel>();
		var report = new ProgressReportModel();

		await Task.Run(() =>
		{
			Parallel.ForEach(websites, site =>
			{
				var results = DownloadWebsite(site);
				output.Add(results);

				report.SitesDownloaded = output;
				report.PercentageComplete = output.Count * 100 / websites.Count;
				progress.Report(report);
			});
		});

		return output;
	}

	[Obsolete("Obsolete")]
	public static async Task<List<WebsiteDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress,
		CancellationToken cancellationToken)
	{
		var websites = PrepData();
		var output = new List<WebsiteDataModel>();
		var report = new ProgressReportModel();

		foreach (var site in websites)
		{
			var results = await DownloadWebsiteAsync(site);
			output.Add(results);

			cancellationToken.ThrowIfCancellationRequested();

			report.SitesDownloaded = output;
			report.PercentageComplete = output.Count * 100 / websites.Count;
			progress.Report(report);
		}

		return output;
	}

	[Obsolete("Obsolete")]
	public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
	{
		var websites = PrepData();
		var tasks = new List<Task<WebsiteDataModel>>();

		foreach (var site in websites) tasks.Add(DownloadWebsiteAsync(site));

		var results = await Task.WhenAll(tasks);

		return new List<WebsiteDataModel>(results);
	}

	[Obsolete("Obsolete")]
	private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
	{
		var output = new WebsiteDataModel();
		var client = new WebClient();

		output.WebsiteUrl = websiteURL;
		output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);

		return output;
	}

	[Obsolete("Obsolete")]
	private static WebsiteDataModel DownloadWebsite(string websiteURL)
	{
		var output = new WebsiteDataModel();
		var client = new WebClient();

		output.WebsiteUrl = websiteURL;
		try
		{
			output.WebsiteData = client.DownloadString(websiteURL);
		}
		catch (WebException e)
		{
			Console.WriteLine(e);
		}

		return output;
	}
}