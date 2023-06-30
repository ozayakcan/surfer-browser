using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;
using Surfer.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Surfer.Utils.Browser
{
    public class SBLifeSpanHandler : ILifeSpanHandler
    {
        public Forms.Browser MyBrowser;

        public SBLifeSpanHandler(Forms.Browser browser)
        {
            MyBrowser = browser;

        }
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            if (browser.IsPopup)
            {
                return false;
            }
            return true;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
        List<Forms.Browser> forms = new List<Forms.Browser>();
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            if (popupFeatures.IsPopup)
            {
                Forms.Browser myBrowser = new Forms.Browser(MyBrowser.AppContainer, null)
                {
                    StartUrl = targetUrl,
                    IsPopup = true,
                };
                if (popupFeatures.Width != null)
                {
                    int _width = (int)popupFeatures.Width;
                    myBrowser.Width = _width > myBrowser.MinimumSize.Width ? myBrowser.MinimumSize.Width : _width;
                }
                if (popupFeatures.Height != null)
                {
                    int _height = (int)popupFeatures.Height;
                    myBrowser.Height = _height > myBrowser.MinimumSize.Height ? myBrowser.MinimumSize.Height : _height;
                }
                myBrowser.FormClosed += (s, e) => {
                    forms.Remove(myBrowser);
                };
                forms.Add(myBrowser);
                myBrowser.Show();
                myBrowser.BringToFront();
            }else
            {
                MyBrowser.OpenInNewTab(targetUrl, true);
            }
            return true;
        }
    }
}
