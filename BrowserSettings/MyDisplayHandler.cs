using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace Surfer.BrowserSettings
{
    public class MyDisplayHandler : IDisplayHandler
    {
        private Browser MyBrowser;

        public MyDisplayHandler(Browser browser)
        {
            MyBrowser = browser;
        }
        public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {
            MyBrowser.OnAddressChanged(addressChangedArgs);
        }

        public bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, CefSharp.Structs.Size newSize)
        {
            return false;
        }

        public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return false;
        }

        public bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
        {
            return false;
        }

        public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
        {
            foreach (var url in urls)
            {
                MyBrowser.SetIcon(url);
            }
        }

        public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
        {
            
        }

        public void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
        {
            progress = progress * 100;
            if (progress >= 100)
            {
                MyBrowser.HideLoading();
            }
            else
            {
                MyBrowser.ShowLoading(Convert.ToInt32(progress));
            }
        }

        public void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {
            
        }

        public void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {
            MyBrowser.TitleChanged(titleChangedArgs);
        }

        public bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            return false;
        }
    }
}
