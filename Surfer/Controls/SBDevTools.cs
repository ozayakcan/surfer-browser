using CefSharp;
using CefSharp.Structs;
using CefSharp.WinForms.Host;
using System.Drawing;

namespace Surfer.Controls
{
    public class SBDevTools: ChromiumHostControl
    {
        private WindowInfo _windowInfo = new WindowInfo();
        public IChromiumWebBrowserBase _chromiumWebBrowser;

        public SBDevTools(IChromiumWebBrowserBase chromiumWebBrowser)
        {
            _chromiumWebBrowser = chromiumWebBrowser;
            MinimumSize = new System.Drawing.Size(260, Size.Height);
        }
        public void UpdateElementLocation(int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            Rectangle clientRectangle = ClientRectangle;
            Rect windowBounds = new Rect(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, clientRectangle.Height);
            _windowInfo.SetAsChild(Handle, windowBounds);
            _chromiumWebBrowser.GetBrowserHost().ShowDevTools(_windowInfo, inspectElementAtX, inspectElementAtY);
        }
    }
}
