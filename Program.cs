using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            AppContainer appContainer = new AppContainer();
            appContainer.Tabs.Add(new EasyTabs.TitleBarTab(appContainer) {
                Content = new Browser
                {
                    Text = "New Tab"
                }
            });
            appContainer.SelectedTabIndex = 0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appContainer);
            Application.Run(applicationContext);
        }
    }
}
