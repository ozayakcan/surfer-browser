﻿using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Surfer.Controls
{
    public partial class MyIconButton: IconButton
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

        public MyIconButton(): base()
        {
            FlatAppearance.BorderSize = 0;
            DefaultMouseDownBackColor = FlatAppearance.MouseDownBackColor;
            DefaultMouseOverBackColor = FlatAppearance.MouseOverBackColor;
            BackColor  = Color.Transparent;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
    public partial class MyIconDropdownButton : IconDropDownButton
    {
        private Color DefaultMouseDownBackColor;
        private Color DefaultMouseOverBackColor;
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
        }
    }
    public partial class MyIconSplitButton : IconSplitButton
    {
        private Color DefaultMouseDownBackColor;
        private Color DefaultMouseOverBackColor;
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
        }
    }
    public partial class MyIconToolStripButton : IconToolStripButton
    {
        private Color DefaultMouseDownBackColor;
        private Color DefaultMouseOverBackColor;
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
        }
    }
}
