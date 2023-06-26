using EasyTabs;
using Surfer.BrowserSettings;
using Surfer.Forms;
using Surfer.Utils;
using System;
using System.Windows.Forms;

namespace Surfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!Settings.Global.Get(nameof(Settings.AddedToDefaults), Settings.AddedToDefaults))
            {
                if(Args.IsAdministrator())
                    Args.RegisterApp(Application.ProductName, Application.ExecutablePath, Application.ProductName.Replace(" ", "."), Application.ProductName);
                else
                {
                    Args.ExecuteAsAdmin(args);
                    Application.Exit();
                    return;
                }
            }
            foreach (var item in args)
            {
                MessageBox.Show(item);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Browser());
            SBAppContainer appContainer = new SBAppContainer();
            TitleBarTab titlebarTab = new EasyTabs.TitleBarTab(appContainer);
            titlebarTab.Content = new Browser(appContainer, titlebarTab)
            {
                StartUrl = args.Length > 0 ? args[args.Length - 1]: SBBrowserSettings.HomePage,
            };
            appContainer.Tabs.Add(titlebarTab);
            appContainer.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appContainer);
            Application.Run(applicationContext);
        }
    }
}
