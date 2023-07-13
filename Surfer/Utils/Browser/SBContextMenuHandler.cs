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
                ToolStripMenuItem undoItem = new ToolStripMenuItem(
                    Locale.Get.undo,
                    IconChar.Undo.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Undo();
                    }
                );
                undoItem.ShortcutKeys = (Keys.Control | Keys.Z);
                MyBrowser.chBrowserContextMenu.Items.Add(undoItem);
                ToolStripMenuItem cutItem = new ToolStripMenuItem(
                    Locale.Get.cut,
                    IconChar.Cut.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.Cut();
                    }
                );
                cutItem.ShortcutKeys = (Keys.Control | Keys.X);
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
                copyItem.ShortcutKeys = (Keys.Control | Keys.C);
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
                pasteItem.ShortcutKeys = (Keys.Control | Keys.V);
                MyBrowser.chBrowserContextMenu.Items.Add(pasteItem);
                pasteItem.Enabled = Clipboard.ContainsText();
                ToolStripMenuItem selectAllItem = new ToolStripMenuItem(
                    Locale.Get.select_all,
                    IconChar.None.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.chBrowser.SelectAll();
                    }
                );
                selectAllItem.ShortcutKeys = (Keys.Control | Keys.A);
                MyBrowser.chBrowserContextMenu.Items.Add(selectAllItem);
            }
            if (!string.IsNullOrEmpty(SelectionText))
            {
                MyBrowser.chBrowserContextMenu.Items.Add(
                    string.Format(Locale.Get.search_the_web_for, SelectionText),
                    IconChar.Search.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.OpenInNewTab(SelectionText.GetSearchUrl(), true);
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
                ToolStripMenuItem reloadItem = new ToolStripMenuItem(
                    Locale.Get.reload,
                    IconChar.Refresh.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        chromiumWebBrowser.Reload();
                    }
                );
                reloadItem.ShortcutKeys = Keys.F5;
                MyBrowser.chBrowserContextMenu.Items.Add(reloadItem);
                MyBrowser.chBrowserContextMenu.Items.Add("-");
                ToolStripMenuItem printItem = new ToolStripMenuItem(
                    Locale.Get.print,
                    IconChar.Print.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        chromiumWebBrowser.Print();
                    }
                );
                printItem.ShortcutKeys = (Keys.Control | Keys.P);
                MyBrowser.chBrowserContextMenu.Items.Add(printItem);
                ToolStripMenuItem saveAsItem = new ToolStripMenuItem(
                    Locale.Get.save_as,
                    IconChar.Save.ToBitmap(Theme.Get.ColorText),
                    (s, e) => {
                        MyBrowser.SaveAs();
                    }
                );
                saveAsItem.ShortcutKeys = (Keys.Control | Keys.S);
                MyBrowser.chBrowserContextMenu.Items.Add(saveAsItem);
            }
            if (MyBrowser.chBrowserContextMenu.Items.Count > 0) MyBrowser.chBrowserContextMenu.Items.Add("-");
            ToolStripMenuItem viewSourceItem = new ToolStripMenuItem(
                Locale.Get.view_source,
                IconChar.None.ToBitmap(Theme.Get.ColorText),
                (s, e) => {
                    MyBrowser.ViewSource();
                }
            );
            viewSourceItem.ShortcutKeys = (Keys.Control | Keys.U);
            MyBrowser.chBrowserContextMenu.Items.Add(viewSourceItem);
            int XCoord = parameters.XCoord;
            int YCoord = parameters.YCoord;
            ToolStripMenuItem inspectItem = new ToolStripMenuItem(
                Locale.Get.inspect,
                IconChar.None.ToBitmap(Theme.Get.ColorText),
                (s, e) => {
                    MyBrowser.ShowDevTools(XCoord, YCoord);
                }
            );
            inspectItem.ShortcutKeys = (Keys.Control | Keys.Alt | Keys.I);
            MyBrowser.chBrowserContextMenu.Items.Add(inspectItem);
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
