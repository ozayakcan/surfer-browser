using System;
using System.Drawing;
using System.Windows.Forms;
using Surfer.Forms;
using Surfer.Utils;
using Surfer.Utils.Browser;

namespace Surfer.Controls
{
    public partial class FavoriteControl : UserControl
    {

        public Image Icon
        {
            get
            {
                return btnFavoriteUrl.Image;
            }
            set
            {
                btnFavoriteUrl.Image = value;
            }
        }
        public string Title
        {
            get
            {
                return btnFavoriteUrl.Text;
            }
            set
            {
                btnFavoriteUrl.Text = value;
            }
        }
        public string Url {get;set;}

        Browser MyBrowser;
        public FavoriteControl(Browser browser)
        {
            MyBrowser = browser;
            InitializeComponent();
            tsmiDelete.Text = Locale.Get.delete;
        }

        private void btnFavoriteUrl_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
                MyBrowser.OpenInNewTab(Url);
            else
                MyBrowser.LoadUrl(Url);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            FavoriteManager.Delete(Url, () =>
            {
                MyBrowser.DeleteFavoriteInAllTabs(Url);
            });
        }
    }
}
