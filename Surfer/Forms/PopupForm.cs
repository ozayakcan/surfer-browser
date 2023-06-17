﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Forms
{
    public partial class PopupForm : Form
    {
        private bool _loaded = false;
        public bool AnimationEnabled { get; set; } = true;

        public bool CloseOnClickOutSide { get; set; } = true;

        private Control _ownerControl;
        public Control OwnerControl
        {
            get
            {
                return _ownerControl;
            }
            set
            {
                _ownerControl = value;
                UpdateLocation(value);
            }
        }
        public void UpdateLocation(Control ownerControl = null)
        {
            if (_loaded)
                Invoke(new Action(() =>
                {
                    if (ownerControl == null)
                        ownerControl = OwnerControl;
                    if (ownerControl != null)
                    {
                        Point loc = Owner.PointToScreen(ownerControl.Location);
                        int xLocation = loc.X;
                        switch (PopupFormStyle)
                        {
                            case PopupFormStyle.Left:
                                xLocation = loc.X + AdditionalXLocation;
                                break;
                            case PopupFormStyle.Center:
                                xLocation = loc.X - (Size.Width / 2) + AdditionalXLocation;
                                break;
                            case PopupFormStyle.Right:
                                xLocation = loc.X - Size.Width + AdditionalXLocation;
                                break;
                        }
                        Location = new Point(xLocation, loc.Y + ownerControl.Size.Height);
                    }
                }));
        }
        private Size FullSize = new Size(0, 0);
        private Control _content;
        public Control Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                if (value != null)
                {
                    Controls.Clear();
                    FullSize = new Size(value.Size.Width, value.Size.Height);
                    Size = new Size(FullSize.Width, 0);
                    Controls.Add(value);
                    BackColor = value.BackColor;
                }
            }
        }

        public Action WhenClosed
        {
            get;
            set;
        }

        public PopupFormStyle PopupFormStyle
        {
            get;
            set;
        } = PopupFormStyle.Left;

        public int AdditionalXLocation
        {
            get;
            set;
        } = 0;

        public PopupForm()
        {
            InitializeComponent();
            Size = new Size(Size.Width, 0);
            if(FullSize.Width == 0)
                FullSize = new Size(Size.Width, 0);
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
        }

        /*protected override void OnShown(EventArgs e)
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
        }*/
        protected override void WndProc(ref Message m)
        {
            if (CloseOnClickOutSide)
            {
                const uint WM_NCACTIVATE = 0x0086;
                if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0)
                {
                    Close();
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
                base.WndProc(ref m);
        }

        protected override void OnClosed(EventArgs e)
        {
            WhenClosed?.Invoke();
            base.OnClosed(e);
        }

        private int timerInterval = 40;

        private int curShowHeight = 0;
        private void tmrShow_Tick(object sender, EventArgs e)
        {
            curShowHeight = curShowHeight + timerInterval;
            if ((curShowHeight + timerInterval) >= FullSize.Height)
            {
                curShowHeight = FullSize.Height;
                tmrShow.Stop();
            }
            Size = new Size(FullSize.Width, curShowHeight);
        }

        private void PopupForm_Load(object sender, EventArgs e)
        {
            _loaded = true;
            UpdateLocation(OwnerControl);
            if (AnimationEnabled)
                tmrShow.Start();
            else
                Size = new Size(FullSize.Width, FullSize.Height);
        }
    }
    public enum PopupFormStyle
    {
        Left,
        Center,
        Right,
    }
}
