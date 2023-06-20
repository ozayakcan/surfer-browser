using System;
using System.Windows.Forms;
using Surfer.Forms;
using CefSharp;
using System.Drawing;
using Surfer.Utils;

namespace Surfer.Controls
{
    public partial class Search : UserControl
    {
        public Form OwnerForm { get; set; }
        public Browser Browser;
        public Search(Browser browser)
        {
            Browser = browser ?? throw new Exception("Browser can not be null");
            InitializeComponent();
            /*tbSearch.BackColor = BackColor;
            Padding = new Padding(5);
            Size = new Size(Size.Width, 23);*/
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Browser.chBrowser.StopFinding(true);
            if (OwnerForm != null)
                OwnerForm.Close();
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Browser.chBrowser.StopFinding(true);
                if (OwnerForm != null)
                    OwnerForm.Close();
            }
            else
            {
                if (tbSearch.Text.Length <= 0)
                {
                    Browser.chBrowser.StopFinding(true);
                }
                else
                {
                    Browser.chBrowser.Find(tbSearch.Text, true, false, e.KeyCode == Keys.Enter);
                }
            }
        }

        private void btnFindPrev_Click(object sender, EventArgs e)
        {
            Browser.chBrowser.Find(tbSearch.Text, false, false, true);
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            Browser.chBrowser.Find(tbSearch.Text, true, false, true);
        }
        public void SetNumbers(int current, int total)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                lblCur.Text = current.ToString();
                lblTotal.Text = total.ToString();
            });
        }
    }
}
