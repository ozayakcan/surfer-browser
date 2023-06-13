using EasyTabs;
using Surfer.BrowserSettings;
using Surfer.Forms;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Browser());
            MyAppContainer appContainer = new MyAppContainer();
            TitleBarTab titlebarTab = new EasyTabs.TitleBarTab(appContainer);
            titlebarTab.Content = new Browser(appContainer, titlebarTab)
            {
                StartUrl = MyBrowserSettings.HomePage,
            };
            appContainer.Tabs.Add(titlebarTab);
            appContainer.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appContainer);
            Application.Run(applicationContext);
        }
    }
}
