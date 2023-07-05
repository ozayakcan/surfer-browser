using CefSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Surfer.Utils.Browser
{
    public class SBDownloadHandler : IDownloadHandler
    {
        Forms.Browser MyBrowser;

        public SBDownloadHandler(Forms.Browser browser)
        {
            MyBrowser = browser;
        }

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
                    string location = DownloadManager.GetFileName(downloadItem.SuggestedFileName);
                    string tempLocation = DownloadManager.GetFileName(location, overwrite: true, newExt: DownloadManager.Extension);
                    MyBrowser.AppContainer.sBDownloads.AddItem(new DownloadFile(DownloadManager.LastID(), downloadItem.Id, Path.GetFileName(location), Path.GetExtension(location), location, tempLocation, downloadItem.Url, DateTime.Now));
                    callback.Continue(tempLocation, showDialog: false);
                }
            }
        }
        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            MyBrowser.AppContainer.sBDownloads.UpdateItem(downloadItem.Id, callback, downloadItem.ReceivedBytes, downloadItem.TotalBytes, downloadItem.CurrentSpeed, downloadItem.IsComplete, downloadItem.PercentComplete);
        }
    }
}
