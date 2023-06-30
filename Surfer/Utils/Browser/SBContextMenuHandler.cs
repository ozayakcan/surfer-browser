using CefSharp;
using System.Windows.Forms;

namespace Surfer.Utils.Browser
{
    public class SBContextMenuHandler : IContextMenuHandler
    {
        enum MyCefMenuCommand
        {
            OpenLinkInNewTab = 26501,
            CopyLink = 26502,
            Inspect = 26504,
        }

        public Forms.Browser MyBrowser;

        public SBContextMenuHandler(Forms.Browser browser)
        {
            MyBrowser = browser;

        }
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
            if (!string.IsNullOrEmpty(parameters.LinkUrl))
            {
                model.AddItem((CefMenuCommand)MyCefMenuCommand.OpenLinkInNewTab, Language.Get.open_link_in_new_tab);
                model.AddSeparator();
                model.AddItem((CefMenuCommand)MyCefMenuCommand.CopyLink, Language.Get.copy_link);
            }

            if (parameters.IsEditable)
            {
                if (model.Count > 0)
                    model.AddSeparator();
                model.AddItem(CefMenuCommand.Cut, Language.Get.cut);
                model.SetEnabled(CefMenuCommand.Cut, !string.IsNullOrEmpty(parameters.SelectionText));
            }
            if (!string.IsNullOrEmpty(parameters.SelectionText) || parameters.IsEditable)
            {
                if (!parameters.IsEditable)
                    model.AddSeparator();
                model.AddItem(CefMenuCommand.Copy, Language.Get.copy);
                model.SetEnabled(CefMenuCommand.Copy, !string.IsNullOrEmpty(parameters.SelectionText));
            }
            if (parameters.IsEditable)
            {
                model.AddItem(CefMenuCommand.Paste, Language.Get.paste);
                model.SetEnabled(CefMenuCommand.Paste, Clipboard.ContainsText());
                model.AddItem(CefMenuCommand.SelectAll, Language.Get.select_all);
            }
            if (string.IsNullOrEmpty(parameters.LinkUrl) && !parameters.IsEditable)
            {
                if (model.Count > 0)
                    model.AddSeparator();
                model.AddItem(CefMenuCommand.Back, Language.Get.back);
                model.SetEnabled(CefMenuCommand.Back, chromiumWebBrowser.CanGoBack);
                model.AddItem(CefMenuCommand.Forward, Language.Get.forward);
                model.SetEnabled(CefMenuCommand.Forward, chromiumWebBrowser.CanGoForward);
                model.AddItem(CefMenuCommand.Reload, Language.Get.reload);
                model.AddSeparator();
                model.AddItem(CefMenuCommand.Print, Language.Get.print);
            }
            if (model.Count > 0)
                model.AddSeparator();
            model.AddItem(CefMenuCommand.ViewSource, Language.Get.view_source);
            model.AddItem((CefMenuCommand)MyCefMenuCommand.Inspect, Language.Get.inspect);
        }


        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            switch ((MyCefMenuCommand)commandId)
            {
                case MyCefMenuCommand.OpenLinkInNewTab:
                    MyBrowser.OpenInNewTab(parameters.LinkUrl);
                    return true;
                case MyCefMenuCommand.CopyLink:
                    Clipboard.SetText(parameters.LinkUrl);
                    return true;
                case MyCefMenuCommand.Inspect:
                    MyBrowser.ShowDevTools(parameters.XCoord, parameters.YCoord);
                    return true;
            }
            switch (commandId)
            {
                case CefMenuCommand.ViewSource:
                    MyBrowser.ViewSource();
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
