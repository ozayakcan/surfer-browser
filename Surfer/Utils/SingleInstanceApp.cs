using EasyTabs;
using Microsoft.VisualBasic.ApplicationServices;
using Surfer.BrowserSettings;
using Surfer.Forms;
using System;
using System.Linq;

namespace Surfer.Utils
{
    public class SingleInstanceApp : WindowsFormsApplicationBase
    {
        private TitleBarTabsApplicationContext m_AppContext;
        public SingleInstanceApp()
        : base()
        {
            IsSingleInstance = true;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);

            string[] secondInstanceArgumens = eventArgs.CommandLine.ToArray();

            SBAppContainer appContainer = (SBAppContainer)MainForm;
            if (secondInstanceArgumens.Length > 0)
            {
                appContainer.Tabs.Add(GetTab(appContainer, secondInstanceArgumens));
                appContainer.SelectedTabIndex = appContainer.Tabs.Count - 1;
            }
            if (eventArgs.BringToForeground)
            {
                appContainer.BringToFront();
            }
        }
        protected override void OnCreateMainForm()
        {
            base.OnCreateMainForm();
            SBAppContainer appContainer = new SBAppContainer();
            
            appContainer.Tabs.Add(GetTab(appContainer, Environment.GetCommandLineArgs().Skip(1).ToArray()));
            appContainer.SelectedTabIndex = 0;
            MainForm = appContainer;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appContainer);
            //Application.Run(applicationContext);
        }
        public TitleBarTab GetTab(SBAppContainer appContainer, string[] args)
        {
            TitleBarTab titlebarTab = new TitleBarTab(appContainer);
            Args clsArgs = Args.Handle(args);
            titlebarTab.Content = new Browser(appContainer, titlebarTab)
            {
                StartUrl = clsArgs.url != null ? clsArgs.url : SBBrowserSettings.HomePage,
            };
            return titlebarTab;
        }
    }
}
