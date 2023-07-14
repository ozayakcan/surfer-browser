using FontAwesome.Sharp;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public partial class SBIconButton: IconButton
    {
        private bool _visualDisabled = false;
        private Color DefaultMouseDownBackColor;
        private Color DefaultMouseOverBackColor;
        public bool VisualDisabled
        {
            get
            {
                return _visualDisabled;
            }
            set
            {
                _visualDisabled = value;
                if (value)
                {
                    FlatAppearance.MouseDownBackColor = FlatAppearance.MouseOverBackColor = BackColor;
                }
                else
                {
                    FlatAppearance.MouseDownBackColor = DefaultMouseDownBackColor;
                    FlatAppearance.MouseOverBackColor = DefaultMouseOverBackColor;
                }
            }
        }
        private bool ShouldSerializeVisualDisabled()
        {
            return _visualDisabled;
        }
        private void ResetVisualDisabled()
        {
            VisualDisabled = false;
        }

        public SBIconButton(): base()
        {
            FlatAppearance.BorderSize = 0;
            BackColor  = Color.Transparent;
            DefaultMouseDownBackColor = FlatAppearance.MouseDownBackColor;
            DefaultMouseOverBackColor = FlatAppearance.MouseOverBackColor;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
        }
        
    }
    public partial class SBIconButtonDark : IconButton
    {
        private bool _visualDisabled = false;
        private Color DefaultMouseDownBackColor;
        private Color DefaultMouseOverBackColor;
        public bool VisualDisabled
        {
            get
            {
                return _visualDisabled;
            }
            set
            {
                _visualDisabled = value;
                if (value)
                {
                    FlatAppearance.MouseDownBackColor = FlatAppearance.MouseOverBackColor = BackColor;
                }
                else
                {
                    FlatAppearance.MouseDownBackColor = DefaultMouseDownBackColor;
                    FlatAppearance.MouseOverBackColor = DefaultMouseOverBackColor;
                }
            }
        }
        private bool ShouldSerializeVisualDisabled()
        {
            return _visualDisabled;
        }
        private void ResetVisualDisabled()
        {
            VisualDisabled = false;
        }
        public SBIconButtonDark(): base()
        {
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            InitializeColors();
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBIconButton_Disposed;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            InitializeColors();
        }
        private void SBIconButton_Disposed(object sender, System.EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            DefaultMouseDownBackColor = Theme.Get.ColorButtonPressed;
            DefaultMouseOverBackColor = Theme.Get.ColorButtonHover;
            IconColor = ForeColor = Theme.Get.ColorText;
            VisualDisabled = VisualDisabled;
        }
    } 
    public partial class MyIconDropdownButton : IconDropDownButton
    {
        public bool VisualDisabled { get; set; } = false;
        private bool ShouldSerializeVisualDisabled()
        {
            return VisualDisabled;
        }
        private void ResetVisualDisabled()
        {
            VisualDisabled = false;
        }

        public MyIconDropdownButton() : base()
        {
            BackColor = Color.Transparent;
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBIconButton_Disposed;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            InitializeColors();
        }
        private void SBIconButton_Disposed(object sender, System.EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            IconColor = ForeColor = Theme.Get.ColorText;
            VisualDisabled = VisualDisabled;
        }
    }
    public partial class MyIconSplitButton : IconSplitButton
    {
        public bool VisualDisabled { get; set; } = false;
        private bool ShouldSerializeVisualDisabled()
        {
            return VisualDisabled;
        }
        private void ResetVisualDisabled()
        {
            VisualDisabled = false;
        }

        public MyIconSplitButton() : base()
        {
            BackColor = Color.Transparent;
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBIconButton_Disposed;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            InitializeColors();
        }
        private void SBIconButton_Disposed(object sender, System.EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            IconColor = ForeColor = Theme.Get.ColorText;
            VisualDisabled = VisualDisabled;
        }
    }
    public partial class MyIconToolStripButton : IconToolStripButton
    {
        public bool VisualDisabled { get; set; } = false;
        private bool ShouldSerializeVisualDisabled()
        {
            return VisualDisabled;
        }
        private void ResetVisualDisabled()
        {
            VisualDisabled = false;
        }

        public MyIconToolStripButton() : base()
        {
            BackColor = Color.Transparent;
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            Disposed += SBIconButton_Disposed;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            InitializeColors();
        }
        private void SBIconButton_Disposed(object sender, System.EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeColors();
        }

        private void InitializeColors()
        {
            IconColor = ForeColor = Theme.Get.ColorText;
            VisualDisabled = VisualDisabled;
        }
    }
}
