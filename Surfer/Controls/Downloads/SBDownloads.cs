using System.Collections.Generic;
using System.Windows.Forms;
using Surfer.Utils.Browser;
using Surfer.Utils;
using CefSharp;
using System;
using System.IO;

namespace Surfer.Controls.Downloads
{
    public partial class SBDownloads : UserControl
    {
        public Forms.Browser MyBrowser { get; set; }
        public SBDownloads()
        {
            InitializeComponent();
            lblDownloads.Text = Locale.Get.downloads;
            pnlDownloads.HorizontalScroll.Visible = false;
        }
        public void UpdateDownloads()
        {
            pnlDownloads.InvokeOnUiThreadIfRequired(() =>
            {
                List<SBDownloadItem> controls = new List<SBDownloadItem>();
                foreach (var item in DownloadManager.Get)
                {
                    SBDownloadItem sbDownloadItem = new SBDownloadItem(MyBrowser, item, IsFirstInitialized: true);
                    sbDownloadItem.Width = pnlDownloads.Width - 25;
                    controls.Add(sbDownloadItem);
                }
                if (controls.Count > 0)
                {
                    pnlDownloads.Controls.Clear();
                    pnlDownloads.Controls.AddRange(controls.ToArray());
                }
                ScrollToTop();
            });
        }
        public void AddItem(DownloadFile downloadFile)
        {
            pnlDownloads.InvokeOnUiThreadIfRequired(() =>
            {
                SBDownloadItem sbDownloadItem = new SBDownloadItem(MyBrowser, downloadFile);
                sbDownloadItem.Width = pnlDownloads.Width - 25;
                pnlDownloads.Controls.Add(sbDownloadItem);
                sbDownloadItem.BringToFront();
                DownloadManager.Save(downloadFile);
                ScrollToTop();
            });
        }
        public void RemoveItem(SBDownloadItem sBDownloadItem)
        {
            pnlDownloads.InvokeOnUiThreadIfRequired(() =>{
                pnlDownloads.Controls.Remove(sBDownloadItem);
                DownloadManager.Remove(sBDownloadItem.downloadFile);
                try
                {
                    if (File.Exists(sBDownloadItem.downloadFile.TempLocation))
                        File.Delete(sBDownloadItem.downloadFile.TempLocation);
                }
                catch
                {

                }
            });
        }
        public void UpdateItem(int DownloadID, IDownloadItemCallback callback, long ReceivedBytes = 0, long TotalBytes = 0, long CurrentSpeed = 0, bool completed = false, int percentage = -1)
        {
            pnlDownloads.InvokeOnUiThreadIfRequired(() =>
            {
                ControlCollection controlCollection = pnlDownloads.Controls;
                foreach (var item in controlCollection)
                {
                    if(item.GetType() == typeof(SBDownloadItem))
                    {
                        SBDownloadItem sbDownloadItem = (SBDownloadItem)item;
                        if (sbDownloadItem.downloadFile.DownloadID == DownloadID)
                        {
                            DownloadFile downloadFile = sbDownloadItem.downloadFile;
                            downloadFile.ReceivedBytes = ReceivedBytes;
                            downloadFile.TotalBytes = TotalBytes;
                            downloadFile.CurrentSpeed = CurrentSpeed;
                            downloadFile.Completed = completed;
                            if (completed)
                                downloadFile.DownloadID = 0;
                            downloadFile.Date = DateTime.Now;
                            DownloadManager.Save(downloadFile);
                            sbDownloadItem.InitializeItem(downloadFile, callback, percentage);
                            break;
                        }
                    }
                }
            });
        }
        public void ScrollToTop()
        {
            if(pnlDownloads.Controls.Count > 0)
                pnlDownloads.ScrollControlIntoView(pnlDownloads.Controls[0]);
        }
    }
}
