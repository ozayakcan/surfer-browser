using FontAwesome.Sharp;

namespace Surfer.Forms
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
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.pnlChBrowser = new Surfer.Controls.SBPanel();
            this.chBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.pnlNav = new Surfer.Controls.SBPanel();
            this.pnlUrl = new Surfer.Controls.SBPanel();
            this.pnlUrlInner = new Surfer.Controls.SBPanel();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnSecure = new Surfer.Controls.SBIconButton();
            this.btnSearch = new Surfer.Controls.SBIconButton();
            this.pnlNavMarginRight = new System.Windows.Forms.Panel();
            this.pnlButtons = new Surfer.Controls.SBPanel();
            this.btnDownload = new Surfer.Controls.SBIconButton();
            this.tsNav = new System.Windows.Forms.ToolStrip();
            this.btnBack = new Surfer.Controls.MyIconToolStripButton();
            this.btnForward = new Surfer.Controls.MyIconToolStripButton();
            this.btnReload = new Surfer.Controls.MyIconToolStripButton();
            this.btnHome = new Surfer.Controls.MyIconToolStripButton();
            this.ttNav = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.pnlBrowser.SuspendLayout();
            this.pnlChBrowser.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlUrl.SuspendLayout();
            this.pnlUrlInner.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tsNav.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Controls.Add(this.pnlChBrowser);
            this.pnlBrowser.Controls.Add(this.pnlNav);
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 5);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(1005, 484);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlChBrowser
            // 
            this.pnlChBrowser.Controls.Add(this.chBrowser);
            this.pnlChBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChBrowser.Location = new System.Drawing.Point(0, 41);
            this.pnlChBrowser.Name = "pnlChBrowser";
            this.pnlChBrowser.Size = new System.Drawing.Size(1005, 443);
            this.pnlChBrowser.TabIndex = 2;
            // 
            // chBrowser
            // 
            this.chBrowser.ActivateBrowserOnCreation = true;
            this.chBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chBrowser.Location = new System.Drawing.Point(0, 0);
            this.chBrowser.Name = "chBrowser";
            this.chBrowser.Size = new System.Drawing.Size(1005, 443);
            this.chBrowser.TabIndex = 0;
            this.chBrowser.LoadError += new System.EventHandler<CefSharp.LoadErrorEventArgs>(this.chBrowser_LoadError);
            this.chBrowser.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chBrowser_LoadingStateChanged);
            this.chBrowser.IsBrowserInitializedChanged += new System.EventHandler(this.chBrowser_IsBrowserInitializedChanged);
            // 
            // pnlNav
            // 
            this.pnlNav.Controls.Add(this.pnlUrl);
            this.pnlNav.Controls.Add(this.pnlNavMarginRight);
            this.pnlNav.Controls.Add(this.pnlButtons);
            this.pnlNav.Controls.Add(this.tsNav);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Padding = new System.Windows.Forms.Padding(5);
            this.pnlNav.Size = new System.Drawing.Size(1005, 41);
            this.pnlNav.TabIndex = 1;
            // 
            // pnlUrl
            // 
            this.pnlUrl.BackColor = System.Drawing.Color.White;
            this.pnlUrl.BorderColor = System.Drawing.Color.White;
            this.pnlUrl.BorderRadius = 25;
            this.pnlUrl.BorderThickness = 3F;
            this.pnlUrl.Controls.Add(this.pnlUrlInner);
            this.pnlUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrl.Location = new System.Drawing.Point(95, 5);
            this.pnlUrl.Name = "pnlUrl";
            this.pnlUrl.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlUrl.Size = new System.Drawing.Size(877, 31);
            this.pnlUrl.TabIndex = 1;
            // 
            // pnlUrlInner
            // 
            this.pnlUrlInner.Controls.Add(this.tbUrl);
            this.pnlUrlInner.Controls.Add(this.btnSecure);
            this.pnlUrlInner.Controls.Add(this.btnSearch);
            this.pnlUrlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrlInner.Location = new System.Drawing.Point(10, 7);
            this.pnlUrlInner.Name = "pnlUrlInner";
            this.pnlUrlInner.Size = new System.Drawing.Size(857, 17);
            this.pnlUrlInner.TabIndex = 0;
            // 
            // tbUrl
            // 
            this.tbUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbUrl.BackColor = System.Drawing.Color.White;
            this.tbUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUrl.Location = new System.Drawing.Point(44, 0);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(813, 13);
            this.tbUrl.TabIndex = 2;
            this.tbUrl.Click += new System.EventHandler(this.tbUrl_Click);
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            this.tbUrl.Enter += new System.EventHandler(this.tbUrl_Enter);
            this.tbUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbUrl_KeyUp);
            this.tbUrl.Leave += new System.EventHandler(this.tbUrl_Leave);
            // 
            // btnSecure
            // 
            this.btnSecure.BackColor = System.Drawing.Color.Transparent;
            this.btnSecure.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSecure.FlatAppearance.BorderSize = 0;
            this.btnSecure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecure.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            this.btnSecure.IconColor = System.Drawing.Color.Black;
            this.btnSecure.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSecure.IconSize = 17;
            this.btnSecure.Location = new System.Drawing.Point(22, 0);
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnSecure.Size = new System.Drawing.Size(22, 17);
            this.btnSecure.TabIndex = 1;
            this.btnSecure.UseVisualStyleBackColor = false;
            this.btnSecure.Visible = false;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            this.btnSecure.MouseLeave += new System.EventHandler(this.btnSecure_MouseLeave);
            this.btnSecure.MouseHover += new System.EventHandler(this.btnSecure_MouseHover);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearch.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 17;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnSearch.Size = new System.Drawing.Size(22, 17);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.VisualDisabled = true;
            // 
            // pnlNavMarginRight
            // 
            this.pnlNavMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavMarginRight.Location = new System.Drawing.Point(972, 5);
            this.pnlNavMarginRight.Name = "pnlNavMarginRight";
            this.pnlNavMarginRight.Size = new System.Drawing.Size(11, 31);
            this.pnlNavMarginRight.TabIndex = 3;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDownload);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(983, 5);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.pnlButtons.Size = new System.Drawing.Size(17, 31);
            this.pnlButtons.TabIndex = 4;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Transparent;
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDownload.IconColor = System.Drawing.Color.Black;
            this.btnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownload.IconSize = 17;
            this.btnDownload.Location = new System.Drawing.Point(0, 7);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(17, 17);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tsNav
            // 
            this.tsNav.BackColor = System.Drawing.Color.Transparent;
            this.tsNav.CanOverflow = false;
            this.tsNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsNav.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsNav.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.btnForward,
            this.btnReload,
            this.btnHome});
            this.tsNav.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsNav.Location = new System.Drawing.Point(5, 5);
            this.tsNav.Name = "tsNav";
            this.tsNav.Padding = new System.Windows.Forms.Padding(0);
            this.tsNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsNav.Size = new System.Drawing.Size(90, 31);
            this.tsNav.Stretch = true;
            this.tsNav.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = false;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.AutoSize = false;
            this.btnForward.BackColor = System.Drawing.Color.Transparent;
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForward.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnForward.IconColor = System.Drawing.Color.Black;
            this.btnForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Margin = new System.Windows.Forms.Padding(0);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(30, 30);
            this.btnForward.Visible = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReload
            // 
            this.btnReload.AutoSize = false;
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnReload.IconColor = System.Drawing.Color.Black;
            this.btnReload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReload.IconSize = 60;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Margin = new System.Windows.Forms.Padding(0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(30, 30);
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnHome
            // 
            this.btnHome.AutoSize = false;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.Black;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(30, 30);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.pbLoading);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Location = new System.Drawing.Point(0, 0);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(1005, 5);
            this.pnlProgress.TabIndex = 2;
            this.pnlProgress.Visible = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoading.Location = new System.Drawing.Point(0, 0);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(1005, 5);
            this.pbLoading.TabIndex = 0;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 489);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.pnlProgress);
            this.Icon = global::Surfer.Properties.Resources.icon;
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Browser_Load);
            this.pnlBrowser.ResumeLayout(false);
            this.pnlChBrowser.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlUrl.ResumeLayout(false);
            this.pnlUrlInner.ResumeLayout(false);
            this.pnlUrlInner.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.tsNav.ResumeLayout(false);
            this.tsNav.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.ToolTip ttNav;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar pbLoading;
        private Controls.SBPanel pnlUrl;
        private Controls.SBPanel pnlNav;
        private System.Windows.Forms.ToolStrip tsNav;
        private Controls.MyIconToolStripButton btnBack;
        private Controls.MyIconToolStripButton btnForward;
        private Controls.MyIconToolStripButton btnHome;
        private Controls.MyIconToolStripButton btnReload;
        private System.Windows.Forms.Panel pnlNavMarginRight;
        public CefSharp.WinForms.ChromiumWebBrowser chBrowser;
        private Controls.SBPanel pnlChBrowser;
        private Controls.SBPanel pnlUrlInner;
        private Controls.SBIconButton btnSearch;
        private Controls.SBIconButton btnSecure;
        public System.Windows.Forms.TextBox tbUrl;
        private Controls.SBPanel pnlButtons;
        private Controls.SBIconButton btnDownload;
    }
}