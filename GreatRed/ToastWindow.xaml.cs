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
using System.Windows.Shapes;

namespace GreatRed
{
    public partial class ToastWindow : Window
    {
        public ToastWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = SystemParameters.WorkArea.Width - this.Width - 10;
            this.Top = SystemParameters.WorkArea.Height - this.Height - 10;
        }

        public void AddToast(string level, string title, string message)
        {
            Color notchColor = level switch
            {
                "success" => Color.FromRgb(0, 200, 83),
                "warning" => Color.FromRgb(255, 186, 0),
                _ => Color.FromRgb(255, 30, 86)
            };

            SolidColorBrush notchBrush = new SolidColorBrush(notchColor);

            Border toastBorder = new Border
            {
                Width = 280,
                Margin = new Thickness(0, 0, 0, 8),
                CornerRadius = new CornerRadius(12),
                Background = new SolidColorBrush(Color.FromRgb(13, 12, 12)),
                BorderBrush = new SolidColorBrush(Color.FromArgb(46, 255, 30, 86)),
                BorderThickness = new Thickness(1),
                Cursor = Cursors.Hand,
                ClipToBounds = false,
                RenderTransform = new TranslateTransform()
            };

            toastBorder.Effect = new System.Windows.Media.Effects.DropShadowEffect
            {
                Color = Colors.Black,
                BlurRadius = 15,
                ShadowDepth = 5,
                Opacity = 0.1
            };

            Grid mainGrid = new Grid { ClipToBounds = false };
            toastBorder.Child = mainGrid;

            Border notch = new Border
            {
                Height = 3,
                Width = 24,
                CornerRadius = new CornerRadius(0, 0, 3, 3),
                Background = notchBrush,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            mainGrid.Children.Add(notch);

            Grid contentGrid = new Grid
            {
                Margin = new Thickness(10, 12, 10, 10),
                ClipToBounds = false
            };
            contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(28) });
            contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            mainGrid.Children.Add(contentGrid);

            Grid iconGrid = new Grid
            {
                Width = 28,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                ClipToBounds = false
            };

            Border iconBackground = new Border
            {
                CornerRadius = new CornerRadius(6),
                Background = new LinearGradientBrush(
                    Color.FromRgb(43, 108, 176),
                    Color.FromRgb(26, 54, 93),
                    135)
            };
            iconGrid.Children.Add(iconBackground);

            Path iconPath = new Path
            {
                Data = Geometry.Parse("M8.5 14.5A2.5 2.5 0 0 0 11 12c0-1.38-.5-2-1-3-1.072-2.143-.224-4.054 2-6 .5 2.5 2 4.9 4 6.5 2 1.6 3 3.5 3 5.5a7 7 0 1 1-14 0c0-1.153.433-2.294 1-3a2.5 2.5 0 0 0 2.5 2.5z"),
                Fill = Brushes.White,
                Width = 16,
                Height = 16,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            iconGrid.Children.Add(iconPath);

            Border redDot = new Border
            {
                Width = 8,
                Height = 8,
                CornerRadius = new CornerRadius(4),
                Background = new SolidColorBrush(Color.FromRgb(229, 62, 62)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(13, 12, 12)),
                BorderThickness = new Thickness(1.5),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, -2, -2)
            };
            iconGrid.Children.Add(redDot);

            Grid.SetColumn(iconGrid, 0);
            contentGrid.Children.Add(iconGrid);

            StackPanel textPanel = new StackPanel
            {
                Margin = new Thickness(10, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(textPanel, 1);
            contentGrid.Children.Add(textPanel);

            TextBlock descText = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Color.FromRgb(237, 232, 232)),
                FontSize = 12.0,
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap,
                LineHeight = 16.0
            };
            textPanel.Children.Add(descText);

            Border progressContainer = new Border
            {
                Height = 4,
                CornerRadius = new CornerRadius(2),
                Background = new SolidColorBrush(Color.FromRgb(20, 18, 18)),
                Margin = new Thickness(0, 5, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            textPanel.Children.Add(progressContainer);

            Grid progressFillGrid = new Grid { HorizontalAlignment = HorizontalAlignment.Left };
            progressContainer.Child = progressFillGrid;

            Border progressBar = new Border
            {
                Height = 4,
                CornerRadius = new CornerRadius(2),
                Background = notchBrush,
                Width = 220
            };
            progressFillGrid.Children.Add(progressBar);

            toastBorder.MouseDown += (s, e) =>
            {
                DismissToast(toastBorder);
            };

            ToastStackPanel.Children.Add(toastBorder);

            DoubleAnimation slideIn = new DoubleAnimation(30, 0, TimeSpan.FromMilliseconds(350))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            ((TranslateTransform)toastBorder.RenderTransform).BeginAnimation(TranslateTransform.YProperty, slideIn);

            DoubleAnimation fadeIn = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(350));
            toastBorder.BeginAnimation(Border.OpacityProperty, fadeIn);

            DoubleAnimation progressAnim = new DoubleAnimation(220, 0, TimeSpan.FromMilliseconds(2000));
            progressAnim.Completed += (s, e) =>
            {
                DismissToast(toastBorder);
            };
            progressBar.BeginAnimation(Border.WidthProperty, progressAnim);
        }

        private void DismissToast(Border toastBorder)
        {
            if (!ToastStackPanel.Children.Contains(toastBorder)) return;

            DoubleAnimation slideOut = new DoubleAnimation(0, 300, TimeSpan.FromMilliseconds(250))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            slideOut.Completed += (s, ev) =>
            {
                if (ToastStackPanel.Children.Contains(toastBorder))
                {
                    ToastStackPanel.Children.Remove(toastBorder);
                }

                if (ToastStackPanel.Children.Count == 0)
                {
                    this.Hide();
                }
            };
            ((TranslateTransform)toastBorder.RenderTransform).BeginAnimation(TranslateTransform.XProperty, slideOut);

            DoubleAnimation fadeOut = new DoubleAnimation(0.0, TimeSpan.FromMilliseconds(250));
            toastBorder.BeginAnimation(Border.OpacityProperty, fadeOut);
        }
    }
}
