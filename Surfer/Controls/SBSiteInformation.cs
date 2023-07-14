using Microsoft.Win32;
using Surfer.Utils;
using Surfer.Utils.Browser;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public partial class SBSiteInformation : UserControl
    {

        public Form OwnerForm{ get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (OwnerForm != null)
                OwnerForm.Close();
        }

        private bool _isSecure = false;
        public SBSiteInformation(Uri url, Icon icon)
        {
            InitializeComponent();
            lblTitle.Text = string.Format(Locale.Get.about_site, url.Host);
            _isSecure = SBBrowserSettings.IsSecureUrl(url.AbsoluteUri);
            lblConnInfo.Text = _isSecure ? Locale.Get.conn_is_secure : Locale.Get.conn_is_not_secure;
            InitializeColors();
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBSiteInformation_Disposed;
        }

        private void SBSiteInformation_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            if (!_isSecure)
                lblConnInfo.ForeColor = Color.Red;
            else
                lblConnInfo.ForeColor = Theme.Get.ColorText;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            InitializeColors();
        }
    }
}
