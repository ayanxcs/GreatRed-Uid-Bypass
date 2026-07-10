// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace GreatRed
{
    public partial class MainWindow
    {
        private void StartResourceDownload()
        {
            _downloadTimer?.Stop();
            _downloadedSize = 0;
            _downloadTimer = new DispatcherTimer();
            _downloadTimer.Interval = TimeSpan.FromMilliseconds(150);
            _downloadTimer.Tick += DownloadTimer_Tick;
            _downloadTimer.Start();
        }

        private void DownloadTimer_Tick(object? sender, EventArgs e)
        {
            Random rand = new Random();
            double speed = rand.NextDouble() * 5.0 + 2.5;
            _downloadedSize += speed * 0.15;

            if (_downloadedSize >= TotalSize)
            {
                _downloadedSize = TotalSize;
                _downloadTimer?.Stop();

                DownloadProgressBar.Width = 262;
                LblDownloadSize.Text = "0.0 MB";
                LblDownloadSpeed.Text = "0.0 MB/s";

                ShowNotification("success", "Success", "Resource initialization complete.");

                DoubleAnimation fadeOut = new DoubleAnimation(0.0, TimeSpan.FromMilliseconds(200));
                fadeOut.Completed += (s, ev) =>
                {
                    DownloadPage.Visibility = Visibility.Collapsed;

                    MainAppWorkspace.Visibility = Visibility.Visible;
                    DoubleAnimation fadeIn = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(250));
                    MainAppWorkspace.BeginAnimation(Grid.OpacityProperty, fadeIn);

                    ShowPage(0);
                };
                DownloadPage.BeginAnimation(Grid.OpacityProperty, fadeOut);
            }
            else
            {
                double percentage = _downloadedSize / TotalSize;
                double targetWidth = percentage * 262;

                DoubleAnimation widthAnim = new DoubleAnimation(targetWidth, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                DownloadProgressBar.BeginAnimation(Border.WidthProperty, widthAnim);

                LblDownloadSize.Text = $"{(TotalSize - _downloadedSize):F1} MB";
                LblDownloadSpeed.Text = $"{speed:F1} MB/s";
            }
        }
    }
}
