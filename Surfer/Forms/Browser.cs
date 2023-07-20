using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using Etier.IconHelper;
using FontAwesome.Sharp;
using Microsoft.Win32;
using Surfer.Controls;
using Surfer.Utils;
using Surfer.Utils.Browser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
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
        public System.Drawing.Icon OriginalIconLight
        {
            get => System.Drawing.Icon.FromHandle(IconChar.Table.ToBitmap(Theme.of(false).ColorText).GetHicon());
        }
        public System.Drawing.Icon OriginalIconDark
        {
            get => System.Drawing.Icon.FromHandle(IconChar.Table.ToBitmap(Theme.of(true).ColorText).GetHicon());
        }
        public System.Drawing.Icon SiteIcon;
        public SBAppContainer AppContainer { get; set; }
        public TitleBarTab Tab { get; set; }

        MyNavigationEntryVisitor myNavigationEntryVisitor;

        Color pnlUrlBorderColor;
        public Browser(SBAppContainer appContainer, TitleBarTab titlebarTab)
        {
            AppContainer = appContainer;
            Tab = titlebarTab;
            InitializeComponent();
            tbUrl.CanAddUndoRedo = (text) =>
            {
                try
                {
                    return text.StartsWith(new Uri(text).Host);
                }
                catch
                {
                    return true;
                }
            };
            Name = Locale.Get.new_tab;
            Text = Locale.Get.new_tab;
            ttNav.SetToolTip(btnSecure, Locale.Get.show_site_information);
            ttNav.SetToolTip(btnBack, Locale.Get.back);
            ttNav.SetToolTip(btnForward, Locale.Get.forward);
            ttNav.SetToolTip(btnHome, Locale.Get.go_home);
            ttNav.SetToolTip(btnReload, string.Format(Locale.Get.reload_w_key, SBShortcutKeys.Reload.ToText()));
            ttNav.SetToolTip(btnFavorite, string.Format(Locale.Get.add_to_favorites, SBShortcutKeys.AddToFavorites.ToText()));
            ttNav.SetToolTip(btnDownload, Locale.Get.downloads);
            Icon = Properties.Resources.icon;
            pnlUrlBorderColor = pnlUrl.BorderColor;
            AppContainer.LocationChanged += new EventHandler(AppContainer_LocationChanged);
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += Browser_Disposed;
        }

        private void Browser_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
            InitializeTBUrlContextMenu();
        }

        public void InitializeColors(bool isFirst = false)
        {
            if (Icon == OriginalIconLight || Icon == OriginalIconDark || isFirst)
                SetIcon(Theme.IsDark ? OriginalIconDark : OriginalIconLight, Properties.Resources.icon);
        }

        private void InitializeTBUrlContextMenu(bool isFirst = false)
        {
            if (isFirst)
            {
                tsmiUndo.Text = Locale.Get.undo;
                tsmiUndo.ShortcutKeys = SBShortcutKeys.Undo.ToKey();
                tsmiRedo.Text = Locale.Get.redo;
                tsmiRedo.ShortcutKeys = SBShortcutKeys.Redo.ToKey();
                tsmiCut.Text = Locale.Get.cut;
                tsmiCut.ShortcutKeys = SBShortcutKeys.Cut.ToKey();
                tsmiCopy.Text = Locale.Get.copy;
                tsmiCopy.ShortcutKeys = SBShortcutKeys.Copy.ToKey();
                tsmiPaste.Text = Locale.Get.paste;
                tsmiPaste.ShortcutKeys = SBShortcutKeys.Paste.ToKey();
                tsmiDelete.Text = Locale.Get.delete;
                tsmiSelectAll.Text = Locale.Get.select_all;
                tsmiSelectAll.ShortcutKeys = SBShortcutKeys.SelectAll.ToKey();
            }
            tsmiUndo.Image = IconChar.Undo.ToBitmap(Theme.Get.ColorText);
            tsmiRedo.Image = IconChar.Redo.ToBitmap(Theme.Get.ColorText);
            tsmiCut.Image = IconChar.Cut.ToBitmap(Theme.Get.ColorText);
            tsmiCopy.Image = IconChar.Copy.ToBitmap(Theme.Get.ColorText);
            tsmiPaste.Image = IconChar.Paste.ToBitmap(Theme.Get.ColorText);
            tsmiDelete.Image = IconChar.TrashCan.ToBitmap(Theme.Get.ColorText);
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
            InitializeColors(true);
            InitializeTBUrlContextMenu(true);
            chBrowser.DisplayHandler = new SBDisplayHandler(this);
            chBrowser.RequestHandler = new SBRequestHandler(this);
            chBrowser.FindHandler = new SBFindHandler(this);
            chBrowser.KeyboardHandler = new SBKeyboardHandler(this);
            chBrowser.MenuHandler = new SBContextMenuHandler(this);
            chBrowser.LifeSpanHandler = new SBLifeSpanHandler(this);
            chBrowser.DownloadHandler = new SBDownloadHandler(this);
            SetGoBackButtonStatus(chBrowser.CanGoBack);
            SetGoForwardButtonStatus(chBrowser.CanGoForward);
            myNavigationEntryVisitor = new MyNavigationEntryVisitor(this);
            InitializeDownloadsForm();
            InitializeFavorites();
            if (!string.IsNullOrEmpty(StartUrl) && !string.IsNullOrWhiteSpace(StartUrl))
                LoadUrl(StartUrl);
            InitializeTBUrlContextMenuButtonStatus();
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
                        System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(thumb.GetHicon());
                        SetIcon(icon, icon);
                    }
                }
                catch
                {
                    SetIcon(Theme.IsDark ? OriginalIconDark : OriginalIconLight, Properties.Resources.icon);
                }
            }
            else
            {
                SetIcon(Theme.IsDark ? OriginalIconDark : OriginalIconLight, Properties.Resources.icon);
            }
        }
        private void SetIcon(System.Drawing.Icon tabIcon, System.Drawing.Icon thumbnailIcon)
        {
            this.InvokeOnUiThreadIfRequired(() => {
                if (Tab != null)
                    Tab.Icon = tabIcon;
                Icon = SiteIcon = tabIcon;
                if (fullScreenForm != null)
                    fullScreenForm.Icon = tabIcon;
                if (Tab != null)
                    Tab.Parent.UpdateThumbnailPreviewIcon(Tab, thumbnailIcon);
            });
        }
        public void ShowLoading(int progress)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                pnlLoading.Visible = true;
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
                pnlLoading.Visible = true;
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
        private void btnReload_Click(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload(bool ignoreCache = false)
        {
            chBrowser.Reload(ignoreCache);
        }
        private void SetRefreshButtonStatus(bool status)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (status)
                {
                    btnReload.IconChar = FontAwesome.Sharp.IconChar.Close;
                }
                else
                {
                    btnReload.IconChar = FontAwesome.Sharp.IconChar.Refresh;
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
        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            string text = tbUrl.Text;
            try
            {
                tbUrl.Text = new Uri(text).GetUrlWithoutHTTP();
                if (tbUrlEntered)
                {
                    tbUrl.SelectionStart = tbUrl.Text.Length;
                    tbUrl.SelectionLength = 0;
                }
            }
            catch
            {

            }
            InitializeTBUrlContextMenuButtonStatus();
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
            if (SBShortcutKeys.FocusUrlBox.IsPressed(modifiers, key))
            {
                this.InvokeOnUiThreadIfRequired(()=> {
                    tbUrl.Focus();
                });
                return true;
            }
            else if (SBShortcutKeys.Search1.IsPressed(modifiers, key) || SBShortcutKeys.Search2.IsPressed(modifiers, key))
            {
                ShowSearch();
                return true;
            }
            else if (SBShortcutKeys.ReloadNoCache.IsPressed(modifiers, key))
            {
                Reload(true);
                return true;
            }
            else if (SBShortcutKeys.Reload.IsPressed(modifiers, key))
            {
                Reload();
                return true;
            }
            else if (SBShortcutKeys.ViewSource.IsPressed(modifiers, key))
            {
                ViewSource();
                return true;
            }
            else if (SBShortcutKeys.Inspect1.IsPressed(modifiers, key) || SBShortcutKeys.Inspect2.IsPressed(modifiers, key))
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
            else if (SBShortcutKeys.Print.IsPressed(modifiers, key))
            {
                Print();
                return true;
            }
            else if (SBShortcutKeys.CloseTab.IsPressed(modifiers, key))
            {
                AppContainer.CloseSelectedTab();
                return true;
            }
            else if (SBShortcutKeys.SaveAs.IsPressed(modifiers, key))
            {
                SaveAs();
                return true;
            }
            else if (SBShortcutKeys.ToggleFavorites.IsPressed(modifiers, key))
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    foreach (var tab in AppContainer.Tabs)
                    {
                        Browser br = (Browser)tab.Content;
                        br.SetFavoritesPanelStatus(!pnlFavorites.Visible);
                    }
                });
                return true;
            }
            else if (SBShortcutKeys.AddToFavorites.IsPressed(modifiers, key))
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    SaveFavorite();
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
        private bool _isPopup = false;
        public bool IsPopup
        {
            get
            {
                return _isPopup;
            }
            set
            {
                _isPopup = tbUrl.ReadOnly = value;
            }
        }
        public void Print()
        {
            chBrowser.Print();
        }
        public void SaveAs()
        {
            chBrowser.GetSourceAsync().ContinueWith(taskHtml =>
            {
                if (taskHtml.IsCompleted)
                {
                    var html = taskHtml.Result;
                    Thread thread = new Thread(() =>{
                        System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                        saveFileDialog.InitialDirectory = DownloadManager.Location;
                        saveFileDialog.Title = "Save text Files";
                        saveFileDialog.DefaultExt = "html";
                        saveFileDialog.Filter = string.Format(Locale.Get.save_as_complete_filter, "(*.html)|*.html");
                        saveFileDialog.FileName = Text;
                        saveFileDialog.RestoreDirectory = true;
                        DialogResult dialogResult = saveFileDialog.ShowDialog();
                        if(dialogResult == DialogResult.OK)
                        {
                            try
                            {
                                FileHandler.Write(saveFileDialog.FileName, html);
                                string tempLocation = Path.GetDirectoryName(saveFileDialog.FileName) + Path.GetFileName(saveFileDialog.FileName) + DownloadManager.Extension;
                                DownloadFile downloadFile = new DownloadFile(
                                        DownloadManager.LastID(),
                                        0,
                                        Path.GetFileName(saveFileDialog.FileName),
                                        Path.GetExtension(saveFileDialog.FileName),
                                        saveFileDialog.FileName,
                                        tempLocation,
                                        tbUrl.Text,
                                        DateTime.Now
                                    );
                                downloadFile.Completed = true;
                                downloadFile.IsWebPage = true;
                                AppContainer.sBDownloads.AddItem(downloadFile);
                            }catch(Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                            
                        }
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
            });
    }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ShowDownloadsForm();
        }
        public void ShowDownloadsForm()
        {
            AppContainer.ShowDownloadsForm(this, pnlButtons, pnlNav.Padding.Top + pnlNav.Padding.Bottom);
        }
        private void InitializeDownloadsForm()
        {
            AppContainer.InitializeDownloadsForm(this, pnlButtons, pnlNav.Padding.Top + pnlNav.Padding.Bottom);
        }

        private void SetFavoritesPanelStatus(bool status)
        {
            pnlFavorites.Visible = status;
            Settings.User.Save(nameof(Settings.FavoritesPanelEnabled), status);
        }
        public void InitializeFavorites()
        {
            foreach(var fav in FavoriteManager.Get)
            {
                FavoriteControl favoriteControl = null;
                int controlIndex = GetFavoriteControlIndex(fav.Url);
                if(controlIndex >= 0)
                    favoriteControl = (FavoriteControl)pnlFavorites.Controls[controlIndex];
                AddToFavorite(
                    IconReader.BytesToBitmap(fav.Favicon),
                    fav.Title,
                    fav.Url,
                    favoriteControl
                );
            }
            SetFavoritesPanelStatus(Settings.User.Get(nameof(Settings.FavoritesPanelEnabled), Settings.FavoritesPanelEnabled));
        }
        public void DeleteFavoriteInAllTabs(string url)
        {
            foreach (var tab in AppContainer.Tabs)
            {
                Browser br = (Browser)tab.Content;
                br.DeleteFavoriteControl(url);
            }
        }
        private void DeleteFavoriteControl(string url)
        {
            int controlIndex = GetFavoriteControlIndex(url);
            if (controlIndex >= 0)
                pnlFavorites.Controls.RemoveAt(controlIndex);
        }
        private void btnFavorite_Click(object sender, EventArgs e)
        {
            SaveFavorite();
        }
        private void SaveFavorite()
        {
            FavoriteManager.Save(new Favorite(IconReader.BitmapToBytes(Icon.ToBitmap()), Text, chBrowser.Address), () => {
                foreach (var tab in AppContainer.Tabs)
                {
                    Browser br = (Browser)tab.Content;
                    br.InitializeFavorites();
                }
            });
        }

        private void tbUrl_DragOver(object sender, DragEventArgs e)
        {
            if (DragDropHandler.IsValidFile(e))
            {
                tbUrl.Focus();
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tbUrl_DragDrop(object sender, DragEventArgs e)
        {
            var fileList = DragDropHandler.GetFileList(e);

            foreach(DragDropItem item in fileList)
            {
                tbUrl.Text = item.TargetPath;
            }
            if(fileList.Count > 0)
            {
                tbUrl.SelectAll();
            }
        }
        private void pnlFavorites_DragOver(object sender, DragEventArgs e)
        {
            if (DragDropHandler.IsValidFile(e))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pnlFavorites_DragDrop(object sender, DragEventArgs e)
        {
            var fileList = DragDropHandler.GetFileList(e);

            foreach (DragDropItem item in fileList)
            {
                FavoriteControl favoriteControl = null;
                int controlIndex = GetFavoriteControlIndex(item.TargetPath);
                if (controlIndex >= 0)
                    favoriteControl = (FavoriteControl)pnlFavorites.Controls[controlIndex];
                AddToFavorite(
                    Properties.Resources.icon.ToBitmap(),
                    item.Name,
                    item.TargetPath,
                    favoriteControl,
                    true
                );
            }
        }
        private int GetFavoriteControlIndex(string url)
        {
            if (pnlFavorites.Controls.Count > 0)
            {
                Control.ControlCollection favoriteControls = pnlFavorites.Controls;
                int controlIndex = favoriteControls.FindIndex((c) => ((FavoriteControl)c).Url == url);
                return controlIndex;
            }
            return -1;
        }
        private void AddToFavorite(Bitmap icon, string title, string url, FavoriteControl favoriteControl = null, bool addToFavorite = false)
        {
            bool favoriteExists = false;
            if (favoriteControl != null)
                favoriteExists = true;
            else
                favoriteControl = new FavoriteControl(this);
            favoriteControl.Dock = DockStyle.Left;
            favoriteControl.Icon = icon;
            favoriteControl.Title = title;
            favoriteControl.Url = url;
            if (!favoriteExists)
            {
                pnlFavorites.Controls.Add(favoriteControl);
                favoriteControl.BringToFront();
            }
            if (addToFavorite)
                FavoriteManager.Save(new Favorite(IconReader.BitmapToBytes(icon), title, url));
        }

        private void btnBack_VisibleChanged(object sender, EventArgs e)
        {
            btnBackMargin.Visible = ((Control)sender).Visible;
        }

        private void btnForward_VisibleChanged(object sender, EventArgs e)
        {
            btnForwardMargin.Visible = ((Control)sender).Visible;
        }

        private void btnHome_VisibleChanged(object sender, EventArgs e)
        {
            btnHomeMargin.Visible = ((Control)sender).Visible;
        }

        private void btnReload_VisibleChanged(object sender, EventArgs e)
        {
            btnReloadMargin.Visible = ((Control)sender).Visible;
        }

        private void tbUrlContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!tbUrlEntered)
                tbUrl.Focus();
            InitializeTBUrlContextMenuButtonStatus();
        }

        private void InitializeTBUrlContextMenuButtonStatus()
        {
            tsmiUndo.Enabled = tbUrl.CanUndo;
            tsmiRedo.Enabled = tbUrl.CanRedo;
            tsmiCut.Enabled = CanCut();
            tsmiCopy.Enabled = CanCopy();
            tsmiPaste.Enabled = CanPaste();
            tsmiDelete.Enabled = CanDelete();
            tsmiSelectAll.Enabled = CanSelectAll();
        }
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            if (tbUrl.CanUndo)
                tbUrl.Undo();
        }
        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            if (tbUrl.CanRedo)
                tbUrl.Redo();
        }
        private bool CanCut()
        {
            return !tbUrl.ReadOnly && tbUrl.SelectionLength > 0;
        }
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            if(CanCut())
                tbUrl.Cut();
        }
        private bool CanCopy()
        {
            return tbUrl.SelectionLength > 0;
        }
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            if (CanCopy())
                tbUrl.Copy();
        }
        private bool CanPaste()
        {
            return Clipboard.GetText().Length > 0;
        }
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            if (CanPaste())
                tbUrl.Paste();
        }
        private bool CanDelete()
        {
            return tbUrl.SelectionLength > 0;
        }
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (CanDelete())
            {
                int selectionStart = tbUrl.SelectionStart;
                tbUrl.Text = tbUrl.Text.Remove(selectionStart, tbUrl.SelectionLength);
                tbUrl.SelectionStart = selectionStart;
            }
        }

        private bool CanSelectAll()
        {
            return tbUrl.SelectionLength < tbUrl.Text.Length;
        }
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            if (CanSelectAll())
                tbUrl.SelectAll();
        }
    }
}
