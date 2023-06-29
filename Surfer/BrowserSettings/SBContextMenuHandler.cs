using CefSharp;
using FontAwesome.Sharp;
using Surfer.Forms;
using Surfer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Surfer.BrowserSettings
{
    public class SBContextMenuHandler : IContextMenuHandler
    {
        public Browser MyBrowser;

        public SBContextMenuHandler(Browser browser)
        {
            MyBrowser = browser;

            UpdateImageText(MyBrowser.tsmiOpenLinkInNewTab, IconChar.Table, Language.Get.open_link_in_new_tab);
            MyBrowser.tsmiOpenLinkInNewTab.Click += TsmiOpenLinkInNewTab_Click;
            UpdateImageText(MyBrowser.tsmiCopyLink, IconChar.Copy, Language.Get.copy_link);
            MyBrowser.tsmiCopyLink.Click += TsmiCopyLink_Click;
            UpdateImageText(MyBrowser.tsmiCut, IconChar.Cut, Language.Get.cut);
            MyBrowser.tsmiCut.Click += TsmiCut_Click;
            UpdateImageText(MyBrowser.tsmiCopy, IconChar.Copy, Language.Get.copy);
            MyBrowser.tsmiCopy.Click += TsmiCopy_Click;
            UpdateImageText(MyBrowser.tsmiPaste, IconChar.Paste, Language.Get.paste);
            MyBrowser.tsmiPaste.Click += TsmiPaste_Click;
            UpdateImageText(MyBrowser.tsmiSelectAll, IconChar.Allergies, Language.Get.select_all);
            MyBrowser.tsmiSelectAll.Click += TsmiSelectAll_Click;
            UpdateImageText(MyBrowser.tsmiBack, IconChar.ArrowLeft, Language.Get.back);
            MyBrowser.tsmiBack.Click += TsmiBack_Click;
            UpdateImageText(MyBrowser.tsmiForward, IconChar.ArrowRight, Language.Get.forward);
            MyBrowser.tsmiForward.Click += TsmiForward_Click; ;
            UpdateImageText(MyBrowser.tsmiReload, IconChar.Refresh, Language.Get.reload);
            MyBrowser.tsmiReload.Click += TsmiReload_Click;
            UpdateImageText(MyBrowser.tsmiReloadNoCache, IconChar.Refresh, Language.Get.force_reload);
            MyBrowser.tsmiReloadNoCache.Click += TsmiReloadNoCache_Click;
            UpdateImageText(MyBrowser.tsmiViewSource, IconChar.Sourcetree, Language.Get.view_source);
            MyBrowser.tsmiViewSource.Click += TsmiViewSource_Click;
            UpdateImageText(MyBrowser.tsmiInspect, IconChar.MagnifyingGlassChart, Language.Get.inspect);
            MyBrowser.tsmiInspect.Click += TsmiInspect_Click;
        }

        private void UpdateImageText(ToolStripMenuItem item, IconChar icon, string text)
        {
            if (item.Image == null)
                item.Image = icon.ToBitmap(Color.Black);
            if (string.IsNullOrEmpty(item.Text))
                item.Text = text;
        }

        private void TsmiOpenLinkInNewTab_Click(object sender, EventArgs e)
        {
            MyBrowser.OpenInNewTab(_linkUrl);
        }
        private void TsmiCopyLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_linkUrl);
        }
        private void TsmiCut_Click(object sender, EventArgs e)
        {
            MyBrowser.chBrowser.Cut();
        }
        private void TsmiCopy_Click(object sender, EventArgs e)
        {
            MyBrowser.chBrowser.Copy();
        }
        private void TsmiPaste_Click(object sender, EventArgs e)
        {
            MyBrowser.chBrowser.Paste();
        }
        private void TsmiSelectAll_Click(object sender, EventArgs e)
        {
            MyBrowser.chBrowser.SelectAll();
        }
        private void TsmiBack_Click(object sender, EventArgs e)
        {
            MyBrowser.GoBack();
        }
        private void TsmiForward_Click(object sender, EventArgs e)
        {
            MyBrowser.GoForward();
        }
        private void TsmiReload_Click(object sender, EventArgs e)
        {
            MyBrowser.Reload();
        }
        private void TsmiReloadNoCache_Click(object sender, EventArgs e)
        {
            MyBrowser.Reload(true);
        }
        private void TsmiViewSource_Click(object sender, EventArgs e)
        {
            MyBrowser.ViewSource();
        }
        private void TsmiInspect_Click(object sender, EventArgs e)
        {
            MyBrowser.ShowDevTools(_xCoord, _yCoord);
        }

        private string _linkUrl = null;
        private string _selectionText = null;
        private bool _isEditable = false;
        private int _xCoord = 0;
        private int _yCoord = 0;
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            int ItemCount = 0;
            _linkUrl = parameters.LinkUrl;
            _selectionText = parameters.SelectionText;
            _isEditable = parameters.IsEditable;
            _xCoord = parameters.XCoord;
            _yCoord = parameters.YCoord;
            ResetAll();
            if (!string.IsNullOrEmpty(_linkUrl))
            {
                MyBrowser.tsmiOpenLinkInNewTab.Visible = true;
                MyBrowser.tsmiLinkSeperator.Visible = true;
                MyBrowser.tsmiCopyLink.Visible = true;
                ItemCount++;
            }
            
            if (!string.IsNullOrEmpty(_selectionText))
            {
                MyBrowser.tsmiCopy.Visible = true;
                MyBrowser.tsmiCopy.Enabled = true;
            }
            if (_isEditable)
            {
                MyBrowser.tsmiSelectionSeperator.Visible = ItemCount > 0;
                MyBrowser.tsmiCut.Visible = true;
                MyBrowser.tsmiCut.Enabled = !string.IsNullOrEmpty(_selectionText);
                MyBrowser.tsmiCopy.Visible = true;
                MyBrowser.tsmiCopy.Enabled = !string.IsNullOrEmpty(_selectionText);
                MyBrowser.tsmiPaste.Visible = true;
                MyBrowser.tsmiPaste.Enabled = Clipboard.ContainsText();
                MyBrowser.tsmiSelectAll.Visible = true;
                ItemCount++;
            }
            if (string.IsNullOrEmpty(_linkUrl) && !_isEditable)
            {
                MyBrowser.tsmiNormalSeperator.Visible = ItemCount > 0;
                MyBrowser.tsmiBack.Visible = true;
                MyBrowser.tsmiForward.Visible = true;
                MyBrowser.tsmiReload.Visible = true;
                MyBrowser.tsmiReloadNoCache.Visible = true;
                ItemCount++;
            }
            MyBrowser.tsmiSourceSeperator.Visible = ItemCount > 0;
        }

        private void ResetAll()
        {
            MyBrowser.tsmiBack.Visible = false;
            MyBrowser.tsmiCopy.Visible = false;
            MyBrowser.tsmiCopy.Enabled = true;
            MyBrowser.tsmiCopyLink.Visible = false;
            MyBrowser.tsmiCopyLink.Enabled = true;
            MyBrowser.tsmiCut.Visible = false;
            MyBrowser.tsmiCut.Enabled = true;
            MyBrowser.tsmiForward.Visible = false;
            MyBrowser.tsmiLinkSeperator.Visible = false;
            MyBrowser.tsmiNormalSeperator.Visible = false;
            MyBrowser.tsmiOpenLinkInNewTab.Visible = false;
            MyBrowser.tsmiOpenLinkInNewTab.Enabled = true;
            MyBrowser.tsmiPaste.Visible = false;
            MyBrowser.tsmiPaste.Enabled = true;
            MyBrowser.tsmiReload.Visible = false;
            MyBrowser.tsmiReload.Enabled = true;
            MyBrowser.tsmiReloadNoCache.Visible = false;
            MyBrowser.tsmiReloadNoCache.Enabled = true;
            MyBrowser.tsmiSelectAll.Visible = false;
            MyBrowser.tsmiSelectAll.Enabled = true;
            MyBrowser.tsmiSelectionSeperator.Visible = false;
            MyBrowser.tsmiSourceSeperator.Visible = false;
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }
        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            //MyBrowser.chBrowserContextMenu.Hide();
        }
        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            MyBrowser.chBrowserContextMenu.Show(Cursor.Position);
            return true;
        }
    }
}
