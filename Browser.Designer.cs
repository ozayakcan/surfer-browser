namespace Surfer
{
    partial class Browser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.ttNav = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new Surfer.Controls.MyIconButton();
            this.btnHome = new Surfer.Controls.MyIconButton();
            this.btnForward = new Surfer.Controls.MyIconButton();
            this.btnBack = new Surfer.Controls.MyIconButton();
            this.pnlNav.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.tbUrl);
            this.pnlNav.Controls.Add(this.btnRefresh);
            this.pnlNav.Controls.Add(this.btnHome);
            this.pnlNav.Controls.Add(this.btnForward);
            this.pnlNav.Controls.Add(this.btnBack);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(800, 20);
            this.pnlNav.TabIndex = 0;
            // 
            // tbUrl
            // 
            this.tbUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUrl.Location = new System.Drawing.Point(80, 0);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(720, 20);
            this.tbUrl.TabIndex = 0;
            this.tbUrl.Click += new System.EventHandler(this.tbUrl_Click);
            this.tbUrl.Enter += new System.EventHandler(this.tbUrl_Enter);
            this.tbUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUrl_KeyPress);
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 25);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(800, 425);
            this.pnlBrowser.TabIndex = 1;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.pbLoading);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Location = new System.Drawing.Point(0, 20);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(800, 5);
            this.pnlProgress.TabIndex = 2;
            this.pnlProgress.Visible = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoading.Location = new System.Drawing.Point(0, 0);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(800, 5);
            this.pbLoading.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnRefresh.IconColor = System.Drawing.Color.Black;
            this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefresh.IconSize = 20;
            this.btnRefresh.Location = new System.Drawing.Point(60, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(20, 20);
            this.btnRefresh.TabIndex = 3;
            this.ttNav.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.Black;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 20;
            this.btnHome.Location = new System.Drawing.Point(40, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(20, 20);
            this.btnHome.TabIndex = 2;
            this.ttNav.SetToolTip(this.btnHome, "Go Home Page");
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.White;
            this.btnForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnForward.IconColor = System.Drawing.Color.Black;
            this.btnForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnForward.IconSize = 20;
            this.btnForward.Location = new System.Drawing.Point(20, 0);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(20, 20);
            this.btnForward.TabIndex = 1;
            this.ttNav.SetToolTip(this.btnForward, "Go Forward");
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Visible = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 20;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(20, 20);
            this.btnBack.TabIndex = 0;
            this.ttNav.SetToolTip(this.btnBack, "Go Back");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlNav);
            this.Icon = global::Surfer.Properties.Resources.tab_icon;
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Tab";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Panel pnlBrowser;
        private Surfer.Controls.MyIconButton btnHome;
        private Surfer.Controls.MyIconButton btnForward;
        private Surfer.Controls.MyIconButton btnBack;
        private Surfer.Controls.MyIconButton btnRefresh;
        private System.Windows.Forms.ToolTip ttNav;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar pbLoading;
    }
}