using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using System.Windows.Forms;

namespace Surfer.Utils.Browser
{
    public class SBKeyboardHandler: IKeyboardHandler
    {
        private Forms.Browser MyBrowser;

        public SBKeyboardHandler(Forms.Browser browser)
        {
            MyBrowser = browser;
        }

        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            Debug.WriteLine("Key Codes: " + windowsKeyCode.ToString() + ", " + nativeKeyCode.ToString());
            if (type == KeyType.KeyUp)
                MyBrowser.KeyEvents((ChromiumWebBrowser)chromiumWebBrowser, modifiers, (Keys)windowsKeyCode);
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }
    }
}
