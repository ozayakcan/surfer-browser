namespace Surfer.Controls
{
    partial class Search
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.btnFindPrev = new Surfer.Controls.MyIconButton();
            this.btnFindNext = new Surfer.Controls.MyIconButton();
            this.btnClose = new Surfer.Controls.MyIconButton();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.Silver;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Location = new System.Drawing.Point(5, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(129, 13);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Location = new System.Drawing.Point(159, 5);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "0";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrent.Location = new System.Drawing.Point(147, 5);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(12, 13);
            this.lblCurrent.TabIndex = 9;
            this.lblCurrent.Text = "/";
            // 
            // lblCur
            // 
            this.lblCur.AutoSize = true;
            this.lblCur.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCur.Location = new System.Drawing.Point(134, 5);
            this.lblCur.Margin = new System.Windows.Forms.Padding(0);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(13, 13);
            this.lblCur.TabIndex = 10;
            this.lblCur.Text = "0";
            // 
            // btnFindPrev
            // 
            this.btnFindPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnFindPrev.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindPrev.FlatAppearance.BorderSize = 0;
            this.btnFindPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPrev.IconChar = FontAwesome.Sharp.IconChar.ChevronUp;
            this.btnFindPrev.IconColor = System.Drawing.Color.Black;
            this.btnFindPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFindPrev.IconSize = 20;
            this.btnFindPrev.Location = new System.Drawing.Point(172, 5);
            this.btnFindPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnFindPrev.Name = "btnFindPrev";
            this.btnFindPrev.Size = new System.Drawing.Size(21, 13);
            this.btnFindPrev.TabIndex = 2;
            this.btnFindPrev.UseVisualStyleBackColor = false;
            this.btnFindPrev.Click += new System.EventHandler(this.btnFindPrev_Click);
            // 
            // btnFindNext
            // 
            this.btnFindNext.BackColor = System.Drawing.Color.Transparent;
            this.btnFindNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindNext.FlatAppearance.BorderSize = 0;
            this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindNext.IconChar = FontAwesome.Sharp.IconChar.ChevronDown;
            this.btnFindNext.IconColor = System.Drawing.Color.Black;
            this.btnFindNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFindNext.IconSize = 20;
            this.btnFindNext.Location = new System.Drawing.Point(193, 5);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(21, 13);
            this.btnFindNext.TabIndex = 3;
            this.btnFindNext.UseVisualStyleBackColor = false;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 20;
            this.btnClose.Location = new System.Drawing.Point(214, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 13);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblCur);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnFindPrev);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.btnClose);
            this.Name = "Search";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(240, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private MyIconButton btnClose;
        private MyIconButton btnFindPrev;
        private MyIconButton btnFindNext;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.Label lblTotal;
    }
}
