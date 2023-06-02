using CefSharp;
using CefSharp.WinForms;
using Surfer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surfer
{
    public partial class Browser : Form
    {
        public Browser()
        {
            CefSettings cefSettings = new CefSettings();
            cefSettings.CachePath = Paths.AppData("Cache");
            if (!Cef.IsInitialized)
                Cef.Initialize(cefSettings);
            InitializeComponent();
        }

        private void tbUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                browser.Load(tbUrl.Text);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            browser.Load(tbUrl.Text);
        }
        ChromiumWebBrowser browser;
        private void Browser_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser(tbUrl.Text);
            browser.Dock = DockStyle.Fill;
            this.pnlBrowser.Controls.Add(browser);
        }
    }
}
