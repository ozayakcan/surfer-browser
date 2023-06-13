using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Surfer.Forms
{
    public partial class PopupForm : Form
    {
        private bool _activating = false;
        private Action _onClosed;
        public PopupForm(Form ownerForm, Control ownerControl, Control content, Action onClosed = null, PopupFormStyle popupFormStyle = PopupFormStyle.Left, int additionalLocX = 0)
        {
            _onClosed = onClosed;
            InitializeComponent();
            Owner = ownerForm;
            Size = content.Size;
            Controls.Add(content);
            StartPosition = FormStartPosition.Manual;
            Point loc = Owner.PointToScreen(ownerControl.Location);
            int xLocation = loc.X;
            switch (popupFormStyle)
            {
                case PopupFormStyle.Left:
                    xLocation = loc.X + additionalLocX;
                    break;
                case PopupFormStyle.Center:
                    xLocation = loc.X - (Size.Width / 2) + additionalLocX;
                    break;
                case PopupFormStyle.Right:
                    xLocation = loc.X - Size.Width + additionalLocX;
                    break;
            }
            Location = new Point(xLocation, loc.Y + ownerControl.Size.Height);
            ShowInTaskbar = false;
        }
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private const int WM_NCACTIVATE = 0x86;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            // The popup needs to be activated for the user to interact with it,
            // but we want to keep the owner window's appearance the same.
            if ((m.Msg == WM_NCACTIVATE) && !_activating && (m.WParam != IntPtr.Zero))
            {
                // The popup is being activated, ensure parent keeps activated appearance
                _activating = true;
                SendMessage(Owner.Handle, WM_NCACTIVATE, (IntPtr)1, IntPtr.Zero);
                _activating = false;
                // Call base.WndProc here if you want the appearance of the popup to change
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Capture = true;
        }
        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            if (!Capture)
            {
                if (!RectangleToScreen(DisplayRectangle).Contains(Cursor.Position))
                {
                    Close();
                }
                else
                {
                    Capture = true;
                }
            }
            base.OnMouseCaptureChanged(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            _onClosed?.Invoke();
            base.OnClosed(e);
        }
    }
    public enum PopupFormStyle
    {
        Left,
        Center,
        Right,
    }
}
