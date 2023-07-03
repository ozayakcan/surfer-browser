using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using Etier.IconHelper;
using Surfer.Utils;
using Surfer.Utils.Browser;

namespace Surfer.Controls.Downloads
{
    public partial class SBDownloadItem : UserControl
    {
        public DownloadFile downloadFile;
        public IDownloadItemCallback callback;
        private Forms.Browser MyBrowser;
        public SBDownloadItem(Forms.Browser browser, DownloadFile downloadFile)
        {
            InitializeComponent();
            MyBrowser = browser;
            lblOpenFile.Text = Language.Get.open_file;
            if (downloadFile != null)
                InitializeItem(downloadFile, null);
        }
        public void InitializeItem(DownloadFile downloadFile, IDownloadItemCallback callback, int percentage = -1)
        {
            this.callback = callback;
            this.downloadFile = downloadFile;
            imgFile.Image = IconReader.GetFileIcon(downloadFile.FileName, IconReader.IconSize.Small, false).ToBitmap();
            lblTitle.Text = downloadFile.FileName;
            if (percentage <= 0)
                pnlPbDownload.Visible = false;
            else
            {
                pbDownload.Value = percentage;
                pnlPbDownload.Visible = true;
            }
            lblDownloaded.Visible = true;
            if (percentage >= 0)
            {
                lblDownloaded.Text = StringHandler.SizeConverter(downloadFile.ReceivedBytes) + "/" + StringHandler.SizeConverter(downloadFile.TotalBytes);
            }
            else
            {
                lblDownloaded.Text = StringHandler.SizeConverter(downloadFile.ReceivedBytes);
            }
            lblSpeed.Text = StringHandler.SizeConverter(downloadFile.CurrentSpeed) + "/s";

            lblRemainingTime.Text = "";
            if (percentage >= 0 && downloadFile.TotalBytes > 0 && downloadFile.CurrentSpeed > 0)
            {
                long remBytes = downloadFile.TotalBytes - downloadFile.ReceivedBytes;
                long remTime = remBytes / downloadFile.CurrentSpeed;
                lblRemainingTime.Text = StringHandler.TimeConverter(remTime);
                lblRemainingTime.BringToFront();
                lblRemainingTime.Visible = true;
            }
            else
            {
                lblRemainingTime.Visible = false;
            }
            lblOpenFile.Visible = downloadFile.Completed;
            btnRestart.Visible = downloadFile.Cancelled;
            if (downloadFile.Completed)
            {
                if(callback != null)
                    File.Move(downloadFile.TempLocation, downloadFile.Location);
                btnPause.Visible = btnCancel.Visible = pnlPbDownload.Visible = lblDownloaded.Visible = lblHyphen.Visible = lblSpeed.Visible = false;
            }
            else
            {
                btnPause.Visible = btnCancel.Visible = lblSpeed.Visible = true;
            }
            if (!downloadFile.Completed && (downloadFile.Cancelled || callback == null))
            {
                btnCancel.Visible = btnPause.Visible = lblSpeed.Visible = lblHyphen.Visible = lblDownloaded.Visible = lblOpenFile.Visible = false;
                btnRestart.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if(callback != null)
                if(!callback.IsDisposed)
                    callback.Cancel();
        }
        private bool _paused = false;
        private void btnPause_Click(object sender, System.EventArgs e)
        {
            _paused = !_paused;
            
            if (callback != null)
                if (!callback.IsDisposed)
                {
                    if (_paused)
                    {
                        callback.Pause();
                        btnPause.IconChar = FontAwesome.Sharp.IconChar.Play;
                    }
                    else
                    {
                        callback.Resume();
                        btnPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
                    }
                }
        }

        private void btnRestart_Click(object sender, System.EventArgs e)
        {
            if(MyBrowser != null)
                MyBrowser.chBrowser.StartDownload(downloadFile.Url);
        }

        private void lblOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(downloadFile.Location);
        }
    }
}
