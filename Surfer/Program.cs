using Surfer.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Surfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (!Settings.Global.Get(nameof(Settings.AddedToDefaults), Settings.AddedToDefaults))
            {
                if (Args.IsAdministrator())
                    Args.RegisterApp(Application.ProductName, Application.ExecutablePath, Application.ProductName.Replace(" ", "."), Application.ProductName);
                else
                {
                    Args.ExecuteAsAdmin(args);
                    Application.Exit();
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Browser());
            new SingleInstanceApp().Run(args);
        }
    }
}
