namespace Surfer.Controls.Downloads
{
    partial class SBDownloadItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgFile = new System.Windows.Forms.PictureBox();
            this.downloadItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRetry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPauseResume = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowInFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyDownloadLink = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlFile = new Surfer.Controls.SBPanel();
            this.pnlFooter = new Surfer.Controls.SBPanel();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblHyphen = new System.Windows.Forms.Label();
            this.lblDownloaded = new System.Windows.Forms.Label();
            this.lblOpenFile = new System.Windows.Forms.LinkLabel();
            this.pnlPbDownload = new Surfer.Controls.SBPanel();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.pnlHeader = new Surfer.Controls.SBPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRetry = new Surfer.Controls.SBIconButton();
            this.btnPauseResume = new Surfer.Controls.SBIconButton();
            this.btnCancel = new Surfer.Controls.SBIconButton();
            this.btnDeleteFile = new Surfer.Controls.SBIconButton();
            this.btnShowInFolder = new Surfer.Controls.SBIconButton();
            this.btnRemoveFromList = new Surfer.Controls.SBIconButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).BeginInit();
            this.downloadItemContextMenu.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlPbDownload.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgFile
            // 
            this.imgFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgFile.Location = new System.Drawing.Point(0, 0);
            this.imgFile.Name = "imgFile";
            this.imgFile.Size = new System.Drawing.Size(26, 33);
            this.imgFile.TabIndex = 0;
            this.imgFile.TabStop = false;
            // 
            // downloadItemContextMenu
            // 
            this.downloadItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFile,
            this.tsmiRetry,
            this.tsmiSeperator1,
            this.tsmiPauseResume,
            this.tsmiShowInFolder,
            this.tsmiCopyDownloadLink,
            this.tsmiSeperator2,
            this.tsmiDeleteFile,
            this.tsmiRemoveFromList,
            this.tsmiCancel});
            this.downloadItemContextMenu.Name = "downloadItemContextMenu";
            this.downloadItemContextMenu.Size = new System.Drawing.Size(177, 192);
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(176, 22);
            this.tsmiOpenFile.Text = "openFile";
            this.tsmiOpenFile.Visible = false;
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // tsmiRetry
            // 
            this.tsmiRetry.Name = "tsmiRetry";
            this.tsmiRetry.Size = new System.Drawing.Size(176, 22);
            this.tsmiRetry.Text = "retry";
            this.tsmiRetry.Visible = false;
            this.tsmiRetry.Click += new System.EventHandler(this.Retry);
            // 
            // tsmiSeperator1
            // 
            this.tsmiSeperator1.Name = "tsmiSeperator1";
            this.tsmiSeperator1.Size = new System.Drawing.Size(173, 6);
            this.tsmiSeperator1.Visible = false;
            // 
            // tsmiPauseResume
            // 
            this.tsmiPauseResume.Name = "tsmiPauseResume";
            this.tsmiPauseResume.Size = new System.Drawing.Size(176, 22);
            this.tsmiPauseResume.Text = "pause_resume";
            this.tsmiPauseResume.Visible = false;
            this.tsmiPauseResume.Click += new System.EventHandler(this.PauseResume);
            // 
            // tsmiShowInFolder
            // 
            this.tsmiShowInFolder.Name = "tsmiShowInFolder";
            this.tsmiShowInFolder.Size = new System.Drawing.Size(176, 22);
            this.tsmiShowInFolder.Text = "showInFolder";
            this.tsmiShowInFolder.Visible = false;
            this.tsmiShowInFolder.Click += new System.EventHandler(this.ShowInFolder);
            // 
            // tsmiCopyDownloadLink
            // 
            this.tsmiCopyDownloadLink.Name = "tsmiCopyDownloadLink";
            this.tsmiCopyDownloadLink.Size = new System.Drawing.Size(176, 22);
            this.tsmiCopyDownloadLink.Text = "copyDownloadLink";
            this.tsmiCopyDownloadLink.Click += new System.EventHandler(this.tsmiCopyDownloadLink_Click);
            // 
            // tsmiSeperator2
            // 
            this.tsmiSeperator2.Name = "tsmiSeperator2";
            this.tsmiSeperator2.Size = new System.Drawing.Size(173, 6);
            // 
            // tsmiDeleteFile
            // 
            this.tsmiDeleteFile.Name = "tsmiDeleteFile";
            this.tsmiDeleteFile.Size = new System.Drawing.Size(176, 22);
            this.tsmiDeleteFile.Text = "deleteFile";
            this.tsmiDeleteFile.Visible = false;
            this.tsmiDeleteFile.Click += new System.EventHandler(this.DeleteFile);
            // 
            // tsmiRemoveFromList
            // 
            this.tsmiRemoveFromList.Name = "tsmiRemoveFromList";
            this.tsmiRemoveFromList.Size = new System.Drawing.Size(176, 22);
            this.tsmiRemoveFromList.Text = "removeFromList";
            this.tsmiRemoveFromList.Visible = false;
            this.tsmiRemoveFromList.Click += new System.EventHandler(this.RemoveFromList);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(176, 22);
            this.tsmiCancel.Text = "cancel";
            this.tsmiCancel.Visible = false;
            this.tsmiCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.pnlFooter);
            this.pnlFile.Controls.Add(this.pnlPbDownload);
            this.pnlFile.Controls.Add(this.pnlHeader);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFile.Location = new System.Drawing.Point(26, 0);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(170, 33);
            this.pnlFile.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblRemainingTime);
            this.pnlFooter.Controls.Add(this.lblSpeed);
            this.pnlFooter.Controls.Add(this.lblHyphen);
            this.pnlFooter.Controls.Add(this.lblDownloaded);
            this.pnlFooter.Controls.Add(this.lblOpenFile);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(0, 20);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(170, 13);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRemainingTime.Location = new System.Drawing.Point(161, 0);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(24, 13);
            this.lblRemainingTime.TabIndex = 8;
            this.lblRemainingTime.Text = "rem";
            this.lblRemainingTime.Visible = false;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpeed.Location = new System.Drawing.Point(125, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(36, 13);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "speed";
            this.lblSpeed.Visible = false;
            // 
            // lblHyphen
            // 
            this.lblHyphen.AutoSize = true;
            this.lblHyphen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHyphen.Location = new System.Drawing.Point(115, 0);
            this.lblHyphen.Name = "lblHyphen";
            this.lblHyphen.Size = new System.Drawing.Size(10, 13);
            this.lblHyphen.TabIndex = 4;
            this.lblHyphen.Text = "-";
            this.lblHyphen.Visible = false;
            // 
            // lblDownloaded
            // 
            this.lblDownloaded.AutoSize = true;
            this.lblDownloaded.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDownloaded.Location = new System.Drawing.Point(50, 0);
            this.lblDownloaded.Name = "lblDownloaded";
            this.lblDownloaded.Size = new System.Drawing.Size(65, 13);
            this.lblDownloaded.TabIndex = 7;
            this.lblDownloaded.Text = "downloaded";
            this.lblDownloaded.Visible = false;
            // 
            // lblOpenFile
            // 
            this.lblOpenFile.AutoSize = true;
            this.lblOpenFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOpenFile.Location = new System.Drawing.Point(0, 0);
            this.lblOpenFile.Name = "lblOpenFile";
            this.lblOpenFile.Size = new System.Drawing.Size(50, 13);
            this.lblOpenFile.TabIndex = 1;
            this.lblOpenFile.TabStop = true;
            this.lblOpenFile.Text = "open_file";
            this.lblOpenFile.Visible = false;
            this.lblOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOpenFile_LinkClicked);
            // 
            // pnlPbDownload
            // 
            this.pnlPbDownload.Controls.Add(this.pbDownload);
            this.pnlPbDownload.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPbDownload.Location = new System.Drawing.Point(0, 13);
            this.pnlPbDownload.Name = "pnlPbDownload";
            this.pnlPbDownload.Size = new System.Drawing.Size(170, 7);
            this.pnlPbDownload.TabIndex = 3;
            this.pnlPbDownload.Visible = false;
            // 
            // pbDownload
            // 
            this.pbDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDownload.Location = new System.Drawing.Point(0, 0);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(170, 7);
            this.pbDownload.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(170, 13);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(23, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "title";
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.Transparent;
            this.btnRetry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRetry.FlatAppearance.BorderSize = 0;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnRetry.IconColor = System.Drawing.Color.Black;
            this.btnRetry.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRetry.IconSize = 26;
            this.btnRetry.Location = new System.Drawing.Point(144, 0);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(26, 33);
            this.btnRetry.TabIndex = 5;
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.Retry);
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseResume.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPauseResume.FlatAppearance.BorderSize = 0;
            this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseResume.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.btnPauseResume.IconColor = System.Drawing.Color.Black;
            this.btnPauseResume.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPauseResume.IconSize = 26;
            this.btnPauseResume.Location = new System.Drawing.Point(196, 0);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(26, 33);
            this.btnPauseResume.TabIndex = 4;
            this.btnPauseResume.UseVisualStyleBackColor = false;
            this.btnPauseResume.Visible = false;
            this.btnPauseResume.Click += new System.EventHandler(this.PauseResume);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 26;
            this.btnCancel.Location = new System.Drawing.Point(222, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(26, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteFile.FlatAppearance.BorderSize = 0;
            this.btnDeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFile.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            this.btnDeleteFile.IconColor = System.Drawing.Color.Black;
            this.btnDeleteFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteFile.IconSize = 26;
            this.btnDeleteFile.Location = new System.Drawing.Point(274, 0);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(26, 33);
            this.btnDeleteFile.TabIndex = 6;
            this.btnDeleteFile.UseVisualStyleBackColor = false;
            this.btnDeleteFile.Visible = false;
            this.btnDeleteFile.Click += new System.EventHandler(this.DeleteFile);
            // 
            // btnShowInFolder
            // 
            this.btnShowInFolder.BackColor = System.Drawing.Color.Transparent;
            this.btnShowInFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowInFolder.FlatAppearance.BorderSize = 0;
            this.btnShowInFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInFolder.IconChar = FontAwesome.Sharp.IconChar.FolderBlank;
            this.btnShowInFolder.IconColor = System.Drawing.Color.Black;
            this.btnShowInFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowInFolder.IconSize = 26;
            this.btnShowInFolder.Location = new System.Drawing.Point(248, 0);
            this.btnShowInFolder.Name = "btnShowInFolder";
            this.btnShowInFolder.Size = new System.Drawing.Size(26, 33);
            this.btnShowInFolder.TabIndex = 7;
            this.btnShowInFolder.UseVisualStyleBackColor = false;
            this.btnShowInFolder.Visible = false;
            this.btnShowInFolder.Click += new System.EventHandler(this.ShowInFolder);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveFromList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveFromList.FlatAppearance.BorderSize = 0;
            this.btnRemoveFromList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromList.IconChar = FontAwesome.Sharp.IconChar.Close;
            this.btnRemoveFromList.IconColor = System.Drawing.Color.Black;
            this.btnRemoveFromList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemoveFromList.IconSize = 26;
            this.btnRemoveFromList.Location = new System.Drawing.Point(170, 0);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(26, 33);
            this.btnRemoveFromList.TabIndex = 8;
            this.btnRemoveFromList.UseVisualStyleBackColor = false;
            this.btnRemoveFromList.Visible = false;
            this.btnRemoveFromList.Click += new System.EventHandler(this.RemoveFromList);
            // 
            // SBDownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.downloadItemContextMenu;
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.pnlFile);
            this.Controls.Add(this.imgFile);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShowInFolder);
            this.Controls.Add(this.btnDeleteFile);
            this.Name = "SBDownloadItem";
            this.Size = new System.Drawing.Size(300, 33);
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).EndInit();
            this.downloadItemContextMenu.ResumeLayout(false);
            this.pnlFile.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlPbDownload.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SBIconButton btnCancel;
        private SBPanel pnlFile;
        private System.Windows.Forms.LinkLabel lblOpenFile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox imgFile;
        private SBPanel pnlFooter;
        private SBPanel pnlHeader;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Label lblDownloaded;
        private System.Windows.Forms.Label lblHyphen;
        private System.Windows.Forms.Label lblSpeed;
        private SBIconButton btnPauseResume;
        private SBIconButton btnRetry;
        private SBPanel pnlPbDownload;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.ContextMenuStrip downloadItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowInFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiRetry;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyDownloadLink;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveFromList;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.ToolStripMenuItem tsmiPauseResume;
        private System.Windows.Forms.ToolStripSeparator tsmiSeperator2;
        private System.Windows.Forms.ToolTip toolTip1;
        private SBIconButton btnDeleteFile;
        private SBIconButton btnShowInFolder;
        private SBIconButton btnRemoveFromList;
    }
}
