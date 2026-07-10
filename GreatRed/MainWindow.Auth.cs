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

namespace GreatRed
{
    public partial class MainWindow
    {
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            HandleLogin();
        }

        private void LoginInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                HandleLogin();
            }
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrEmpty(TxtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void HandleLogin()
        {
            if (_isLoggingIn) return;

            string username = TxtUsername.Text;
            string password = TxtPassword.Password;

            if (username == "1" && password == "1")
            {
                _isLoggingIn = true;
                ShowNotification("success", "Success", "License authenticated. Initializing download.");

                DoubleAnimation fadeOut = new DoubleAnimation(0.0, TimeSpan.FromMilliseconds(200));
                fadeOut.Completed += (s, ev) =>
                {
                    LoginPage.Visibility = Visibility.Collapsed;

                    DownloadPage.Visibility = Visibility.Visible;
                    DoubleAnimation fadeIn = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(250));
                    DownloadPage.BeginAnimation(Grid.OpacityProperty, fadeIn);

                    StartResourceDownload();
                };
                LoginPage.BeginAnimation(Grid.OpacityProperty, fadeOut);
            }
            else
            {
                ShowNotification("warning", "Warning", "Invalid credentials. Verification failed.");

                DoubleAnimationUsingKeyFrames shake = new DoubleAnimationUsingKeyFrames();
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(-5, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.07))));
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(5, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.14))));
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(-5, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.21))));
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(5, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.28))));
                shake.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.35))));

                TranslateTransform translate = new TranslateTransform();
                LoginPage.RenderTransform = translate;
                translate.BeginAnimation(TranslateTransform.XProperty, shake);
            }
        }
    }
}
