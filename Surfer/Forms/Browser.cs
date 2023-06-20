using CefSharp;
using CefSharp.WinForms;
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
        public string StartUrl {get; set;}
        public Icon OriginalIcon = Properties.Resources.tab_icon;
        public Icon SiteIcon;
        public MyAppContainer AppContainer { get; set; }
        public TitleBarTab Tab { get; set; }

        Color pnlUrlBorderColor;
        public Browser(MyAppContainer appContainer, TitleBarTab titlebarTab)
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.BrowserCache();
            cefSettings.PersistSessionCookies = true;
            cefSettings.PersistUserPreferences = true;
            cefSettings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            if (!Cef.IsInitialized)
                Cef.Initialize(cefSettings);
            if(!HistoryManager.IsInitialized)
                HistoryManager.Initialize();
            AppContainer = appContainer;
            Tab = titlebarTab;
            InitializeComponent();
            pnlUrlBorderColor = pnlUrl.BorderColor;
            if (StartUrl != null)
            {
                tbUrl.Text = StartUrl;
                SiteInformationButtonStatus(true, MyBrowserSettings.IsSecureUrl(StartUrl));
            }
            else
                SiteInformationButtonStatus(false);
            tsNav.Renderer = new MyRenderer();
            tsUrl.Renderer = new MyRenderer();
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
            chBrowser.DisplayHandler = new MyDisplayHandler(this);
            chBrowser.RequestHandler = new MyRequestHandler(this);
            chBrowser.FindHandler = new MyFindHandler(this);
            chBrowser.KeyboardHandler = new MyKeyboardHandler(this);
            SetGoBackButtonStatus(chBrowser.CanGoBack);
            SetGoForwardButtonStatus(chBrowser.CanGoForward);
            if (!string.IsNullOrEmpty(StartUrl) && !string.IsNullOrWhiteSpace(StartUrl))
                LoadUrl(StartUrl);
        }

        private void chBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            InvokeAction(() =>
            {
                chBrowser.Focus();
            });
        }

        private void chBrowser_LoadError(object sender, LoadErrorEventArgs e)
        {
            if (e.ErrorText == ErrorTexts.NameNotResolved)
                LoadUrl(lastUrl.GetSearchUrl());
        }
        internal void OpenInNewTab(string targetUrl)
        {
            InvokeAction(() =>
            {
                TitleBarTab titleBarTab = new TitleBarTab(AppContainer);
                titleBarTab.Content = new Browser(AppContainer, titleBarTab)
                {
                    StartUrl = targetUrl
                };
                int index = AppContainer.SelectedTabIndex;
                AppContainer.Tabs.Insert(index + 1, titleBarTab);
                AppContainer.SelectedTabIndex = index + 1;
                AppContainer.SelectedTabIndex = index;
            });
        }

        public void OnAddressChanged(AddressChangedEventArgs addressChangedArgs)
        {
            InvokeAction(() => {
                tbUrl.Text = chBrowser.Address;
                if (fullScreenForm != null)
                    fullScreenForm.Text = chBrowser.Address;
                SiteInformationButtonStatus(true, MyBrowserSettings.IsSecureUrl(chBrowser.Address));
                HistoryManager.Save(
                    chBrowser.Address,
                    increaseVisited: true,
                    onSaved: ()=> {
                        UpdateAutoCompletion();
                    });
                OnFavIconUrlChanged(chBrowser.Address);
            });
        }

        // Url Auto Complete
        private void UpdateAutoCompletion()
        {
            InvokeAction(() =>
            {
                AutoCompleteStringCollection autoCompleteString = new AutoCompleteStringCollection();
                autoCompleteString.AddRange(HistoryManager.Get.Select(h => h.url).ToArray());
                tbUrl.AutoCompleteCustomSource = autoCompleteString;
            });
        }

        public void OnFavIconUrlChanged(string url, string faviconUrl = "")
        {
            HistoryManager.Save(
                url,
                favicon: faviconUrl/*,
                onSaved: () => {
                    UpdateAutoCompletion();
                }*/);
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
            InvokeAction(() => {
                Icon = Tab.Icon = SiteIcon = icon;
                if (fullScreenForm != null)
                    fullScreenForm.Icon = icon;
                Tab.Parent.UpdateThumbnailPreviewIcon(Tab, icon);

            });
        }

        internal void TitleChanged(string url, TitleChangedEventArgs titleChangedArgs)
        {
            InvokeAction(() => {
                Text = titleChangedArgs.Title;
                HistoryManager.Save(
                    url,
                    title: titleChangedArgs.Title/*,
                    onSaved: () => {
                        UpdateAutoCompletion();
                    }*/);
            });
        }
        public void ShowLoading(int progress)
        {
            InvokeAction(() =>
            {
                pnlProgress.Visible = true;
                pbLoading.Value = progress;
                SetRefreshButtonStatus(false);
            });
        }

        public void HideLoading()
        {
            InvokeAction(() =>
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
            }
            SetRefreshButtonStatus(e.IsLoading);
        }

        public void InvokeAction(Action action)
        {
            if (!chBrowser.IsDisposed)
            {
                Invoke(new Action(() => {
                    action();
                    this.Invalidate();
                    this.Update();
                    this.Refresh();
                    Application.DoEvents();
                }));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chBrowser.CanGoBack)
            {
                SetGoBackButtonStatus(false);
                chBrowser.Back();
            }
        }
        private void SetGoBackButtonStatus(bool status)
        {
            InvokeAction(() =>
            {
                btnBack.Enabled = status;
            });
        }
        private void btnForward_Click(object sender, EventArgs e)
        {

            if (chBrowser.CanGoForward)
            {
                SetGoForwardButtonStatus(false);
                chBrowser.Forward();
            }
        }

        private void SetGoForwardButtonStatus(bool status)
        {
            InvokeAction(() =>
            {
                btnForward.Visible = btnForward.Enabled = status;
            });
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadUrl(MyBrowserSettings.HomePage);
        }
   
        private void SetGoHomeButtonStatus(bool status)
        {
            InvokeAction(() =>
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
            InvokeAction(() =>
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
            SiteInformationButtonStatus(false);
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
        private void SiteInformationButtonStatus(bool enabled, bool locked = false)
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
                siteInfoPopupForm.Content = new SiteInformation(url, Icon) { OwnerForm = siteInfoPopupForm };
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
            InvokeAction(() =>
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
                    searchPopupForm.Content = new Search(this) { OwnerForm = searchPopupForm };
                    searchPopupForm.Show();
                }
                else
                {
                    searchPopupForm.Show();
                }
                Search search = (Search)searchPopupForm.Content;
                search.tbSearch.Focus();
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
            chromiumWebBrowser.InvokeOnUiThreadIfRequired(() =>
            {
                if (status)
                {
                    lastWindowState = AppContainer.WindowState;
                    AppContainer.WindowState = FormWindowState.Maximized;
                    //parentControl = chromiumWebBrowser.Parent;
                    pnlBrowser.Controls.Remove(chromiumWebBrowser);
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
                        pnlBrowser.Controls.Add(chromiumWebBrowser);
                        fullScreenForm.Close();
                        fullScreenForm.Dispose();
                        fullScreenForm = null;
                    }
                }
                CloseSiteInfo();
                if (searchPopupForm != null)
                {
                    searchPopupForm.Fullscreen = status;
                    searchPopupForm.UpdateLocation();
                }
            });
            Fullscreen = status;
        }
        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {  
            return KeyEvents(chBrowser, CefEventFlags.None, keyData, base.ProcessCmdKey(ref msg, keyData));
        }*/
        public bool KeyEvents(ChromiumWebBrowser chromiumWebBrowser, CefEventFlags modifiers, Keys key, bool resp = true)
        {
            if (key == Keys.F2)
            {
                InvokeAction(()=> {
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
            else if (
                key == Keys.F12 
                || (modifiers == (CefEventFlags.ControlDown | CefEventFlags.AltDown) && key == Keys.I) 
                || (key == (Keys.Control | Keys.Alt | Keys.I))
            )
            {
                Invoke((MethodInvoker)delegate
                {
                    if (DevTools == null)
                    {
                        pnlRight.Controls.Clear();
                        DevTools = chBrowser.ShowDevToolsDocked(pnlRight, dockStyle: DockStyle.Right);
                        if(pnlRight.Controls.Count == 0)
                            pnlRight.Controls.Add(DevTools);
                        pnlRight.BackColor = DevTools.BackColor;
                    }
                    else
                    {
                        //chBrowser.CloseDevTools();
                        pnlRight.Controls.Remove(DevTools);
                        DevTools = null;
                    }
                });
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
        Control DevTools;
        private void pnlRight_ControlAdded(object sender, ControlEventArgs e)
        {
            SetPnlRightSize();
        }

        private void pnlRight_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetPnlRightSize();
        }

        private void SetPnlRightSize()
        {
            int width = 0;
            foreach (Control cntrl in pnlRight.Controls)
            {
                width += cntrl.Size.Width;
            }
            pnlRight.Size = new Size(width, pnlRight.Size.Height);
        }
    }
}
