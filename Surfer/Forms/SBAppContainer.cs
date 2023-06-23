using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using Surfer.BrowserSettings;
using Surfer.Utils;

namespace Surfer.Forms
{
    public partial class SBAppContainer : TitleBarTabs, IMessageFilter
    {
        public SBAppContainer()
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.BrowserCache();
            cefSettings.PersistSessionCookies = true;
            cefSettings.PersistUserPreferences = true;
            cefSettings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            if (!Cef.IsInitialized)
                Cef.Initialize(cefSettings);
            if (!HistoryManager.IsInitialized)
                HistoryManager.Initialize();
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            TabSelected += SBAppContainer_TabSelected;
        }

        private void SBAppContainer_TabSelected(object sender, TitleBarTabEventArgs e)
        {
            foreach (var tab in Tabs)
            {
                Browser browser = (tab.Content as Browser);
                if (browser.searchPopupForm != null)
                    browser.searchPopupForm.Visible = tab.Active;
            }
        }

        public override TitleBarTab CreateTab()
        {
            TitleBarTab titlebarTab = new TitleBarTab(this);
            titlebarTab.Content = new Browser(this, titlebarTab)
            {
                StartUrl = SBBrowserSettings.HomePage,
            };
            return titlebarTab;
        }
        bool mRepeating;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!mRepeating)
            {
                mRepeating = true;
                Browser myBrowser = (Browser)SelectedTab.Content;
                return myBrowser.KeyEvents(myBrowser.chBrowser, CefEventFlags.None, keyData, base.ProcessCmdKey(ref msg, keyData));
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x101) mRepeating = false;
            return false;
        }
    }
}
