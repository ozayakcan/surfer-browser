using EasyTabs;
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
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 450);
            this.WindowState = FormWindowState.Normal;
            this.MinimumSize = new Size(400, 400);
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new Browser {
                    Text = "New Tab",
                    StartUrl = MyBrowserSettings.HomePage,
                }
            };
        }
    }
}
