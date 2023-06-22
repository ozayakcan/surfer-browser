using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using Surfer.BrowserSettings;
using Surfer.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public static class MyExtensions
    {
        // IEnumerable
        public static T Find<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var current in enumerable)
            {
                if (predicate(current))
                {
                    return current;
                }
            }
            return default(T);
        }
        // NewtonSoft JSON
        public static Dictionary<B, T> ToDict<B, T>(this JObject jObject)
        {
            return JObject.FromObject(jObject).ToObject<Dictionary<B, T>>();
        }
        // Uri
        public static string GetUrlWithoutWWW(this Uri uri)
        {
            if (uri.HostNameType == UriHostNameType.Dns)
            {
                string host = uri.GetUrlWithoutHTTP();

                var nodes = host.Split('.');
                int startNode = 0;
                if (nodes[0] == "www") startNode = 1;
                string url = "";
                for (int i = startNode; i < nodes.Length; i++)
                {
                    if (i == startNode)
                        url += nodes[i];
                    else
                        url += "." + nodes[i];
                }
                int start = uri.AbsoluteUri.LastIndexOf(url) + url.Length;
                return url+ uri.AbsoluteUri.Substring(start);
            }
            return uri.AbsoluteUri;
        }
        public static string GetUrlWithoutHTTP(this Uri uri)
        {
            string text = uri.AbsoluteUri;
            if (MyBrowserSettings.IsUrl(text))
                return text.Substring(text.LastIndexOf(new Uri(text).Host));
            else
                return text;
        }
        // Invoke
        public static void InvokeOnUiThreadIfRequired(this ChromiumWebBrowser chromiumWebBrowser, Action action)
        {
            if (chromiumWebBrowser.InvokeRequired)
            {
                chromiumWebBrowser.BeginInvoke((MethodInvoker)delegate {
                    action?.Invoke();
                });
            }
            else
                action?.Invoke();
        }
        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke((MethodInvoker)delegate {
                    action?.Invoke();
                });
            }
            else
                action?.Invoke();
        }

        // string
        public static string GetSearchUrl(this string text)
        {
            return "https://www.google.com/search?q=" + text;
        }
        public static DevToolsControl ShowDevToolsDockedCustom(this IChromiumWebBrowserBase chromiumWebBrowser, Action<DevToolsControl> addParentControl, string controlName = "ChromiumHostControlDevTools", DockStyle dockStyle = DockStyle.Fill, int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            if (!chromiumWebBrowser.IsDisposed && addParentControl != null)
            {
                DevToolsControl devToolsControl = new DevToolsControl(chromiumWebBrowser)
                {
                    Name = controlName,
                    Dock = dockStyle
                };
                devToolsControl.CreateControl();
                addParentControl(devToolsControl);
                devToolsControl.UpdateElementLocation(inspectElementAtX, inspectElementAtY);
                return devToolsControl;
            }
            return null;
        }
        public static DevToolsControl ShowDevToolsDockedCustom(this IChromiumWebBrowserBase chromiumWebBrowser, Control parentControl, string controlName = "ChromiumHostControlDevTools", DockStyle dockStyle = DockStyle.Fill, int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            if (!chromiumWebBrowser.IsDisposed && parentControl != null && !parentControl.IsDisposed)
            {
                return chromiumWebBrowser.ShowDevToolsDockedCustom(delegate (DevToolsControl ctrl)
                {
                    parentControl.Controls.Add(ctrl);
                }, controlName, dockStyle, inspectElementAtX, inspectElementAtY);
            }
            return null;
        }
    }
}
