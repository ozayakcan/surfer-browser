using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using Etier.IconHelper;
using FontAwesome.Sharp;
using Surfer.Utils;
using Surfer.Utils.Browser;

namespace Surfer.Controls.Downloads
{
    public partial class SBDownloadItem : UserControl
    {
        public DownloadFile downloadFile;
        public IDownloadItemCallback callback;
        private Forms.Browser MyBrowser;
        public SBDownloadItem(Forms.Browser browser, DownloadFile downloadFile, bool IsFirstInitialized = false)
        {
            InitializeComponent();
            InitializeFirst();
            MyBrowser = browser;
            lblOpenFile.Text = Locale.Get.open_file;
            if (downloadFile != null)
                InitializeItem(downloadFile, null, IsFirstInitialized: IsFirstInitialized);
        }
        private void InitializeFirst()
        {
            lblTitle.Text = "";
            lblDownloaded.Text = "";
            lblSpeed.Text = "";
            lblRemainingTime.Text = "";
            lblOpenFile.Text = tsmiOpenFile.Text = Locale.Get.open_file;
            tsmiOpenFile.Image = IconChar.File.ToBitmap(Color.Black);
            tsmiRetry.Text = Locale.Get.retry;
            tsmiRetry.Image = IconChar.Refresh.ToBitmap(Color.Black);
            tsmiPauseResume.Text = Locale.Get.pause;
            tsmiPauseResume.Image = IconChar.Pause.ToBitmap(Color.Black);
            tsmiShowInFolder.Text = Locale.Get.show_in_folder;
            tsmiShowInFolder.Image = IconChar.Folder.ToBitmap(Color.Black);
            tsmiCopyDownloadLink.Text = Locale.Get.copy_download_link;
            tsmiCopyDownloadLink.Image = IconChar.Link.ToBitmap(Color.Black);
            tsmiDeleteFile.Text = Locale.Get.delete_file;
            tsmiDeleteFile.Image = IconChar.Trash.ToBitmap(Color.Black);
            tsmiRemoveFromList.Text = Locale.Get.remove_from_list;
            tsmiRemoveFromList.Image = IconChar.Close.ToBitmap(Color.Black);
            tsmiCancel.Text = Locale.Get.cancel;
            tsmiCancel.Image = IconChar.Close.ToBitmap(Color.Black);
            toolTip1.SetToolTip(btnRetry, tsmiRetry.Text);
            toolTip1.SetToolTip(btnRemoveFromList, tsmiRemoveFromList.Text);
            toolTip1.SetToolTip(btnPauseResume, tsmiPauseResume.Text);
            toolTip1.SetToolTip(btnCancel, tsmiCancel.Text);
            toolTip1.SetToolTip(btnShowInFolder, tsmiShowInFolder.Text);
            toolTip1.SetToolTip(btnDeleteFile, tsmiDeleteFile.Text);
        }
        public void InitializeItem(DownloadFile downloadFile, IDownloadItemCallback callback, int percentage = -1, bool IsFirstInitialized = false)
        {
            this.callback = callback;
            this.downloadFile = downloadFile;
            imgFile.Image = IconReader.GetFileIcon(downloadFile.FileName, IconReader.IconSize.Small, false).ToBitmap();
            lblTitle.Text = downloadFile.FileName;
            tsmiShowInFolder.Visible = File.Exists(downloadFile.Location);
            if (IsFirstInitialized && (!downloadFile.Completed || !File.Exists(downloadFile.Location)))
                SetRetry();
            else if (downloadFile.Completed)
                SetCompleted();
            else
                SetDownloading(percentage);
        }

        private void SetCompleted()
        {
            lblOpenFile.Visible
                = tsmiOpenFile.Visible
                = tsmiSeperator1.Visible
                = tsmiDeleteFile.Visible
                = tsmiRemoveFromList.Visible
                = btnShowInFolder.Visible
                = btnDeleteFile.Visible
                = true;
            pnlPbDownload.Visible
                = lblDownloaded.Visible
                = lblHyphen.Visible
                = lblSpeed.Visible
                = lblRemainingTime.Visible
                = btnRetry.Visible
                = btnRemoveFromList.Visible
                = btnPauseResume.Visible
                = btnCancel.Visible
                = tsmiRetry.Visible
                = tsmiPauseResume.Visible
                = tsmiCancel.Visible
                = false;
            if (callback != null)
                File.Move(downloadFile.TempLocation, downloadFile.Location);
        }
        private void SetRetry()
        {
            btnRetry.Visible
                = btnRemoveFromList.Visible
                = tsmiRetry.Visible
                = tsmiSeperator1.Visible
                = tsmiRemoveFromList.Visible
                = true;
            lblOpenFile.Visible
                = pnlPbDownload.Visible
                = lblOpenFile.Visible
                = lblDownloaded.Visible
                = lblHyphen.Visible
                = lblSpeed.Visible
                = lblRemainingTime.Visible
                = btnPauseResume.Visible
                = btnCancel.Visible
                = btnShowInFolder.Visible
                = btnDeleteFile.Visible
                = tsmiOpenFile.Visible
                = tsmiPauseResume.Visible
                = tsmiShowInFolder.Visible
                = tsmiDeleteFile.Visible
                = tsmiCancel.Visible
                = false;
        }
        private void SetDownloading(int percentage)
        {
            lblDownloaded.Visible
                = lblHyphen.Visible
                = lblSpeed.Visible
                = btnPauseResume.Visible
                = btnCancel.Visible
                = tsmiPauseResume.Visible
                = tsmiCancel.Visible
                = true;
            lblOpenFile.Visible
                = btnRetry.Visible
                = btnRemoveFromList.Visible
                = btnShowInFolder.Visible
                = btnDeleteFile.Visible
                = tsmiOpenFile.Visible
                = tsmiRetry.Visible
                = tsmiSeperator1.Visible
                = tsmiShowInFolder.Visible
                = tsmiDeleteFile.Visible
                = tsmiRemoveFromList.Visible
                = false;
            if (percentage < 0)
            {
                lblDownloaded.Text = StringHandler.SizeConverter(downloadFile.ReceivedBytes);
                pnlPbDownload.Visible = false;
            }
            else
            {
                pbDownload.Value = percentage;
                pnlPbDownload.Visible = true;
                lblDownloaded.Text = StringHandler.SizeConverter(downloadFile.ReceivedBytes) + "/" + StringHandler.SizeConverter(downloadFile.TotalBytes);
            }

            lblSpeed.Text = StringHandler.SizeConverter(downloadFile.CurrentSpeed) + "/s";
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
        }

        private void lblOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFile();
        }
        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void OpenFile()
        {
            if (File.Exists(downloadFile.Location))
                Process.Start(downloadFile.Location);
        }

        private void Retry(object sender, EventArgs e)
        {
            if (MyBrowser != null)
                MyBrowser.chBrowser.StartDownload(downloadFile.Url);
        }

        private bool _paused = false;
        private void PauseResume(object sender, EventArgs e)
        {
            _paused = !_paused;

            if (callback != null)
                if (!callback.IsDisposed)
                {
                    if (_paused)
                    {
                        callback.Pause();
                        btnPauseResume.IconChar = IconChar.Play;
                        tsmiPauseResume.Text = Locale.Get.resume;
                    }
                    else
                    {
                        callback.Resume();
                        btnPauseResume.IconChar = IconChar.Pause;
                        tsmiPauseResume.Text = Locale.Get.pause;
                    }
                    toolTip1.SetToolTip(btnPauseResume, tsmiPauseResume.Text);
                    tsmiPauseResume.Image = btnPauseResume.Image;
                }
        }

        private void ShowInFolder(object sender, EventArgs e)
        {
            if (!File.Exists(downloadFile.Location))
            {
                return;
            }
            string argument = "/select, \"" + downloadFile.Location + "\"";

            Process.Start("explorer.exe", argument);
        }

        private void tsmiCopyDownloadLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(downloadFile.Url);
        }

        private void DeleteFile(object sender, EventArgs e)
        {
            if (File.Exists(downloadFile.Location))
                File.Delete(downloadFile.Location);
            SetRetry();
        }

        private void RemoveFromList(object sender, EventArgs e)
        {
            MyBrowser.AppContainer.sBDownloads.RemoveItem(this);
        }

        private void Cancel(object sender, EventArgs e)
        {
            if (callback != null)
            {
                if (!callback.IsDisposed)
                    callback.Cancel();
            }
            RemoveFromList(sender, e);
        }
    }
}
