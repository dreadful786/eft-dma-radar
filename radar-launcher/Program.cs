using System;
using System.Windows.Forms;

namespace radar_launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configure the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Launch the form
            Application.Run(new LauncherForm());
        }
    }
}