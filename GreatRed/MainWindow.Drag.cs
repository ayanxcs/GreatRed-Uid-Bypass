// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace GreatRed
{
    public partial class MainWindow
    {
        private void TitleBarDragGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _isDragging = true;
                _lastMousePos = PointToScreen(e.GetPosition(this));
                _windowLeft = this.Left;
                _windowTop = this.Top;

                WindowRotation.BeginAnimation(RotateTransform.AngleProperty, null);

                DoubleAnimation opacityAnim = new DoubleAnimation(0.78, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                this.BeginAnimation(Window.OpacityProperty, opacityAnim);

                Color crimsonColor = (Color)ColorConverter.ConvertFromString("#FF1E56");
                SolidColorBrush borderBrush = new SolidColorBrush(((SolidColorBrush)ImguiWindowBg.BorderBrush).Color);
                ImguiWindowBg.BorderBrush = borderBrush;
                ColorAnimation borderAnim = new ColorAnimation(crimsonColor, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                borderBrush.BeginAnimation(SolidColorBrush.ColorProperty, borderAnim);

                if (ImguiWindowBg.Effect is DropShadowEffect bgEffect)
                {
                    DoubleAnimation shadowOpacityAnim = new DoubleAnimation(0.35, TimeSpan.FromMilliseconds(150))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    DoubleAnimation shadowBlurAnim = new DoubleAnimation(30, TimeSpan.FromMilliseconds(150))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    bgEffect.BeginAnimation(DropShadowEffect.OpacityProperty, shadowOpacityAnim);
                    bgEffect.BeginAnimation(DropShadowEffect.BlurRadiusProperty, shadowBlurAnim);
                }

                DoubleAnimation scaleAnim = new DoubleAnimation(0.99, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                WindowScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                WindowScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

                TitleBarDragGrid.CaptureMouse();
                e.Handled = true;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentMousePos = PointToScreen(e.GetPosition(this));
                double deltaX = currentMousePos.X - _lastMousePos.X;

                this.Left += deltaX;
                this.Top += currentMousePos.Y - _lastMousePos.Y;

                _lastMousePos = currentMousePos;

                double tiltAngle = Math.Max(-5.0, Math.Min(5.0, deltaX * 0.45));

                WindowRotation.BeginAnimation(RotateTransform.AngleProperty, null);

                double currentTilt = WindowRotation.Angle;
                double newTilt = currentTilt + (tiltAngle - currentTilt) * 0.25;
                WindowRotation.Angle = newTilt;
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                TitleBarDragGrid.ReleaseMouseCapture();

                DoubleAnimation opacityAnim = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                this.BeginAnimation(Window.OpacityProperty, opacityAnim);

                SolidColorBrush borderHoverBrush = (SolidColorBrush)FindResource("PanelBorderBrush");
                SolidColorBrush borderBrush = new SolidColorBrush(((SolidColorBrush)ImguiWindowBg.BorderBrush).Color);
                ImguiWindowBg.BorderBrush = borderBrush;
                ColorAnimation borderAnim = new ColorAnimation(borderHoverBrush.Color, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                borderBrush.BeginAnimation(SolidColorBrush.ColorProperty, borderAnim);

                if (ImguiWindowBg.Effect is DropShadowEffect bgEffect)
                {
                    DoubleAnimation shadowOpacityAnim = new DoubleAnimation(0.15, TimeSpan.FromMilliseconds(150))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    DoubleAnimation shadowBlurAnim = new DoubleAnimation(20, TimeSpan.FromMilliseconds(150))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    bgEffect.BeginAnimation(DropShadowEffect.OpacityProperty, shadowOpacityAnim);
                    bgEffect.BeginAnimation(DropShadowEffect.BlurRadiusProperty, shadowBlurAnim);
                }

                DoubleAnimation scaleAnim = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                WindowScale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                WindowScale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

                DoubleAnimation rotateAnim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                WindowRotation.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Window_MouseMove(sender: this, e: e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            Window_MouseUp(sender: this, e: e);
        }
    }
}
