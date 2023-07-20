using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using Surfer.Controls;
using Surfer.Utils.Browser;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public static class SBExtensions
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
        public static int FindIndex(this Control.ControlCollection controlCollection, Func<Control, bool> predicate)
        {
            for(int i = 0; i < controlCollection.Count; i++)
            {
                if (predicate(controlCollection[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        // NewtonSoft JSON
        public static bool IsJArray(this object o)
        {
            return o.GetType() == typeof(JArray);
        }
        public static bool IsJObject(this object o)
        {
            return o.GetType() == typeof(JObject);
        }
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
            if (SBBrowserSettings.IsUrl(text))
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
        public static string ToUrl(this string text)
        {
            if (!text.IsUrl())
            {
                return text.GetSearchUrl();
            }
            else
            {
                return text;
            }
        }
        public static bool IsUrl(this string text)
        {
            return Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute);
        }
        public static SBDevTools ShowDevToolsDockedCustom(this IChromiumWebBrowserBase chromiumWebBrowser, Action<SBDevTools> addParentControl, string controlName = "ChromiumHostControlDevTools", DockStyle dockStyle = DockStyle.Fill, int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            if (!chromiumWebBrowser.IsDisposed && addParentControl != null)
            {
                SBDevTools sbDevTools = new SBDevTools(chromiumWebBrowser)
                {
                    Name = controlName,
                    Dock = dockStyle
                };
                sbDevTools.CreateControl();
                addParentControl(sbDevTools);
                sbDevTools.UpdateElementLocation(inspectElementAtX, inspectElementAtY);
                return sbDevTools;
            }
            return null;
        }
        public static SBDevTools ShowDevToolsDockedCustom(this IChromiumWebBrowserBase chromiumWebBrowser, Control parentControl, string controlName = "ChromiumHostControlDevTools", DockStyle dockStyle = DockStyle.Fill, int inspectElementAtX = 0, int inspectElementAtY = 0)
        {
            if (!chromiumWebBrowser.IsDisposed && parentControl != null && !parentControl.IsDisposed)
            {
                return chromiumWebBrowser.ShowDevToolsDockedCustom(delegate (SBDevTools ctrl)
                {
                    parentControl.Controls.Add(ctrl);
                }, controlName, dockStyle, inspectElementAtX, inspectElementAtY);
            }
            return null;
        }
    }
}
