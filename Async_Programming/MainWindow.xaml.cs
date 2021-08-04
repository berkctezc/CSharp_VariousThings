using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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


        private void ButtonAsync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunDownloadSync()
        {
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultsWindow.Text += $"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long. {Environment.NewLine}";
        }

        private WebsiteDataModel DownloadWebsite(string site)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new();

            output.WebsiteUrl = site;
            output.WebsiteData = client.DownloadString(site);

            return output;
        }

        private List<string> PrepData()
        {
            List<string> output = new List<string>();

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
