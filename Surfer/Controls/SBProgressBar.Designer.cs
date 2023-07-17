namespace Surfer.Controls
{
    partial class SBProgressBar
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
            this.pnlProgress = new Surfer.Controls.SBPanel();
            this.SuspendLayout();
            // 
            // pnlProgress
            // 
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProgress.Location = new System.Drawing.Point(0, 0);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(0, 100);
            this.pnlProgress.TabIndex = 0;
            this.ResumeLayout(false);

        }

        #endregion

        private SBPanel pnlProgress;
    }
}
