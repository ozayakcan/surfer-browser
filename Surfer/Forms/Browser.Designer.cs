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
            this.pnlChBrowser = new Surfer.Controls.MyPanel();
            this.chBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.pnlNav = new Surfer.Controls.MyPanel();
            this.pnlUrl = new Surfer.Controls.MyPanel();
            this.tsUrl = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new Surfer.Controls.MyIconToolStripButton();
            this.btnSecure = new Surfer.Controls.MyIconToolStripButton();
            this.tbUrl = new Surfer.Controls.MyToolStripSpringTextBox();
            this.pnlNavMarginRight = new System.Windows.Forms.Panel();
            this.tsNav = new System.Windows.Forms.ToolStrip();
            this.btnBack = new Surfer.Controls.MyIconToolStripButton();
            this.btnForward = new Surfer.Controls.MyIconToolStripButton();
            this.btnHome = new Surfer.Controls.MyIconToolStripButton();
            this.btnRefresh = new Surfer.Controls.MyIconToolStripButton();
            this.ttNav = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.pnlBrowser.SuspendLayout();
            this.pnlChBrowser.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlUrl.SuspendLayout();
            this.tsUrl.SuspendLayout();
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
            this.pnlBrowser.Size = new System.Drawing.Size(800, 445);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlChBrowser
            // 
            this.pnlChBrowser.Controls.Add(this.chBrowser);
            this.pnlChBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChBrowser.Location = new System.Drawing.Point(0, 40);
            this.pnlChBrowser.Name = "pnlChBrowser";
            this.pnlChBrowser.Size = new System.Drawing.Size(800, 405);
            this.pnlChBrowser.TabIndex = 2;
            // 
            // chBrowser
            // 
            this.chBrowser.ActivateBrowserOnCreation = true;
            this.chBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chBrowser.Location = new System.Drawing.Point(0, 0);
            this.chBrowser.Name = "chBrowser";
            this.chBrowser.Size = new System.Drawing.Size(800, 405);
            this.chBrowser.TabIndex = 0;
            this.chBrowser.LoadError += new System.EventHandler<CefSharp.LoadErrorEventArgs>(this.chBrowser_LoadError);
            this.chBrowser.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chBrowser_LoadingStateChanged);
            this.chBrowser.IsBrowserInitializedChanged += new System.EventHandler(this.chBrowser_IsBrowserInitializedChanged);
            // 
            // pnlNav
            // 
            this.pnlNav.Controls.Add(this.pnlUrl);
            this.pnlNav.Controls.Add(this.pnlNavMarginRight);
            this.pnlNav.Controls.Add(this.tsNav);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Padding = new System.Windows.Forms.Padding(5);
            this.pnlNav.Size = new System.Drawing.Size(800, 40);
            this.pnlNav.TabIndex = 1;
            // 
            // pnlUrl
            // 
            this.pnlUrl.BackColor = System.Drawing.Color.White;
            this.pnlUrl.BorderColor = System.Drawing.Color.White;
            this.pnlUrl.BorderRadius = 25;
            this.pnlUrl.BorderThickness = 3F;
            this.pnlUrl.Controls.Add(this.tsUrl);
            this.pnlUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrl.Location = new System.Drawing.Point(95, 5);
            this.pnlUrl.Name = "pnlUrl";
            this.pnlUrl.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlUrl.Size = new System.Drawing.Size(689, 30);
            this.pnlUrl.TabIndex = 1;
            // 
            // tsUrl
            // 
            this.tsUrl.BackColor = System.Drawing.Color.Transparent;
            this.tsUrl.CanOverflow = false;
            this.tsUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsUrl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsUrl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsUrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnSecure,
            this.tbUrl});
            this.tsUrl.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsUrl.Location = new System.Drawing.Point(10, 3);
            this.tsUrl.Name = "tsUrl";
            this.tsUrl.Padding = new System.Windows.Forms.Padding(0);
            this.tsUrl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsUrl.Size = new System.Drawing.Size(669, 24);
            this.tsUrl.Stretch = true;
            this.tsUrl.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearch.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 20);
            this.btnSearch.VisualDisabled = true;
            // 
            // btnSecure
            // 
            this.btnSecure.BackColor = System.Drawing.Color.Transparent;
            this.btnSecure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSecure.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            this.btnSecure.IconColor = System.Drawing.Color.Black;
            this.btnSecure.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSecure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Size = new System.Drawing.Size(23, 20);
            this.btnSecure.ToolTipText = "Show Site Information";
            this.btnSecure.Visible = false;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            this.btnSecure.MouseLeave += new System.EventHandler(this.btnSecure_MouseLeave);
            this.btnSecure.MouseHover += new System.EventHandler(this.btnSecure_MouseHover);
            // 
            // tbUrl
            // 
            this.tbUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbUrl.AutoSize = false;
            this.tbUrl.BackColor = System.Drawing.Color.White;
            this.tbUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUrl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(615, 16);
            this.tbUrl.Enter += new System.EventHandler(this.tbUrl_Enter);
            this.tbUrl.Leave += new System.EventHandler(this.tbUrl_Leave);
            this.tbUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbUrl_KeyUp);
            this.tbUrl.Click += new System.EventHandler(this.tbUrl_Click);
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            // 
            // pnlNavMarginRight
            // 
            this.pnlNavMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavMarginRight.Location = new System.Drawing.Point(784, 5);
            this.pnlNavMarginRight.Name = "pnlNavMarginRight";
            this.pnlNavMarginRight.Size = new System.Drawing.Size(11, 30);
            this.pnlNavMarginRight.TabIndex = 3;
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
            this.btnHome,
            this.btnRefresh});
            this.tsNav.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsNav.Location = new System.Drawing.Point(5, 5);
            this.tsNav.Name = "tsNav";
            this.tsNav.Padding = new System.Windows.Forms.Padding(0);
            this.tsNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsNav.Size = new System.Drawing.Size(90, 30);
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
            this.btnBack.ToolTipText = "Go Back";
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
            this.btnForward.ToolTipText = "Go Forward";
            this.btnForward.Visible = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
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
            this.btnHome.ToolTipText = "Go Home Page";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnRefresh.IconColor = System.Drawing.Color.Black;
            this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefresh.IconSize = 60;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.ToolTipText = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.pbLoading);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Location = new System.Drawing.Point(0, 0);
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
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.pnlProgress);
            this.Icon = global::Surfer.Properties.Resources.tab_icon;
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Tab";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.pnlBrowser.ResumeLayout(false);
            this.pnlChBrowser.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlUrl.ResumeLayout(false);
            this.pnlUrl.PerformLayout();
            this.tsUrl.ResumeLayout(false);
            this.tsUrl.PerformLayout();
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
        private Controls.MyPanel pnlUrl;
        private Controls.MyPanel pnlNav;
        private System.Windows.Forms.ToolStrip tsNav;
        private Controls.MyIconToolStripButton btnBack;
        private Controls.MyIconToolStripButton btnForward;
        private Controls.MyIconToolStripButton btnHome;
        private Controls.MyIconToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlNavMarginRight;
        private System.Windows.Forms.ToolStrip tsUrl;
        private Controls.MyIconToolStripButton btnSecure;
        private Surfer.Controls.MyToolStripSpringTextBox tbUrl;
        private Controls.MyIconToolStripButton btnSearch;
        public CefSharp.WinForms.ChromiumWebBrowser chBrowser;
        private Controls.MyPanel pnlChBrowser;
    }
}