using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Host;
using EasyTabs;
using Surfer.BrowserSettings;
using Surfer.Controls;
using Surfer.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Surfer.Forms
{
    public partial class Browser : Form
    {
        private string _startUrl = null;
        public string StartUrl {
            get => _startUrl;
            set
            {
                _startUrl = value;
                if(value != null) {
                    tbUrl.Text = value;
                    SBSiteInformationButtonStatus(true, SBBrowserSettings.IsSecureUrl(value));
                }
                else
                    SBSiteInformationButtonStatus(false);
            }
        }
        public Icon OriginalIcon = Properties.Resources.tab_icon;
        public Icon SiteIcon;
        public SBAppContainer AppContainer { get; set; }
        public TitleBarTab Tab { get; set; }

        MyNavigationEntryVisitor myNavigationEntryVisitor;

        Color pnlUrlBorderColor;
        public Browser(SBAppContainer appContainer, TitleBarTab titlebarTab)
        {
            AppContainer = appContainer;
            Tab = titlebarTab;
            InitializeComponent();
            pnlUrlBorderColor = pnlUrl.BorderColor;
            tsNav.Renderer = new SBRenderer();
            tsUrl.Renderer = new SBRenderer();
            AppContainer.LocationChanged += new EventHandler(AppContainer_LocationChanged);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadUrl(tbUrl.Text);
        }
        private string lastUrl = "";
        public void LoadUrl(string url)
        {
            lastUrl = url;
            chBrowser.Load(url);
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            // Browser
            chBrowser.DisplayHandler = new SBDisplayHandler(this);
            chBrowser.RequestHandler = new SBRequestHandler(this);
            chBrowser.FindHandler = new SBFindHandler(this);
            chBrowser.KeyboardHandler = new SBKeyboardHandler(this);
            chBrowser.MenuHandler = new SBContextMenuHandler(this);
            SetGoBackButtonStatus(chBrowser.CanGoBack);
            SetGoForwardButtonStatus(chBrowser.CanGoForward);
            myNavigationEntryVisitor = new MyNavigationEntryVisitor(this);
            if (!string.IsNullOrEmpty(StartUrl) && !string.IsNullOrWhiteSpace(StartUrl))
                LoadUrl(StartUrl);
        }

        private void chBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                chBrowser.Focus();
            });
        }

        private void chBrowser_LoadError(object sender, LoadErrorEventArgs e)
        {
            if (e.ErrorText == ErrorTexts.NameNotResolved)
                LoadUrl(lastUrl.GetSearchUrl());
        }
        internal void OpenInNewTab(string targetUrl, bool isCurrentTab = false)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                TitleBarTab titleBarTab = new TitleBarTab(AppContainer);
                titleBarTab.Content = new Browser(AppContainer, titleBarTab)
                {
                    StartUrl = targetUrl
                };
                int index = AppContainer.SelectedTabIndex;
                AppContainer.Tabs.Insert(index + 1, titleBarTab);
                AppContainer.SelectedTabIndex = index + 1;
                if(!isCurrentTab)
                    AppContainer.SelectedTabIndex = index;
            });
        }
        private bool _canChangeTitle = true;
        public void OnAddressChanged(AddressChangedEventArgs addressChangedArgs)
        {
            this.InvokeOnUiThreadIfRequired(() => {
                IgnoredUrls.IgnoredUrl ignoredUrl = null;
                foreach (var _ignoredUrl in IgnoredUrls.list)
                {
                    if (addressChangedArgs.Address.StartsWith(_ignoredUrl.url))
                    {
                        ignoredUrl = _ignoredUrl;
                        break;
                    }
                }
                string address = addressChangedArgs.Address;
                if (ignoredUrl != null)
                {
                    address = ignoredUrl.ignoreInAddress ? chBrowser.Address : addressChangedArgs.Address;
                    _canChangeTitle = ignoredUrl.canChangeTitle;
                }
                else
                    _canChangeTitle = true;
                tbUrl.Text = address;
                if (fullScreenForm != null)
                    fullScreenForm.Text = address;
                SBSiteInformationButtonStatus(true, SBBrowserSettings.IsSecureUrl(address));
                OnFavIconUrlChanged(address);
            });
        }

        internal void TitleChanged(string url, TitleChangedEventArgs titleChangedArgs)
        {
            if (_canChangeTitle)
                this.InvokeOnUiThreadIfRequired(() => {
                    IgnoredUrls.IgnoredUrl ignoredUrl = null;
                    foreach (var _ignoredUrl in IgnoredUrls.list)
                    {
                        if (titleChangedArgs.Title.StartsWith(_ignoredUrl.url))
                        {
                            ignoredUrl = _ignoredUrl;
                            break;
                        }
                    }
                    if(ignoredUrl != null)
                        if (ignoredUrl.changeUrl)
                            tbUrl.Text = titleChangedArgs.Title;
                        
                    Text = titleChangedArgs.Title;
                    chBrowser.GetBrowserHost().GetNavigationEntries(myNavigationEntryVisitor, true);
                    /*HistoryManager.Save(
                        url,
                        title: titleChangedArgs.Title/*,
                        onSaved: () => {
                            UpdateAutoCompletion();
                        }*///);
                });
        }
        // Url Auto Complete
        public void UpdateAutoCompletion()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(HistoryManager.Get.Select(h => h.DisplayUrl).ToArray());
                tbUrl.AutoCompleteCustomSource = autoCompleteString;
            });
        }

        public void OnFavIconUrlChanged(string url, string faviconUrl = "")
        {
            chBrowser.GetBrowserHost().GetNavigationEntries(myNavigationEntryVisitor, true);
            /*HistoryManager.Save(
                url,
                favicon: faviconUrl/*,
                onSaved: () => {
                    UpdateAutoCompletion();
                }*///);
            if (!string.IsNullOrEmpty(faviconUrl) && !string.IsNullOrWhiteSpace(faviconUrl))
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {

                        WebClient wc = new WebClient();
                        byte[] originalData = wc.DownloadData(faviconUrl);
                        MemoryStream stream = new MemoryStream(originalData);
                        Bitmap bmp = new Bitmap(stream);
                        var thumb = (Bitmap)bmp.GetThumbnailImage(32, 32, null, IntPtr.Zero);
                        thumb.MakeTransparent();
                        Icon icon = Icon.FromHandle(thumb.GetHicon());
                        SetIcon(icon);
                    }
                }
                catch
                {
                    SetIcon(OriginalIcon);
                }
            }
            else
            {
                SetIcon(OriginalIcon);
            }
        }
        private void SetIcon(Icon icon)
        {
            this.InvokeOnUiThreadIfRequired(() => {
                Icon = Tab.Icon = SiteIcon = icon;
                if (fullScreenForm != null)
                    fullScreenForm.Icon = icon;
                Tab.Parent.UpdateThumbnailPreviewIcon(Tab, icon);

            });
        }

        public void ShowLoading(int progress)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                pnlProgress.Visible = true;
                pbLoading.Value = progress;
                SetRefreshButtonStatus(false);
            });
        }

        public void HideLoading()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                SetRefreshButtonStatus(true);
                pbLoading.Value = 0;
                pnlProgress.Visible = true;
            });
        }
        private void chBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            
            if (!e.IsLoading)
            {
                SetGoBackButtonStatus(e.CanGoBack);
                SetGoForwardButtonStatus(e.CanGoForward);
                if (myNavigationEntryVisitor != null)
                    chBrowser.GetBrowserHost().GetNavigationEntries(myNavigationEntryVisitor, false);
            }
            SetRefreshButtonStatus(e.IsLoading);
        }

        public void InvokeAction(Action action)
        {
            this.InvokeOnUiThreadIfRequired(action);
            /*this.InvokeOnUiThreadIfRequired(() => {
                action();
                Invalidate();
                Update();
                Refresh();
                Application.DoEvents();
            });*/
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        public void GoBack()
        {
            if (chBrowser.CanGoBack)
            {
                SetGoBackButtonStatus(false);
                chBrowser.Back();
            }
        }
        private void SetGoBackButtonStatus(bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                btnBack.Enabled = status;
            });
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            GoForward();
        }
        public void GoForward()
        {
            if (chBrowser.CanGoForward)
            {
                SetGoForwardButtonStatus(false);
                chBrowser.Forward();
            }
        }
        private void SetGoForwardButtonStatus(bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                btnForward.Visible = btnForward.Enabled = status;
            });
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadUrl(SBBrowserSettings.HomePage);
        }
   
        private void SetGoHomeButtonStatus(bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                btnHome.Enabled = status;
            });
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chBrowser.Reload();
        }

        private void SetRefreshButtonStatus(bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (status)
                {
                    btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Close;
                }
                else
                {
                    btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
                }
            });
        }

        private bool tbUrlEntered = false;

        private void tbUrl_Enter(object sender, EventArgs e)
        {
            pnlUrl.BorderColor = Color.DeepSkyBlue;
            if (!tbUrlEntered)
            {
                tbUrl.SelectAll();
                tbUrlEntered = true;
            }

            UpdateAutoCompletion();
        }

        private void tbUrl_Leave(object sender, EventArgs e)
        {
            tbUrlEntered = false;
            if (pnlUrlBorderColor != null)
                pnlUrl.BorderColor = pnlUrlBorderColor;
        }

        private void tbUrl_Click(object sender, EventArgs e)
        {
            if (tbUrlEntered)
            {
                tbUrl.SelectAll();
            }

            tbUrlEntered = false;
        }
        private void tbUrl_KeyUp(object sender, KeyEventArgs e)
        {
            SBSiteInformationButtonStatus(false);
            if (e.KeyCode == Keys.Enter)
            {
                string url = tbUrl.Text;
                Uri uriResult;
                bool result = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uriResult);
                if(uriResult == null)
                {
                    LoadUrl(tbUrl.Text.GetSearchUrl());
                }
                else
                {
                    LoadUrl(tbUrl.Text);
                }
            }
        }
        private void SBSiteInformationButtonStatus(bool enabled, bool locked = false)
        {
            if (enabled)
            {
                if (locked)
                    btnSecure.IconChar = FontAwesome.Sharp.IconChar.Lock;
                else
                    btnSecure.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
                btnSearch.Visible = false;
                btnSecure.Visible = true;
            }
            else
            {
                btnSecure.Visible = false;
                btnSearch.Visible = true;
            }
        }
        private PopupForm siteInfoPopupForm;
        private void btnSecure_Click(object sender, EventArgs e)
        {
            ShowSiteInfo();
        }
        public void ShowSiteInfo()
        {
            if (siteInfoPopupForm == null)
            {
                Uri url = new Uri(chBrowser.Address);
                siteInfoPopupForm = new PopupForm()
                {
                    Owner = this,
                    OwnerControl = pnlUrl,
                    WhenClosed = () => { siteInfoPopupForm = null; },
                    PopupFormStyle = PopupFormStyle.Left,
                    MarginY = pnlNav.Padding.Vertical,
                    CloseOnClickOutSide = false,
                    Fullscreen = Fullscreen,
                };
                siteInfoPopupForm.Content = new SBSiteInformation(url, Icon) { OwnerForm = siteInfoPopupForm };
                siteInfoPopupForm.Show();
            }
            else
            {
                siteInfoPopupForm.Close();
                siteInfoPopupForm = null;
            }
        }
        public void CloseSiteInfo()
        {
            if(siteInfoPopupForm != null)
                siteInfoPopupForm.Close();
        }
        private void btnSecure_MouseHover(object sender, EventArgs e)
        {
            if (siteInfoPopupForm != null)
                siteInfoPopupForm.CloseOnClickOutSide = false;
        }
        private void btnSecure_MouseLeave(object sender, EventArgs e)
        {
            if (siteInfoPopupForm != null)
                siteInfoPopupForm.CloseOnClickOutSide = true;
        }

        private void AppContainer_LocationChanged(object sender, EventArgs e)
        {
            if (siteInfoPopupForm != null)
                siteInfoPopupForm.UpdateLocation();
            if (searchPopupForm != null)
                searchPopupForm.UpdateLocation();
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            string text = tbUrl.Text;
            try
            {
                tbUrl.Text = new Uri(text).GetUrlWithoutHTTP();
            }
            catch
            {

            }
        }
        public PopupForm searchPopupForm;
        public void ShowSearch()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (searchPopupForm == null)
                {
                    Uri url = new Uri(chBrowser.Address);
                    searchPopupForm = new PopupForm()
                    {
                        Owner = this,
                        OwnerControl = pnlUrl,
                        WhenClosed = () => { searchPopupForm = null; },
                        PopupFormStyle = PopupFormStyle.Right,
                        MarginY = pnlNav.Padding.Vertical,
                        AnimationEnabled = false,
                        CloseOnClickOutSide = false,
                        Fullscreen = Fullscreen,
                    };
                    searchPopupForm.Content = new SBSearch(this) { OwnerForm = searchPopupForm };
                    searchPopupForm.Show();
                }
                else
                {
                    searchPopupForm.Show();
                }
                SBSearch sbSearch = (SBSearch)searchPopupForm.Content;
                sbSearch.tbSearch.Focus();
            });
        }
        public void CloseSearch()
        {
            if (searchPopupForm != null)
                searchPopupForm.Close();
        }
 
        public bool Fullscreen = false;
        private Control parentControl;
        private Form fullScreenForm;
        private FormWindowState lastWindowState;
        public void SetFullscreen(ChromiumWebBrowser chromiumWebBrowser, bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (status)
                {
                    lastWindowState = AppContainer.WindowState;
                    AppContainer.WindowState = FormWindowState.Maximized;
                    parentControl = chromiumWebBrowser.Parent;
                    parentControl.Controls.Remove(chromiumWebBrowser);
                    fullScreenForm = new Form();
                    fullScreenForm.Icon = Icon;
                    fullScreenForm.Text = Text;
                    fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                    fullScreenForm.WindowState = FormWindowState.Maximized;
                    fullScreenForm.Controls.Add(chromiumWebBrowser);
                    fullScreenForm.ShowDialog(this);
                }
                else
                {
                    if(fullScreenForm != null)
                    {
                        AppContainer.WindowState = lastWindowState;
                        fullScreenForm.Controls.Remove(chromiumWebBrowser);
                        parentControl.Controls.Add(chromiumWebBrowser);
                        chromiumWebBrowser.BringToFront();
                        fullScreenForm.Close();
                        fullScreenForm.Dispose();
                        fullScreenForm = null;
                    }
                }
                CloseSiteInfo();
                CloseSearch();
                /*if (searchPopupForm != null)
                {
                    searchPopupForm.Fullscreen = status;
                    searchPopupForm.UpdateLocation();
                }*/
                Fullscreen = status;
            });
        }
        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {  
            return KeyEvents(chBrowser, CefEventFlags.None, keyData, base.ProcessCmdKey(ref msg, keyData));
        }*/
        public bool KeyEvents(ChromiumWebBrowser chromiumWebBrowser, CefEventFlags modifiers, Keys key, bool resp = true)
        {
            if (key == Keys.F2)
            {
                this.InvokeOnUiThreadIfRequired(()=> {
                    tbUrl.Focus();
                });
                return true;
            }
            else if (key == Keys.F3 || (modifiers == CefEventFlags.ControlDown && key == Keys.F) || (key == (Keys.Control | Keys.F)))
            {
                ShowSearch();
                return true;
            }
            else if ((modifiers == CefEventFlags.ControlDown && key == Keys.F5) || (key == (Keys.Control | Keys.F5)))
            {
                chBrowser.Reload(true);
                return true;
            }
            else if (key == Keys.F5)
            {
                chBrowser.Reload();
                return true;
            }
            else if ((modifiers == CefEventFlags.ControlDown && key == Keys.U) || (key == (Keys.Control | Keys.U))
            )
            {
                ViewSource();
                return true;
            }
            else if (
                key == Keys.F12
                || (modifiers == (CefEventFlags.ControlDown | CefEventFlags.AltDown) && key == Keys.I)
                || (key == (Keys.Control | Keys.Alt | Keys.I))
            )
            {
                if (_devToolsEnabled)
                {
                    HideDevTools();
                }
                else
                {
                    ShowDevTools();
                }
                return true;
            }
            /*else if (key == Keys.Escape)
            {
                if (Fullscreen)
                {
                    SetFullscreen(chromiumWebBrowser, false);
                }
                return true;
            }*/
            return resp;
        }

        private SBDevTools DevTools;
        private bool _devToolsEnabled = false;
        public void ShowDevTools(int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (DevTools == null)
                    DevTools = chBrowser.ShowDevToolsDockedCustom(
                        pnlChBrowser,
                        dockStyle: DockStyle.Right,
                        inspectElementAtX: inspectElementAtX,
                        inspectElementAtY: inspectElementAtY
                    );
                else
                {
                    pnlChBrowser.Controls.Add(DevTools);
                    DevTools.UpdateElementLocation(inspectElementAtX, inspectElementAtY);
                }
                _devToolsEnabled = true;
            });
        }
        public void HideDevTools()
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if(DevTools != null)
                    pnlChBrowser.Controls.Remove(DevTools);
                _devToolsEnabled = false;
            });
        }
        public void ViewSource()
        {
            OpenInNewTab("view-source:" + chBrowser.Address, true);
        }
    }
}
