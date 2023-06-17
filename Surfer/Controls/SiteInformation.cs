using Surfer.BrowserSettings;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public partial class SiteInformation : UserControl
    {

        public Form OwnerForm{ get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (OwnerForm != null)
                OwnerForm.Close();
        }

        private bool _isSecure = false;
        public SiteInformation(Uri url, Icon icon)
        {
            InitializeComponent();
            lblTitle.Text = "About " + url.Host;
            _isSecure = MyBrowserSettings.IsSecureUrl(url.AbsoluteUri);
            lblConnInfo.Text = _isSecure ? "Connection is secure" : "Your connection to this site isn't secure";
            if (!_isSecure)
                lblConnInfo.ForeColor = Color.Red;
        }
    }
}
