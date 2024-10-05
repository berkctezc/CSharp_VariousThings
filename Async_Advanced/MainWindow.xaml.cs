namespace Async_Advanced;

public partial class MainWindow : Window
{
    private readonly CancellationTokenSource cts = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    [Obsolete("Obsolete")]
    private void ButtonNormal_Click(object sender, RoutedEventArgs e)
    {
        var watch = Stopwatch.StartNew();

        var results = DemoMethods.RunDownloadParallelSync();
        PrintResults(results);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        resultsWindow.Text += $"Total execution time: {elapsedMs}";
    }

    [Obsolete("Obsolete")]
    private async void ButtonAsync_Click(object sender, RoutedEventArgs e)
    {
        var progress = new Progress<ProgressReportModel>();
        progress.ProgressChanged += ReportProgress;

        var watch = Stopwatch.StartNew();

        try
        {
            var results = await DemoMethods.RunDownloadAsync(progress, cts.Token);
            PrintResults(results);
        }
        catch (OperationCanceledException)
        {
            resultsWindow.Text += $"The async download was cancelled. {Environment.NewLine}";
        }
        catch (Exception)
        {
            resultsWindow.Text += $"URL is Wrong {Environment.NewLine}";
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        resultsWindow.Text += $"Total execution time: {elapsedMs}";
    }

    private void ReportProgress(object sender, ProgressReportModel e)
    {
        dashboardProgress.Value = e.PercentageComplete;
        PrintResults(e.SitesDownloaded);
    }

    [Obsolete("Obsolete")]
    private async void ButtonParallelAsync_Click(object sender, RoutedEventArgs e)
    {
        Progress<ProgressReportModel> progress = new();
        progress.ProgressChanged += ReportProgress;

        var watch = Stopwatch.StartNew();

        var results = await DemoMethods.RunDownloadParallelAsyncV2(progress);
        PrintResults(results);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        resultsWindow.Text += $"Total execution time: {elapsedMs}";
    }

    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
        cts.Cancel();
    }

    private void PrintResults(List<WebsiteDataModel> results)
    {
        resultsWindow.Text = "";
        foreach (var item in results)
            resultsWindow.Text +=
                $"{item.WebsiteUrl} downloaded: {item.WebsiteData.Length} characters long.{Environment.NewLine}";
    }
}
