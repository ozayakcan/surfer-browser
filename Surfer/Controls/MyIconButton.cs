using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

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
            BackColor  = Color.White;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
