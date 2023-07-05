namespace Surfer.Controls.Downloads
{
    partial class SBDownloads
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
            this.pnlDownloads = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new Surfer.Controls.SBPanel();
            this.lblDownloads = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDownloads
            // 
            this.pnlDownloads.AutoScroll = true;
            this.pnlDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDownloads.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlDownloads.Location = new System.Drawing.Point(0, 25);
            this.pnlDownloads.Name = "pnlDownloads";
            this.pnlDownloads.Size = new System.Drawing.Size(350, 165);
            this.pnlDownloads.TabIndex = 1;
            this.pnlDownloads.WrapContents = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDownloads);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(350, 25);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDownloads
            // 
            this.lblDownloads.AutoSize = true;
            this.lblDownloads.Location = new System.Drawing.Point(4, 6);
            this.lblDownloads.Name = "lblDownloads";
            this.lblDownloads.Size = new System.Drawing.Size(58, 13);
            this.lblDownloads.TabIndex = 0;
            this.lblDownloads.Text = "downloads";
            // 
            // SBDownloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlDownloads);
            this.Controls.Add(this.pnlHeader);
            this.Name = "SBDownloads";
            this.Size = new System.Drawing.Size(350, 190);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SBPanel pnlHeader;
        private System.Windows.Forms.Label lblDownloads;
        private System.Windows.Forms.FlowLayoutPanel pnlDownloads;
    }
}
