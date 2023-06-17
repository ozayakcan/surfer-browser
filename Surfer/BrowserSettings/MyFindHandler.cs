using CefSharp;
using CefSharp.Structs;
using Surfer.Controls;
using Surfer.Forms;
using System;

namespace Surfer.BrowserSettings
{
    public class MyFindHandler : IFindHandler
    {
        private Browser MyBrowser;

        public MyFindHandler(Browser browser)
        {
            MyBrowser = browser;
        }
        public void OnFindResult(IWebBrowser chromiumWebBrowser, IBrowser browser, int identifier, int count, Rect selectionRect, int activeMatchOrdinal, bool finalUpdate)
        {
            Search search = (MyBrowser.searchPopupForm.Content as Search);
            search.SetNumbers(activeMatchOrdinal, count);
        }
    }
}
