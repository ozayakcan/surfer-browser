using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surfer.Utils.Browser
{
    public class SBDownloadHandler : IDownloadHandler
    {
        public bool CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
        {
            return true;
        }

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    string location = GetFileName(downloadItem.SuggestedFileName);
                    Debug.WriteLine(downloadItem.Id + " download started to " + location);
                    callback.Continue(location, showDialog: false);
                }
            }
        }
        public string GetFileName(string fileName, int current = 0)
        {
            string ext = Path.GetExtension(fileName);
            string location = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\" +
                              Path.GetFileNameWithoutExtension(fileName) + (current > 0 ? "(" + current + ")" : "") + (!string.IsNullOrEmpty(ext) ? ext : "");
            if (File.Exists(location))
                return GetFileName(fileName, current + 1);
            else
                return location;
        }
        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            Debug.WriteLine(
                downloadItem.Id
                + ", Current: " + downloadItem.ReceivedBytes
                + ", Total: " + downloadItem.TotalBytes
                + ", Speed: " + downloadItem.CurrentSpeed);
        }
    }
}
