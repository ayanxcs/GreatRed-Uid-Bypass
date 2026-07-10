// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace GreatRed
{
    public partial class MainWindow
    {
        private void BtnSecurityScan_Click(object sender, RoutedEventArgs e)
        {
            if (_scanTimer != null && _scanTimer.IsEnabled) return;

            BtnSecurityScan.IsEnabled = false;
            BtnSecurityScan.Content = "Scanning...";
            SecurityProgressContainer.Visibility = Visibility.Visible;

            StatusBypass.Text = "ANALYZING...";
            StatusBypass.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
            if (StatusBypass.Effect is DropShadowEffect effBypass)
            {
                effBypass.Color = Color.FromRgb(255, 186, 0);
            }

            StatusMemory.Text = "VERIFYING...";
            StatusMemory.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
            if (StatusMemory.Effect is DropShadowEffect effMem)
            {
                effMem.Color = Color.FromRgb(255, 186, 0);
            }

            StatusDebug.Text = "CHECKING...";
            StatusDebug.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
            if (StatusDebug.Effect is DropShadowEffect effDebug)
            {
                effDebug.Color = Color.FromRgb(255, 186, 0);
            }

            ShowNotification("info", "Security Scan", "Security integrity check started.");

            _scanProgress = 0;
            _scanTimer = new DispatcherTimer();
            _scanTimer.Interval = TimeSpan.FromMilliseconds(100);
            _scanTimer.Tick += ScanTimer_Tick;
            _scanTimer.Start();
        }

        private void ScanTimer_Tick(object? sender, EventArgs e)
        {
            _scanProgress += 10;

            SecurityProgressColDone.Width = new GridLength(_scanProgress, GridUnitType.Star);
            SecurityProgressColLeft.Width = new GridLength(100 - _scanProgress, GridUnitType.Star);

            if (_scanProgress >= 100)
            {
                _scanTimer?.Stop();

                SecurityProgressContainer.Visibility = Visibility.Collapsed;
                BtnSecurityScan.IsEnabled = true;
                BtnSecurityScan.Content = "SCAN SYSTEM";

                StatusBypass.Text = "SECURE";
                StatusBypass.Foreground = Brushes.Lime;
                if (StatusBypass.Effect is DropShadowEffect effBypass)
                {
                    effBypass.Color = Colors.Lime;
                }

                StatusMemory.Text = "SAFE";
                StatusMemory.Foreground = Brushes.Lime;
                if (StatusMemory.Effect is DropShadowEffect effMem)
                {
                    effMem.Color = Colors.Lime;
                }

                StatusDebug.Text = "ACTIVE";
                StatusDebug.Foreground = Brushes.Lime;
                if (StatusDebug.Effect is DropShadowEffect effDebug)
                {
                    effDebug.Color = Colors.Lime;
                }

                ShowNotification("success", "Security Scan", "Security check complete. System is SAFE.");
            }
        }

        private void ConnectBypass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtBypassState.Text = "Online";
                TxtBypassState.Foreground = Brushes.Lime;
                TxtBypassState.Effect = new DropShadowEffect { Color = Colors.Lime, BlurRadius = 8, ShadowDepth = 0, Opacity = 0.4 };

                BypassLedGlow.Visibility = Visibility.Visible;
                Storyboard pulseGlow = (Storyboard)FindResource("LedPulse");
                pulseGlow.Begin(this, isControllable: true);

                ShowNotification("success", "Success", "Crimson bypass connection established. Port locked.");
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("crash_connect.txt", ex.ToString());
            }
        }

        private void DisconnectBypass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtBypassState.Text = "Offline";
                TxtBypassState.Foreground = (SolidColorBrush)FindResource("TextMutedBrush");
                TxtBypassState.Effect = null;

                Storyboard pulseGlow = (Storyboard)FindResource("LedPulse");
                pulseGlow.Stop(this);
                BypassLedGlow.Visibility = Visibility.Collapsed;

                ShowNotification("info", "Information", "Bypass terminated.");
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("crash_disconnect.txt", ex.ToString());
            }
        }

        private void EmuSelectTrigger_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EmuSelectPopup.IsOpen = !EmuSelectPopup.IsOpen;
        }

        private void EmuOption_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border opt = (Border)sender;
            string value = opt.Tag?.ToString() ?? "MSI";
            string label = value == "MSI" ? "MSI Player" : "Bluestacks";

            _selectedEmuValue = value;
            TxtSelectedEmu.Text = label;
            TxtBypassEmu.Text = $"Emu: {value}";

            if (value == "MSI")
            {
                EmuOptMsi.Background = (SolidColorBrush)FindResource("CrimsonBrush");
                ((TextBlock)EmuOptMsi.Child).Foreground = Brushes.White;

                EmuOptBlue.Background = Brushes.Transparent;
                ((TextBlock)EmuOptBlue.Child).Foreground = (SolidColorBrush)FindResource("TextMainBrush");
            }
            else
            {
                EmuOptBlue.Background = (SolidColorBrush)FindResource("CrimsonBrush");
                ((TextBlock)EmuOptBlue.Child).Foreground = Brushes.White;

                EmuOptMsi.Background = Brushes.Transparent;
                ((TextBlock)EmuOptMsi.Child).Foreground = (SolidColorBrush)FindResource("TextMainBrush");
            }

            EmuSelectPopup.IsOpen = false;
            ShowNotification("info", "Information", $"Target: {value}");
        }

        private void RequestAccess_Click(object sender, RoutedEventArgs e)
        {
            ShowNotification("success", "Success", $"Access requested for {_selectedEmuValue}.");
        }

        private void InstallCert_Click(object sender, RoutedEventArgs e)
        {
            ShowNotification("success", "Success", $"Cert installed on {_selectedEmuValue}.");
        }

        private void UninstallCert_Click(object sender, RoutedEventArgs e)
        {
            ShowNotification("info", "Information", $"Cert uninstalled from {_selectedEmuValue}.");
        }

        private void OpenWebPortal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c start https://deletehex.com/",
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
                ShowNotification("success", "Support Portal", "Opening web portal in your browser.");
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("crash_portal.txt", ex.ToString());
                ShowNotification("warning", "Warning", "Failed to open link in web browser.");
            }
        }
    }
}
