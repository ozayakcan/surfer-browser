using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using Etier.IconHelper;
using FontAwesome.Sharp;
using IWshRuntimeLibrary;
using Microsoft.Win32;
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
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            InitializeFirst();
            MyBrowser = browser;
            lblOpenFile.Text = Locale.Get.open_file;
            if (downloadFile != null)
                InitializeItem(downloadFile, null, IsFirstInitialized: IsFirstInitialized);
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InitializeIcons();
            Invalidate();
        }

        private void InitializeFirst()
        {
            lblTitle.Text = "";
            lblDownloaded.Text = "";
            lblSpeed.Text = "";
            lblRemainingTime.Text = "";
            lblOpenFile.Text = tsmiOpenFile.Text = Locale.Get.open_file;
            tsmiRetry.Text = Locale.Get.retry;
            tsmiPauseResume.Text = Locale.Get.pause;
            tsmiShowInFolder.Text = Locale.Get.show_in_folder;
            tsmiCopyDownloadLink.Text = Locale.Get.copy_download_link;
            tsmiDeleteFile.Text = Locale.Get.delete_file;
            tsmiRemoveFromList.Text = Locale.Get.remove_from_list;
            tsmiCancel.Text = Locale.Get.cancel;
            InitializeIcons();
            toolTip1.SetToolTip(btnRetry, tsmiRetry.Text);
            toolTip1.SetToolTip(btnRemoveFromList, tsmiRemoveFromList.Text);
            toolTip1.SetToolTip(btnPauseResume, tsmiPauseResume.Text);
            toolTip1.SetToolTip(btnCancel, tsmiCancel.Text);
            toolTip1.SetToolTip(btnShowInFolder, tsmiShowInFolder.Text);
            toolTip1.SetToolTip(btnDeleteFile, tsmiDeleteFile.Text);
            Invalidate();
        }
        public void InitializeIcons()
        {
            tsmiOpenFile.Image = IconChar.File.ToBitmap(Theme.Get.ColorText);
            tsmiRetry.Image = IconChar.Refresh.ToBitmap(Theme.Get.ColorText);
            tsmiPauseResume.Image = IconChar.Pause.ToBitmap(Theme.Get.ColorText);
            tsmiShowInFolder.Image = IconChar.Folder.ToBitmap(Theme.Get.ColorText);
            tsmiCopyDownloadLink.Image = IconChar.Link.ToBitmap(Theme.Get.ColorText);
            tsmiDeleteFile.Image = IconChar.TrashCan.ToBitmap(Theme.Get.ColorText);
            tsmiRemoveFromList.Image = IconChar.Close.ToBitmap(Theme.Get.ColorText);
            tsmiCancel.Image = IconChar.Close.ToBitmap(Theme.Get.ColorText);

        }
        public void InitializeItem(DownloadFile downloadFile, IDownloadItemCallback callback, int percentage = -1, bool IsFirstInitialized = false)
        {
            this.callback = callback;
            this.downloadFile = downloadFile;
            imgFile.Image = IconReader.GetFileIcon(downloadFile.FileName, IconReader.IconSize.Small, false).ToBitmap();
            lblTitle.Text = downloadFile.FileName;
            tsmiShowInFolder.Visible = System.IO.File.Exists(downloadFile.Location);
            if (IsFirstInitialized && (!downloadFile.Completed || !System.IO.File.Exists(downloadFile.Location)))
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
                = tsmiRemoveFromList.Visible
                = tsmiDeleteFile.Visible
                = btnShowInFolder.Visible
                = btnDeleteFile.Visible
                = true;
            btnDeleteFile.SendToBack();
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
            if (callback != null && downloadFile.Completed && System.IO.File.Exists(downloadFile.TempLocation))
                System.IO.File.Move(downloadFile.TempLocation, downloadFile.Location);
        }
        private void SetRetry()
        {
            if (downloadFile.IsWebPage)
                btnRetry.Visible = tsmiRetry.Visible = false;
            else
                btnRetry.Visible = tsmiRetry.Visible = false;
            btnRemoveFromList.Visible
                = tsmiSeperator1.Visible
                = tsmiRemoveFromList.Visible
                = true;
            btnRemoveFromList.SendToBack();
            pnlPbDownload.Visible
                = lblOpenFile.Visible
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
            btnCancel.SendToBack();
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
            if (System.IO.File.Exists(downloadFile.Location))
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
            if (!System.IO.File.Exists(downloadFile.Location))
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
            if (System.IO.File.Exists(downloadFile.Location))
                System.IO.File.Delete(downloadFile.Location);
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

        bool _holding = false;
        private void SBDownloadItem_MouseDown(object sender, MouseEventArgs e)
        {
            if(downloadFile.Completed && System.IO.File.Exists(downloadFile.Location))
                _holding = true;
        }

        private void SBDownloadItem_MouseUp(object sender, MouseEventArgs e)
        {
            _holding = false;
        }

        private readonly WshShell shell = new WshShell();
        private void SBDownloadItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (_holding)
            {
                string[] filesToDrag =
                {
                    downloadFile.Location
                };
                DoDragDrop(new DataObject(DataFormats.FileDrop, filesToDrag), DragDropEffects.Copy);
                _holding = false;
            }
        }
    }
}
