using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Async_Programming
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNormal_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();

            resultsWindow.Text += $"Total execution time:{watch.ElapsedMilliseconds}";
        }

        private async void ButtonAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            await RunDownloadAsync();

            watch.Stop();

            resultsWindow.Text += $"Total execution time:{watch.ElapsedMilliseconds}";
        }

        private async void ButtonParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            watch.Stop();

            resultsWindow.Text += $"Total execution time:{watch.ElapsedMilliseconds}";
        }

        private void RunDownloadSync()
        {
            var websites = PrepData();

            foreach (var site in websites)
            {
                var results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadAsync()
        {
            var websites = PrepData();

            foreach (var site in websites)
            {
                var results = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites) tasks.Add(DownloadWebsiteAsync(site));

            var results = await Task.WhenAll(tasks);

            foreach (var item in results) ReportWebsiteInfo(item);
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultsWindow.Text += $"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long. {Environment.NewLine}";
        }

        private static WebsiteDataModel DownloadWebsite(string site)
        {
            var output = new WebsiteDataModel();
            WebClient client = new();

            output.WebsiteUrl = site;
            output.WebsiteData = client.DownloadString(site);

            return output;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string site)
        {
            var output = new WebsiteDataModel();
            WebClient client = new();

            output.WebsiteUrl = site;
            output.WebsiteData = await client.DownloadStringTaskAsync(site);

            return output;
        }

        private List<string> PrepData()
        {
            var output = new List<string>();

            resultsWindow.Text = "";

            output.Add("https://stackoverflow.com/");
            output.Add("https://www.github.com");
            output.Add("https://www.linkedin.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://tiko.es");
            output.Add("https://www.youtube.com");

            return output;
        }
    }
}