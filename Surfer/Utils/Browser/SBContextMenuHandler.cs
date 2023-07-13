using CefSharp;
using FontAwesome.Sharp;
using System.Diagnostics;
using System.Windows.Forms;

namespace Surfer.Utils.Browser
{
    public class SBContextMenuHandler : IContextMenuHandler
    {
        enum MyCefMenuCommand
        {
            OpenLinkInNewTab = 26501,
            CopyLink = 26502,
            SaveAs = 26503,
            Inspect = 26504,
        }

        public Forms.Browser MyBrowser;

        public SBContextMenuHandler(Forms.Browser browser)
        {
            MyBrowser = browser;

        }
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            MyBrowser.chBrowserContextMenu.Items.Clear();
            MyBrowser.chBrowserContextMenu.Hide();
            string LinkUrl = parameters.LinkUrl;
            if (!string.IsNullOrEmpty(LinkUrl))
            {
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.open_link_in_new_tab,
                    IconChar.Table.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.OpenInNewTab(LinkUrl);
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add("-");
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.copy_link,
                    IconChar.Link.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        Clipboard.SetText(LinkUrl);
                    }
                );
            }
            bool IsEditable = parameters.IsEditable;
            string SelectionText = parameters.SelectionText;
            if (IsEditable)
            {
                if (MyBrowser.chBrowserContextMenu.Items.Count > 0) MyBrowser.chBrowserContextMenu.Items.Add("-");
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.undo,
                    IconChar.Undo.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Undo();
                    }
                );
                ToolStripMenuItem cutItem = new ToolStripMenuItem(
                    Locale.Get.cut,
                    IconChar.Cut.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Cut();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(cutItem);
                cutItem.Enabled = !string.IsNullOrEmpty(SelectionText);
            }
            if (!string.IsNullOrEmpty(SelectionText) || IsEditable)
            {
                if (!IsEditable) MyBrowser.chBrowserContextMenu.Items.Add("-");
                ToolStripMenuItem copyItem = new ToolStripMenuItem(
                    Locale.Get.copy,
                    IconChar.Copy.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Copy();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(copyItem);
                copyItem.Enabled = !string.IsNullOrEmpty(SelectionText);
            }

            if (IsEditable)
            {
                ToolStripMenuItem pasteItem = new ToolStripMenuItem(
                     Locale.Get.paste,
                    IconChar.Paste.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Paste();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(pasteItem);
                pasteItem.Enabled = Clipboard.ContainsText();
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.select_all,
                    IconChar.None.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.SelectAll();
                    }
                );
            }
            if (string.IsNullOrEmpty(LinkUrl) && !IsEditable)
            {
                if (MyBrowser.chBrowserContextMenu.Items.Count > 0) MyBrowser.chBrowserContextMenu.Items.Add("-");
                ToolStripMenuItem backItem = new ToolStripMenuItem(
                    Locale.Get.back,
                    IconChar.ArrowLeft.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        if (chromiumWebBrowser.CanGoBack)
                            chromiumWebBrowser.Back();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(backItem);
                backItem.Enabled = chromiumWebBrowser.CanGoBack;
                ToolStripMenuItem forwardItem = new ToolStripMenuItem(
                    Locale.Get.forward,
                    IconChar.ArrowRight.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        if (chromiumWebBrowser.CanGoForward)
                            chromiumWebBrowser.Forward();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(forwardItem);
                forwardItem.Enabled = chromiumWebBrowser.CanGoForward;
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.reload,
                    IconChar.Refresh.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        chromiumWebBrowser.Reload();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add("-");
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.print,
                    IconChar.Print.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        chromiumWebBrowser.Print();
                    }
                );
                MyBrowser.chBrowserContextMenu.Items.Add(
                    Locale.Get.save_as,
                    IconChar.Save.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.SaveAs();
                    }
                );
            }
            if (MyBrowser.chBrowserContextMenu.Items.Count > 0) MyBrowser.chBrowserContextMenu.Items.Add("-");
            MyBrowser.chBrowserContextMenu.Items.Add(
                Locale.Get.view_source,
                IconChar.None.ToBitmap(Theme.Get.ColorText),
                (s, e) => {
                    MyBrowser.ViewSource();
                }
            );
            int XCoord = parameters.XCoord;
            int YCoord = parameters.YCoord;
            MyBrowser.chBrowserContextMenu.Items.Add(
                Locale.Get.inspect,
                IconChar.None.ToBitmap(Theme.Get.ColorText),
                (s, e) => {
                    MyBrowser.ShowDevTools(XCoord, YCoord);
                }
            );
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
