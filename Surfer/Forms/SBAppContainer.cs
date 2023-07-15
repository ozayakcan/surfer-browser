using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using Microsoft.Win32;
using Surfer.Controls.Downloads;
using Surfer.Utils;
using Surfer.Utils.Browser;

namespace Surfer.Forms
{
    public partial class SBAppContainer : TitleBarTabs, IMessageFilter
    {
        public SBAppContainer()
        {

            if (!Settings.User.Get(nameof(Settings.LocalesChanged), Settings.LocalesChanged))
            {
                CultureInfo ci = CultureInfo.CurrentUICulture;
                string localeFile = null;
                if (File.Exists(Path.Combine(Locale.Location, ci.TwoLetterISOLanguageName + JSON.Extension)))
                {
                    localeFile = Path.Combine(Locale.Location, ci.TwoLetterISOLanguageName + JSON.Extension);
                }
                if (File.Exists(Path.Combine(Locale.Location, ci.Name + JSON.Extension)))
                {
                    localeFile = Path.Combine(Locale.Location, ci.Name + JSON.Extension);
                }
                if (localeFile != null)
                {
                    List<string> locales = Settings.Locales;
                    string lang = Path.GetFileNameWithoutExtension(localeFile);
                    if (!locales.Contains(lang))
                        locales.Insert(0, Path.GetFileNameWithoutExtension(localeFile));
                    Settings.User.Save(nameof(Settings.Locales), locales);
                }
                else
                {
                    Settings.User.Save(nameof(Settings.Locales), Settings.Locales);
                }
                Settings.User.Save(nameof(Settings.LocalesChanged), true);
            }
            Locale.Set(Settings.User.Get(nameof(Settings.Locales), Settings.Locales)[0]);
            sBDownloads = new SBDownloads();
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.BrowserCache();
            cefSettings.PersistSessionCookies = true;
            cefSettings.PersistUserPreferences = true;
            cefSettings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            cefSettings.AcceptLanguageList = string.Join(",", Settings.User.Get(nameof(Settings.Locales), Settings.Locales).Select((l) => Locale.GetL(l).accepted_languages));
            cefSettings.Locale = Settings.User.Get(nameof(Settings.Locales), Settings.Locales)[0];
            if (!Cef.IsInitialized)
                Cef.Initialize(cefSettings);
            if (!HistoryManager.IsInitialized)
                HistoryManager.Initialize();
            if (!DownloadManager.IsInitialized)
                DownloadManager.Initialize();
            if (!FavoriteManager.IsInitialized)
                FavoriteManager.Initialize();
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
            AeroPeekEnabled = true;
            ExitOnLastTabClose = false;
            TabRenderer = new ChromeTabRenderer(this);
            TabSelected += SBAppContainer_TabSelected;
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBAppContainer_Disposed;
        }

        private void SBAppContainer_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            RedrawTabs();
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
        public void CloseSelectedTab()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                CloseTab(SelectedTab);
            });
        }
        protected override void CloseTab(TitleBarTab closingTab)
        {
            base.CloseTab(closingTab);
            if (Tabs.Count == 0)
                Close();
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

        public SBDownloads sBDownloads;
        
        public PopupForm downloadsPopupForm;
        public void InitializeDownloadsForm(Browser owner, Control ownerControl, int marginY)
        {
            ShowDownloadsForm(owner, ownerControl, marginY);
            sBDownloads.UpdateDownloads();
            CloseDownloadsForm();
        }
        public void ShowDownloadsForm(Browser owner, Control ownerControl, int marginY)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                sBDownloads.MyBrowser = owner;
                downloadsPopupForm = new PopupForm()
                {
                    Owner = owner,
                    OwnerControl = ownerControl,
                    WhenClosed = () => { downloadsPopupForm = null; },
                    PopupFormStyle = PopupFormStyle.Right,
                    MarginY = marginY,
                    AnimationEnabled = true,
                    HideOnClickOutSide = true,
                    Content = sBDownloads,
                };
                downloadsPopupForm.Show();
            });
        }
        public void CloseDownloadsForm()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (downloadsPopupForm != null)
                    downloadsPopupForm.Hide();
            });
        }
    }
}
