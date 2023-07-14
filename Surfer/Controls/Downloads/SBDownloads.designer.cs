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
            this.lblDownloads = new Surfer.Controls.SBLabel();
            this.pnlParent = new Surfer.Controls.SBPanelDark();
            this.pnlHeader.SuspendLayout();
            this.pnlParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDownloads
            // 
            this.pnlDownloads.AutoScroll = true;
            this.pnlDownloads.BackColor = System.Drawing.Color.Transparent;
            this.pnlDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDownloads.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlDownloads.Location = new System.Drawing.Point(0, 25);
            this.pnlDownloads.Name = "pnlDownloads";
            this.pnlDownloads.Size = new System.Drawing.Size(353, 168);
            this.pnlDownloads.TabIndex = 1;
            this.pnlDownloads.WrapContents = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblDownloads);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(353, 25);
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
            // pnlParent
            // 
            this.pnlParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlParent.Controls.Add(this.pnlDownloads);
            this.pnlParent.Controls.Add(this.pnlHeader);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(353, 193);
            this.pnlParent.TabIndex = 2;
            // 
            // SBDownloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlParent);
            this.Name = "SBDownloads";
            this.Size = new System.Drawing.Size(353, 193);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SBPanel pnlHeader;
        private Surfer.Controls.SBLabel lblDownloads;
        private System.Windows.Forms.FlowLayoutPanel pnlDownloads;
        private SBPanelDark pnlParent;
    }
}
