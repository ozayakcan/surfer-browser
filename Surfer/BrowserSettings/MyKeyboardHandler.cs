using CefSharp;
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
            //MessageBox.Show("F3 Key: "+ ((int)Keys.F3).ToString());
            if (windowsKeyCode == (int)Keys.F3)
            {
                MyBrowser.ShowSearch();
                return true;
            }
            else if (modifiers == CefEventFlags.ControlDown && windowsKeyCode == (int)Keys.F)
            {
                MyBrowser.ShowSearch();
                return true;
            }
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }
    }
}
