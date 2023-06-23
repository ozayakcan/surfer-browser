using CefSharp;
using CefSharp.Structs;
using Surfer.Controls;
using Surfer.Forms;
using System;

namespace Surfer.BrowserSettings
{
    public class SBFindHandler : IFindHandler
    {
        private Browser MyBrowser;

        public SBFindHandler(Browser browser)
        {
            MyBrowser = browser;
        }
        public void OnFindResult(IWebBrowser chromiumWebBrowser, IBrowser browser, int identifier, int count, Rect selectionRect, int activeMatchOrdinal, bool finalUpdate)
        {
            SBSearch sbSearch = (MyBrowser.searchPopupForm.Content as SBSearch);
            sbSearch.SetNumbers(activeMatchOrdinal, count);
        }
    }
}
