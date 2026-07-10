// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GreatRed
{
    public partial class MainWindow
    {
        private void TabButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int pageIndex = int.Parse(btn.Tag?.ToString() ?? "0");
            ShowPage(pageIndex);

            string tabName = pageIndex switch
            {
                0 => "Security Integrity page",
                1 => "Bypass Configuration page",
                2 => "Emulator Installer menu",
                _ => "Web Portal support page"
            };
        }

        private void ShowPage(int index)
        {
            if (EmuSelectPopup != null)
            {
                EmuSelectPopup.IsOpen = false;
            }

            TabBtn1.BorderBrush = Brushes.Transparent;
            TabBtn2.BorderBrush = Brushes.Transparent;
            TabBtn3.BorderBrush = Brushes.Transparent;
            TabBtn4.BorderBrush = Brushes.Transparent;

            ((Path)TabBtn1.Content).Stroke = (SolidColorBrush)FindResource("TextMutedBrush");
            ((Path)TabBtn2.Content).Stroke = (SolidColorBrush)FindResource("TextMutedBrush");
            ((Path)TabBtn3.Content).Stroke = (SolidColorBrush)FindResource("TextMutedBrush");
            ((Path)TabBtn4.Content).Stroke = (SolidColorBrush)FindResource("TextMutedBrush");

            PageSecurity.Visibility = Visibility.Collapsed;
            PageBypass.Visibility = Visibility.Collapsed;
            PageEmu.Visibility = Visibility.Collapsed;
            PageWeb.Visibility = Visibility.Collapsed;

            Button activeBtn = index switch
            {
                0 => TabBtn1,
                1 => TabBtn2,
                2 => TabBtn3,
                _ => TabBtn4
            };

            activeBtn.BorderBrush = new SolidColorBrush((Color)FindResource("CrimsonColor")) { Opacity = 0.4 };
            ((Path)activeBtn.Content).Stroke = (SolidColorBrush)FindResource("CrimsonBrush");

            Grid activePage = index switch
            {
                0 => PageSecurity,
                1 => PageBypass,
                2 => PageEmu,
                _ => PageWeb
            };

            activePage.Visibility = Visibility.Visible;

            TranslateTransform slideTransform = new TranslateTransform(0, 12);
            activePage.RenderTransform = slideTransform;

            Duration transitionDuration = new Duration(TimeSpan.FromMilliseconds(300));
            IEasingFunction easing = new CubicEase { EasingMode = EasingMode.EaseOut };

            DoubleAnimation fadeIn = new DoubleAnimation(0.0, 1.0, transitionDuration)
            {
                EasingFunction = easing
            };
            activePage.BeginAnimation(Grid.OpacityProperty, fadeIn);

            DoubleAnimation slideAnim = new DoubleAnimation(12.0, 0.0, transitionDuration)
            {
                EasingFunction = easing
            };
            slideTransform.BeginAnimation(TranslateTransform.YProperty, slideAnim);

            double targetY = 13 + index * 38;
            DoubleAnimation indicatorAnim = new DoubleAnimation(targetY, TimeSpan.FromMilliseconds(300))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            IndicatorTransform.BeginAnimation(TranslateTransform.YProperty, indicatorAnim);
        }
    }
}
