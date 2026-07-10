// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace GreatRed
{
    public partial class MainWindow
    {
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            _isMinimized = !_isMinimized;
            double targetHeight = _isMinimized ? 36.0 : _originalBorderHeight;

            double opacityTarget = _isMinimized ? 0.0 : 1.0;
            double scaleTarget = _isMinimized ? 0.95 : 1.0;

            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            IEasingFunction easing = new CubicEase { EasingMode = EasingMode.EaseOut };

            DoubleAnimation heightAnim = new DoubleAnimation(targetHeight, duration) { EasingFunction = easing };
            ImguiWindowBorder.BeginAnimation(Border.HeightProperty, heightAnim);

            DoubleAnimation opacityAnim = new DoubleAnimation(opacityTarget, duration) { EasingFunction = easing };
            ContentContainerGrid.BeginAnimation(Grid.OpacityProperty, opacityAnim);

            DoubleAnimation contentScaleAnim = new DoubleAnimation(scaleTarget, duration) { EasingFunction = easing };
            ScaleTransform contentScale = new ScaleTransform(1, 1, 200, 140);
            ContentContainerGrid.RenderTransform = contentScale;
            contentScale.BeginAnimation(ScaleTransform.ScaleXProperty, contentScaleAnim);
            contentScale.BeginAnimation(ScaleTransform.ScaleYProperty, contentScaleAnim);

            ContentContainerGrid.IsHitTestVisible = !_isMinimized;

            if (_isMinimized)
            {
                DoubleAnimation borderGlow = new DoubleAnimation(0.2, 0.6, TimeSpan.FromMilliseconds(1500))
                {
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever
                };
                if (ImguiWindowBg.Effect is DropShadowEffect bgEffect)
                {
                    bgEffect.BeginAnimation(DropShadowEffect.OpacityProperty, borderGlow);
                }
            }
            else
            {
                if (ImguiWindowBg.Effect is DropShadowEffect bgEffect)
                {
                    bgEffect.BeginAnimation(DropShadowEffect.OpacityProperty, null);
                    bgEffect.Opacity = 0.08;
                }
            }

            ShowNotification("info", "System Status", _isMinimized ? "Console window minimized." : "Console window restored.");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(200));
            IEasingFunction easing = new QuadraticEase { EasingMode = EasingMode.EaseIn };

            DoubleAnimation opacityAnim = new DoubleAnimation(0.0, duration) { EasingFunction = easing };
            DoubleAnimation scaleAnim = new DoubleAnimation(0.8, duration) { EasingFunction = easing };

            DoubleAnimation translateAnim = new DoubleAnimation(20.0, duration) { EasingFunction = easing };
            TranslateTransform translate = new TranslateTransform();
            ImguiWindowBorder.RenderTransform = new TransformGroup { Children = { WindowScale, WindowRotation, translate } };

            opacityAnim.Completed += (s, ev) =>
            {
                Application.Current.Shutdown();
                Environment.Exit(0);
            };

            ImguiWindowBorder.BeginAnimation(Border.OpacityProperty, opacityAnim);
            WindowScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            WindowScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
            translate.BeginAnimation(TranslateTransform.YProperty, translateAnim);
        }

        private void ImguiRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            ImguiRestoreButton.Visibility = Visibility.Collapsed;

            this.Width = 492;
            this.Height = 372;
            this.Left = _lastLeft;
            this.Top = _lastTop;

            ImguiWindowBorder.Visibility = Visibility.Visible;
            CrtOverlay.Visibility = Visibility.Visible;

            ImguiWindowBorder.RenderTransform = new TransformGroup { Children = { WindowScale, WindowRotation } };

            DoubleAnimation opacityAnim = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(250));
            DoubleAnimation scaleAnim = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(250));

            ImguiWindowBorder.BeginAnimation(Border.OpacityProperty, opacityAnim);
            WindowScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            WindowScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            ShowNotification("success", "System Status", "Console window restored.");
        }
    }
}
