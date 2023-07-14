namespace Surfer.Controls
{
    partial class FavoriteControl
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
            this.contextMenuStrip1 = new Surfer.Controls.SBContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFavoriteUrl = new Surfer.Controls.SBButton();
            this.pnlParent = new Surfer.Controls.SBPanelDark();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(106, 22);
            this.tsmiDelete.Text = "delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // btnFavoriteUrl
            // 
            this.btnFavoriteUrl.AutoEllipsis = true;
            this.btnFavoriteUrl.BackColor = System.Drawing.Color.Transparent;
            this.btnFavoriteUrl.ContextMenuStrip = this.contextMenuStrip1;
            this.btnFavoriteUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFavoriteUrl.FlatAppearance.BorderSize = 0;
            this.btnFavoriteUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavoriteUrl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFavoriteUrl.Location = new System.Drawing.Point(0, 0);
            this.btnFavoriteUrl.Name = "btnFavoriteUrl";
            this.btnFavoriteUrl.Size = new System.Drawing.Size(150, 18);
            this.btnFavoriteUrl.TabIndex = 1;
            this.btnFavoriteUrl.Text = "title";
            this.btnFavoriteUrl.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFavoriteUrl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFavoriteUrl.UseVisualStyleBackColor = false;
            this.btnFavoriteUrl.Click += new System.EventHandler(this.btnFavoriteUrl_Click);
            // 
            // pnlParent
            // 
            this.pnlParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlParent.Controls.Add(this.btnFavoriteUrl);
            this.pnlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.Size = new System.Drawing.Size(150, 18);
            this.pnlParent.TabIndex = 2;
            // 
            // FavoriteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlParent);
            this.Name = "FavoriteControl";
            this.Size = new System.Drawing.Size(150, 18);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private SBButton btnFavoriteUrl;
        private SBContextMenuStrip contextMenuStrip1;
        private SBPanelDark pnlParent;
    }
}
