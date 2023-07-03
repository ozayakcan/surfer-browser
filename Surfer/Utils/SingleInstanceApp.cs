using EasyTabs;
using Microsoft.VisualBasic.ApplicationServices;
using Surfer.Forms;
using Surfer.Utils.Browser;
using System;
using System.IO;
using System.Linq;

namespace Surfer.Utils
{
    public class SingleInstanceApp : WindowsFormsApplicationBase
    {
        public SingleInstanceApp()
        : base()
        {
            IsSingleInstance = true;
        }

        protected override void OnShutdown()
        {
            DownloadManager.Reset();
            var downloadTemps = Directory.EnumerateFiles(DownloadManager.Location, "*.*", SearchOption.AllDirectories).Where(s => Path.GetExtension(s) == DownloadManager.Extension);
            foreach (var file in downloadTemps)
            {
                File.Delete(file);
            }
            base.OnShutdown();
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);

            string[] secondInstanceArguments = eventArgs.CommandLine.ToArray();

            SBAppContainer appContainer = (SBAppContainer)MainForm;
            if (secondInstanceArguments.Length > 0)
            {
                appContainer.Tabs.Add(GetTab(appContainer, secondInstanceArguments));
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
            titlebarTab.Content = new Forms.Browser(appContainer, titlebarTab)
            {
                StartUrl = clsArgs.url != null ? clsArgs.url : SBBrowserSettings.HomePage,
            };
            return titlebarTab;
        }
    }
}
