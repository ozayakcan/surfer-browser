using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using Surfer.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Surfer
{
    public partial class Browser : Form
    {
        public string StartUrl {get; set;}
        public Icon OriginalIcon = Properties.Resources.tab_icon;
        public Icon SiteIcon;
        private TitleBarTab _tab;
        public TitleBarTab Tab
        {
            get
            {
                return _tab;
            }
            set
            {
                _tab = value;
            }
        }
        public Browser(TitleBarTab titlebarTab)
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.AppData("Cache");
            if (!Cef.IsInitialized)
                Cef.Initialize(cefSettings);
            Tab = titlebarTab;
            InitializeComponent();
        }

        private void tbUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                LoadUrl(tbUrl.Text);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadUrl(tbUrl.Text);
        }

        public void LoadUrl(string url)
        {
            chBrowser.Load(url);
        }
        public void SetIcon(Icon icon)
        {
            InvokeAction(new Action(() => {
                Icon = Tab.Icon = SiteIcon = icon;
                Tab.Parent.UpdateThumbnailPreviewIcon(Tab, icon);
            }));
        }
        ChromiumWebBrowser chBrowser;
        private void Browser_Load(object sender, EventArgs e)
        {
            chBrowser = new ChromiumWebBrowser(tbUrl.Text);
            chBrowser.Dock = DockStyle.Fill;
            chBrowser.LoadingStateChanged += ChBrowser_LoadingStateChanged;
            chBrowser.AddressChanged += ChBrowser_AddressChanged;
            chBrowser.TitleChanged += ChBrowser_TitleChanged;
            pnlBrowser.Controls.Add(chBrowser);
            if (!string.IsNullOrEmpty(StartUrl) && !string.IsNullOrWhiteSpace(StartUrl))
                LoadUrl(StartUrl);
        }

        private void ChBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            /*if (e.IsLoading)
            {
                InvokeAction(new Action(() =>
                {
                    Icon = OriginalIcon;
                }));
            }
            else
            {
                
            }*/
        }

        private void ChBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            InvokeAction(new Action(() => {
                tbUrl.Text = e.Address;
            }));
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    using (HttpResponseMessage httpResponse = httpClient.GetAsync(e.Address).Result)
                    {
                        using (HttpContent httpContent = httpResponse.Content)
                        {
                            string html = httpContent.ReadAsStringAsync().Result;
                            //var html = taskHtml.Result;
                            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(html);
                            string iconPath = "";
                            string url = new Uri(e.Address).GetLeftPart(UriPartial.Authority);
                            // From Meta
                            iconPath = FindIcon(url, doc, "meta", "itemprop", new string[] { "image" }, "content");
                            // From link
                            iconPath = FindIcon(url, doc, "link", "rel", new string[] { "icon" }, "href", iconPath);
                            iconPath = FindIcon(url, doc, "link", "rel", new string[] { "shortcut icon" }, "href", iconPath);
                            if (iconPath != "")
                            {
                                using (WebClient client = new WebClient())
                                {

                                    WebClient wc = new WebClient();
                                    byte[] originalData = wc.DownloadData(iconPath);
                                    MemoryStream stream = new MemoryStream(originalData);
                                    Bitmap bmp = new Bitmap(stream);
                                    var thumb = (Bitmap)bmp.GetThumbnailImage(32, 32, null, IntPtr.Zero);
                                    thumb.MakeTransparent();
                                    Icon icon = Icon.FromHandle(thumb.GetHicon());
                                    SetIcon(icon);
                                }
                            }
                            else
                            {
                                SetIcon(OriginalIcon);
                            }
                        }
                    }
                }
            }catch(Exception exception)
            {
                SetIcon(OriginalIcon);
            }
            
        }

        private void ChBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            InvokeAction(new Action(() => {
                Text = e.Title;
            }));
        }

        private void InvokeAction(Action action)
        {
            Invoke(new Action(() => {
                action();
                this.Invalidate();
                this.Update();
                this.Refresh();
                Application.DoEvents();
            }));
        }

        public string FindIcon(string url, HtmlAgilityPack.HtmlDocument doc, string tag, string attr, string[] attrEqs, string res, string original = "")
        {
            foreach (var attrEq in attrEqs)
            {

                var node = doc.DocumentNode.SelectSingleNode("/html/head/" + tag + "[@" + attr + "='" + attrEq + "' and @" + res + "]");
                if (node != null)
                {
                    string icon = node.Attributes[res].Value;

                    if (icon.ToLower().StartsWith("http"))
                    {
                        return icon;
                    }
                    else
                    {
                        return url + (icon.StartsWith("/") ? icon : "/" + icon);
                    }
                }
            }
            return original;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chBrowser.CanGoBack)
            {
                chBrowser.Back();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {

            if (chBrowser.CanGoForward)
            {
                chBrowser.Forward();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadUrl(MyBrowserSettings.HomePage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chBrowser.Reload();
        }
        private bool tbUrlEntered = false;

        private void tbUrl_Enter(object sender, EventArgs e)
        {
            tbUrl.SelectAll();
            tbUrlEntered = true;
        }

        private void tbUrl_Click(object sender, EventArgs e)
        {
            if (tbUrlEntered)
            {
                tbUrl.SelectAll();
            }

            tbUrlEntered = false;
        }
    }
}
