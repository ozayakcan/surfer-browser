using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public class SBLinkLabel: LinkLabel
    {
        public SBLinkLabel()
        {
            BackColor = Color.Transparent;
            InitializeColors();
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBPanelDark_Disposed;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            InitializeColors();
        }
        private void SBPanelDark_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            ForeColor = LinkColor = Theme.Get.ColorLink;
        }
    }
}
