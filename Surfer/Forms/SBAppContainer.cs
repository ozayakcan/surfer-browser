using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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

            if (!Settings.User.Get(nameof(Settings.LanguagesChanged), Settings.LanguagesChanged))
            {
                CultureInfo ci = CultureInfo.CurrentUICulture;
                string languageFile = null;
                if (File.Exists(Path.Combine(Language.Location, ci.TwoLetterISOLanguageName + ".sf")))
                {
                    languageFile = Path.Combine(Language.Location, ci.TwoLetterISOLanguageName + ".sf");
                }
                if (File.Exists(Path.Combine(Language.Location, ci.Name + ".sf")))
                {
                    languageFile = Path.Combine(Language.Location, ci.Name + ".sf");
                }
                if (languageFile != null)
                {
                    List<string> languages = Settings.Languages;
                    string lang = Path.GetFileNameWithoutExtension(languageFile);
                    if (!languages.Contains(lang))
                        languages.Insert(0, Path.GetFileNameWithoutExtension(languageFile));
                    Settings.User.Save(nameof(Settings.Languages), languages);
                }
                else
                {
                    Settings.User.Save(nameof(Settings.Languages), Settings.Languages);
                }
                Settings.User.Save(nameof(Settings.LanguagesChanged), true);
            }
            Language.Set(Settings.User.Get(nameof(Settings.Languages), Settings.Languages)[0]);

            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.BrowserCache();
            cefSettings.PersistSessionCookies = true;
            cefSettings.PersistUserPreferences = true;
            cefSettings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            cefSettings.AcceptLanguageList = string.Join(",", Settings.User.Get(nameof(Settings.Languages), Settings.Languages).Select((l) => Language.GetL(l).accepted_languages));
            cefSettings.Locale = Settings.User.Get(nameof(Settings.Languages), Settings.Languages)[0];
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
