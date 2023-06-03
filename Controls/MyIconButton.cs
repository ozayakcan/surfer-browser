using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;

namespace Surfer.Controls
{
    public partial class MyIconButton: IconButton
    {
        public MyIconButton(): base()
        {
            FlatAppearance.BorderSize = 0;
            BackColor = FlatAppearance.MouseOverBackColor = Color.White;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
