using CefSharp;
using CefSharp.Structs;
using Surfer.Controls;

namespace Surfer.Utils.Browser
{
    public class SBFindHandler : IFindHandler
    {
        private Forms.Browser MyBrowser;

        public SBFindHandler(Forms.Browser browser)
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
