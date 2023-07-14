using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public class SBButton: Button
    {
        public SBButton()
        {
            BackColor = Color.Transparent;
            InitializeColors();
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBButton_Disposed;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            InitializeColors();
        }

        private void SBButton_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            ForeColor = Theme.Get.ColorText;
            FlatAppearance.MouseDownBackColor = Theme.Get.ColorButtonPressed;
            FlatAppearance.MouseOverBackColor = Theme.Get.ColorButtonHover;
        }
    }
}
