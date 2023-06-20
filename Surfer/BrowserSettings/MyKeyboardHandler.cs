using CefSharp;
using CefSharp.WinForms;
using Surfer.Forms;
using System.Diagnostics;
using System.Windows.Forms;

namespace Surfer.BrowserSettings
{
    public class MyKeyboardHandler: IKeyboardHandler
    {
        private Browser MyBrowser;

        public MyKeyboardHandler(Browser browser)
        {
            MyBrowser = browser;
        }

        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            Debug.WriteLine("Key Codes: " + windowsKeyCode.ToString() + ", " + nativeKeyCode.ToString());
            var chBrowser = (ChromiumWebBrowser)chromiumWebBrowser;
            
            
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            MyBrowser.KeyEvents((ChromiumWebBrowser)chromiumWebBrowser, modifiers, (Keys)windowsKeyCode);
            return false;
        }
    }
}
