namespace Surfer.Controls
{
    partial class SiteInformation
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
            this.lblConnInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConnInfo
            // 
            this.lblConnInfo.AutoSize = true;
            this.lblConnInfo.Location = new System.Drawing.Point(4, 4);
            this.lblConnInfo.Name = "lblConnInfo";
            this.lblConnInfo.Size = new System.Drawing.Size(81, 13);
            this.lblConnInfo.TabIndex = 0;
            this.lblConnInfo.Text = "Connection info";
            // 
            // SiteInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblConnInfo);
            this.Name = "SiteInformation";
            this.Size = new System.Drawing.Size(300, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnInfo;
    }
}
