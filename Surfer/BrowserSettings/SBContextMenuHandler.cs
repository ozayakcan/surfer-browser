using CefSharp;
using Surfer.Forms;
using Surfer.Utils;
using System.Threading;
using System.Windows.Forms;

namespace Surfer.BrowserSettings
{
    public enum CustomCefMenuCommand{
        // On Links
        OpenLinkInNewTab = 26501,
        //OpenLinkInNewWindow = 26502,
        //OpenLinkInPrivateTab = 26503,
        CopyLink = 26505,

        // Always active
        Inspect = 26701,
    }
    public class SBContextMenuHandler : IContextMenuHandler
    {
        private Browser MyBrowser;

        public SBContextMenuHandler(Browser browser)
        {
            MyBrowser = browser;
        }
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
            int ItemCount = 0;
            if (!string.IsNullOrEmpty(parameters.LinkUrl))
            {
                if(ItemCount > 0)
                    model.AddSeparator();
                ItemCount += 1;
                model.AddItem((CefMenuCommand)CustomCefMenuCommand.OpenLinkInNewTab, Language.Get.open_link_in_new_tab);
                //model.AddItem((CefMenuCommand)CustomCefMenuCommand.OpenLinkInNewTab, "Open link in new window");
                //model.AddItem((CefMenuCommand)CustomCefMenuCommand.OpenLinkInNewTab, "Open link in private tab");
                model.AddSeparator();
                model.AddItem((CefMenuCommand)CustomCefMenuCommand.CopyLink, Language.Get.copy_link);
            }

            if (!string.IsNullOrEmpty(parameters.SelectionText))
            {
                if (ItemCount > 0)
                    model.AddSeparator();
                ItemCount += 1;
                if (parameters.IsEditable)
                    model.AddItem(CefMenuCommand.Cut, string.Format(Language.Get.cut_w_key, "Ctrl + X"));
                model.AddItem(CefMenuCommand.Copy, string.Format(Language.Get.copy_w_key, "Ctrl + C"));
            }
            if (parameters.IsEditable)
            {
                if(Clipboard.ContainsText())
                    model.AddItem(CefMenuCommand.Paste, string.Format(Language.Get.paste_w_key, "Ctrl + V"));
                model.AddItem(CefMenuCommand.SelectAll, string.Format(Language.Get.select_all_w_key, "Ctrl + A"));
            }
            if (string.IsNullOrEmpty(parameters.LinkUrl))
            {
                if (ItemCount > 0)
                    model.AddSeparator();
                ItemCount += 1;
                model.AddItem(CefMenuCommand.Back, Language.Get.back);
                model.AddItem(CefMenuCommand.Forward, Language.Get.forward);
                model.AddItem(CefMenuCommand.Reload, string.Format(Language.Get.reload_w_key, "F5"));
                model.AddItem(CefMenuCommand.ReloadNoCache, string.Format(Language.Get.reload_w_key, "Ctrl + F5"));
            }
            if (ItemCount > 0)
                model.AddSeparator();
            model.AddItem(CefMenuCommand.ViewSource, string.Format(Language.Get.view_source_w_key, "Ctrl + U"));
            model.AddItem((CefMenuCommand)CustomCefMenuCommand.Inspect, string.Format(Language.Get.inspect_w_key, "Ctrl + Alt + I"));
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            switch (commandId)
            {
                case (CefMenuCommand)CustomCefMenuCommand.OpenLinkInNewTab:
                    MyBrowser.OpenInNewTab(parameters.LinkUrl);
                    return true;
                case (CefMenuCommand)CustomCefMenuCommand.CopyLink:
                    Clipboard.SetText(parameters.LinkUrl);
                    return true;
                case CefMenuCommand.Cut:
                    MyBrowser.chBrowser.Cut();
                    return true;
                case CefMenuCommand.Copy:
                    MyBrowser.chBrowser.Copy();
                    return true;
                case CefMenuCommand.Paste:
                    MyBrowser.chBrowser.Paste();
                    return true;
                case CefMenuCommand.SelectAll:
                    MyBrowser.chBrowser.SelectAll();
                    return true;
                case CefMenuCommand.Back:
                    MyBrowser.GoBack();
                    return true;
                case CefMenuCommand.Forward:
                    MyBrowser.GoForward();
                    return true;
                case CefMenuCommand.Reload:
                    MyBrowser.chBrowser.Reload();
                    return true;
                case CefMenuCommand.ReloadNoCache:
                    MyBrowser.chBrowser.Reload(true);
                    return true;
                case CefMenuCommand.ViewSource:
                    MyBrowser.ViewSource();
                    return true;
                case (CefMenuCommand)CustomCefMenuCommand.Inspect:
                    MyBrowser.ShowDevTools(parameters.XCoord, parameters.YCoord);
                    return true;
            }
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            
        }

        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
