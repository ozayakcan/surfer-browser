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
            this.imgFile = new System.Windows.Forms.PictureBox();
            this.pnlFile = new Surfer.Controls.SBPanel();
            this.pnlFooter = new Surfer.Controls.SBPanel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblHyphen = new System.Windows.Forms.Label();
            this.lblDownloaded = new System.Windows.Forms.Label();
            this.lblOpenFile = new System.Windows.Forms.LinkLabel();
            this.pnlPbDownload = new Surfer.Controls.SBPanel();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.pnlHeader = new Surfer.Controls.SBPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRestart = new Surfer.Controls.SBIconButton();
            this.btnPause = new Surfer.Controls.SBIconButton();
            this.btnCancel = new Surfer.Controls.SBIconButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).BeginInit();
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
            // pnlFile
            // 
            this.pnlFile.Controls.Add(this.pnlFooter);
            this.pnlFile.Controls.Add(this.pnlPbDownload);
            this.pnlFile.Controls.Add(this.pnlHeader);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFile.Location = new System.Drawing.Point(26, 0);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(196, 33);
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
            this.pnlFooter.Size = new System.Drawing.Size(196, 13);
            this.pnlFooter.TabIndex = 3;
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
            this.pnlPbDownload.Size = new System.Drawing.Size(196, 7);
            this.pnlPbDownload.TabIndex = 3;
            this.pnlPbDownload.Visible = false;
            // 
            // pbDownload
            // 
            this.pbDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDownload.Location = new System.Drawing.Point(0, 0);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(196, 7);
            this.pbDownload.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(196, 13);
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
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnRestart.IconColor = System.Drawing.Color.Black;
            this.btnRestart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestart.IconSize = 26;
            this.btnRestart.Location = new System.Drawing.Point(222, 0);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(26, 33);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Transparent;
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.btnPause.IconColor = System.Drawing.Color.Black;
            this.btnPause.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPause.IconSize = 26;
            this.btnPause.Location = new System.Drawing.Point(248, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(26, 33);
            this.btnPause.TabIndex = 4;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(274, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(26, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SBDownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFile);
            this.Controls.Add(this.imgFile);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnCancel);
            this.Name = "SBDownloadItem";
            this.Size = new System.Drawing.Size(300, 33);
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).EndInit();
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
        private SBIconButton btnPause;
        private SBIconButton btnRestart;
        private SBPanel pnlPbDownload;
        private System.Windows.Forms.Label lblRemainingTime;
    }
}
