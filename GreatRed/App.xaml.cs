// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System;
using System.IO;
using System.Windows;

namespace GreatRed;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            LogException(args.ExceptionObject as Exception, "AppDomain");
        };

        this.DispatcherUnhandledException += (sender, args) =>
        {
            LogException(args.Exception, "Dispatcher");
        };
    }

    private void LogException(Exception? ex, string source)
    {
        if (ex == null) return;
        try
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"[{DateTime.Now}] Source: {source}");

            Exception? currentEx = ex;
            int depth = 0;
            while (currentEx != null)
            {
                sb.AppendLine($"Depth: {depth}");
                sb.AppendLine($"Exception: {currentEx.GetType().FullName}");
                sb.AppendLine($"Message: {currentEx.Message}");
                sb.AppendLine($"StackTrace:\n{currentEx.StackTrace}");
                sb.AppendLine(new string('-', 40));
                currentEx = currentEx.InnerException;
                depth++;
            }
            sb.AppendLine();

            File.AppendAllText(logPath, sb.ToString());
        }
        catch
        {
        }
    }
}
