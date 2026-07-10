// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.Windows;

namespace GreatRed
{
    public partial class MainWindow
    {
        public static void ShowNotification(string level, string title, string message)
        {
            try
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (_toastWindowInstance == null || !_toastWindowInstance.IsLoaded)
                        {
                            _toastWindowInstance = new ToastWindow();
                            _toastWindowInstance.Show();
                        }
                        else if (!_toastWindowInstance.IsVisible)
                        {
                            _toastWindowInstance.Show();
                        }
                        _toastWindowInstance.AddToast(level, title, message);
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.WriteAllText("crash_toast.txt", ex.ToString());
                    }
                }));
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("crash_dispatch.txt", ex.ToString());
            }
        }
    }
}
