using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using Surfer.Forms;
using Surfer.Utils;
using Surfer.Utils.Browser;

namespace Surfer.Controls
{
    public partial class FavoriteControl : UserControl
    {

        public Image Icon
        {
            get
            {
                return btnFavoriteUrl.Image;
            }
            set
            {
                if(value != null)
                {
                    Bitmap bitmap = new Bitmap(value, 12, 12);
                    btnFavoriteUrl.Image = bitmap;
                }
            }
        }
        public string Title
        {
            get
            {
                return btnFavoriteUrl.Text;
            }
            set
            {
                btnFavoriteUrl.Text = value;
            }
        }
        public string Url {get;set;}

        Browser MyBrowser;
        public FavoriteControl(Browser browser)
        {
            MyBrowser = browser;
            InitializeComponent();
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            InitializeContextMenu();
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeIcons();
        }

        private void InitializeContextMenu()
        {
            tsmiDelete.Text = Locale.Get.delete;
            InitializeIcons();
        }

        private void InitializeIcons()
        {
            tsmiDelete.Image = IconChar.TrashCan.ToBitmap(Theme.Get.ColorText);
        }

        private void btnFavoriteUrl_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
                MyBrowser.OpenInNewTab(Url);
            else
                MyBrowser.LoadUrl(Url);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            FavoriteManager.Delete(Url, () =>
            {
                MyBrowser.DeleteFavoriteInAllTabs(Url);
            });
        }

        private bool _holding = false;
        private void btnFavoriteUrl_MouseDown(object sender, MouseEventArgs e)
        {
            _holding = true;
        }

        private void btnFavoriteUrl_MouseUp(object sender, MouseEventArgs e)
        {
            _holding = false;
        }

        private readonly WshShell shell = new WshShell();
        private void btnFavoriteUrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_holding)
            {
                string path = Paths.ShortcutUrl(Title);
                var shortcut = shell.CreateShortcut(path);
                shortcut.TargetPath = Url;
                shortcut.Save();
                string[] filesToDrag =
                {
                    path
                };
                btnFavoriteUrl.DoDragDrop(new DataObject(DataFormats.FileDrop, filesToDrag), DragDropEffects.Move);
                _holding = false;
            }
        }
    }
}
