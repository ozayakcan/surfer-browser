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
            this.btnFavoriteUrl = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
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
            this.btnFavoriteUrl.UseVisualStyleBackColor = true;
            this.btnFavoriteUrl.Click += new System.EventHandler(this.btnFavoriteUrl_Click);
            // 
            // FavoriteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFavoriteUrl);
            this.Name = "FavoriteControl";
            this.Size = new System.Drawing.Size(150, 18);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.Button btnFavoriteUrl;
        private SBContextMenuStrip contextMenuStrip1;
    }
}
