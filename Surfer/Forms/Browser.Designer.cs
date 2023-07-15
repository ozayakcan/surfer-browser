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
            this.pnlBrowser = new Surfer.Controls.SBPanelDark();
            this.pnlChBrowser = new Surfer.Controls.SBPanel();
            this.tsNav = new System.Windows.Forms.ToolStrip();
            this.chBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.chBrowserContextMenu = new Surfer.Controls.SBContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFavorites = new Surfer.Controls.SBPanel();
            this.pnlNav = new Surfer.Controls.SBPanel();
            this.pnlUrl = new Surfer.Controls.SBPanel();
            this.pnlUrlInner = new Surfer.Controls.SBPanel();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnSecure = new Surfer.Controls.SBIconButton();
            this.btnSearch = new Surfer.Controls.SBIconButton();
            this.btnFavorite = new Surfer.Controls.SBIconButton();
            this.pnlNavButtons = new Surfer.Controls.SBPanel();
            this.btnReloadMargin = new Surfer.Controls.SBPanel();
            this.btnReload = new Surfer.Controls.SBIconButtonDark();
            this.btnHomeMargin = new Surfer.Controls.SBPanel();
            this.btnHome = new Surfer.Controls.SBIconButtonDark();
            this.btnForwardMargin = new Surfer.Controls.SBPanel();
            this.btnForward = new Surfer.Controls.SBIconButtonDark();
            this.btnBackMargin = new Surfer.Controls.SBPanel();
            this.btnBack = new Surfer.Controls.SBIconButtonDark();
            this.pnlNavMarginRight = new System.Windows.Forms.Panel();
            this.pnlButtons = new Surfer.Controls.SBPanel();
            this.btnDownload = new Surfer.Controls.SBIconButtonDark();
            this.ttNav = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.pnlBrowser.SuspendLayout();
            this.pnlChBrowser.SuspendLayout();
            this.chBrowserContextMenu.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlUrl.SuspendLayout();
            this.pnlUrlInner.SuspendLayout();
            this.pnlNavButtons.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.pnlBrowser.Controls.Add(this.pnlChBrowser);
            this.pnlBrowser.Controls.Add(this.pnlFavorites);
            this.pnlBrowser.Controls.Add(this.pnlNav);
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 5);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(1005, 484);
            this.pnlBrowser.TabIndex = 0;
            // 
            // pnlChBrowser
            // 
            this.pnlChBrowser.BackColor = System.Drawing.Color.Transparent;
            this.pnlChBrowser.Controls.Add(this.tsNav);
            this.pnlChBrowser.Controls.Add(this.chBrowser);
            this.pnlChBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChBrowser.Location = new System.Drawing.Point(0, 61);
            this.pnlChBrowser.Name = "pnlChBrowser";
            this.pnlChBrowser.Size = new System.Drawing.Size(1005, 423);
            this.pnlChBrowser.TabIndex = 2;
            // 
            // tsNav
            // 
            this.tsNav.BackColor = System.Drawing.Color.Transparent;
            this.tsNav.CanOverflow = false;
            this.tsNav.Dock = System.Windows.Forms.DockStyle.None;
            this.tsNav.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsNav.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsNav.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsNav.Location = new System.Drawing.Point(223, 189);
            this.tsNav.Name = "tsNav";
            this.tsNav.Padding = new System.Windows.Forms.Padding(0);
            this.tsNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsNav.Size = new System.Drawing.Size(0, 0);
            this.tsNav.Stretch = true;
            this.tsNav.TabIndex = 0;
            // 
            // chBrowser
            // 
            this.chBrowser.ActivateBrowserOnCreation = true;
            this.chBrowser.ContextMenuStrip = this.chBrowserContextMenu;
            this.chBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chBrowser.Location = new System.Drawing.Point(0, 0);
            this.chBrowser.Name = "chBrowser";
            this.chBrowser.Size = new System.Drawing.Size(1005, 423);
            this.chBrowser.TabIndex = 0;
            this.chBrowser.LoadError += new System.EventHandler<CefSharp.LoadErrorEventArgs>(this.chBrowser_LoadError);
            this.chBrowser.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chBrowser_LoadingStateChanged);
            this.chBrowser.IsBrowserInitializedChanged += new System.EventHandler(this.chBrowser_IsBrowserInitializedChanged);
            // 
            // chBrowserContextMenu
            // 
            this.chBrowserContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.chBrowserContextMenu.Name = "chBrowserContextMenu";
            this.chBrowserContextMenu.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // pnlFavorites
            // 
            this.pnlFavorites.AllowDrop = true;
            this.pnlFavorites.BackColor = System.Drawing.Color.Transparent;
            this.pnlFavorites.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFavorites.Location = new System.Drawing.Point(0, 41);
            this.pnlFavorites.Name = "pnlFavorites";
            this.pnlFavorites.Size = new System.Drawing.Size(1005, 20);
            this.pnlFavorites.TabIndex = 3;
            this.pnlFavorites.Visible = false;
            this.pnlFavorites.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlFavorites_DragDrop);
            this.pnlFavorites.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlFavorites_DragOver);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.Transparent;
            this.pnlNav.Controls.Add(this.pnlUrl);
            this.pnlNav.Controls.Add(this.pnlNavButtons);
            this.pnlNav.Controls.Add(this.pnlNavMarginRight);
            this.pnlNav.Controls.Add(this.pnlButtons);
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
            this.pnlUrl.Location = new System.Drawing.Point(93, 5);
            this.pnlUrl.Name = "pnlUrl";
            this.pnlUrl.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlUrl.Size = new System.Drawing.Size(879, 31);
            this.pnlUrl.TabIndex = 1;
            // 
            // pnlUrlInner
            // 
            this.pnlUrlInner.Controls.Add(this.tbUrl);
            this.pnlUrlInner.Controls.Add(this.btnSecure);
            this.pnlUrlInner.Controls.Add(this.btnSearch);
            this.pnlUrlInner.Controls.Add(this.btnFavorite);
            this.pnlUrlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrlInner.Location = new System.Drawing.Point(10, 7);
            this.pnlUrlInner.Name = "pnlUrlInner";
            this.pnlUrlInner.Size = new System.Drawing.Size(859, 17);
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
            this.tbUrl.Size = new System.Drawing.Size(798, 13);
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
            this.btnSecure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
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
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
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
            // btnFavorite
            // 
            this.btnFavorite.BackColor = System.Drawing.Color.Transparent;
            this.btnFavorite.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFavorite.FlatAppearance.BorderSize = 0;
            this.btnFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnFavorite.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.btnFavorite.IconColor = System.Drawing.Color.Black;
            this.btnFavorite.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFavorite.IconSize = 17;
            this.btnFavorite.Location = new System.Drawing.Point(842, 0);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(17, 17);
            this.btnFavorite.TabIndex = 1;
            this.btnFavorite.UseVisualStyleBackColor = false;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.AutoSize = true;
            this.pnlNavButtons.Controls.Add(this.btnReloadMargin);
            this.pnlNavButtons.Controls.Add(this.btnReload);
            this.pnlNavButtons.Controls.Add(this.btnHomeMargin);
            this.pnlNavButtons.Controls.Add(this.btnHome);
            this.pnlNavButtons.Controls.Add(this.btnForwardMargin);
            this.pnlNavButtons.Controls.Add(this.btnForward);
            this.pnlNavButtons.Controls.Add(this.btnBackMargin);
            this.pnlNavButtons.Controls.Add(this.btnBack);
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavButtons.Location = new System.Drawing.Point(5, 5);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.pnlNavButtons.Size = new System.Drawing.Size(88, 31);
            this.pnlNavButtons.TabIndex = 1;
            // 
            // btnReloadMargin
            // 
            this.btnReloadMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReloadMargin.Location = new System.Drawing.Point(83, 7);
            this.btnReloadMargin.Name = "btnReloadMargin";
            this.btnReloadMargin.Size = new System.Drawing.Size(5, 17);
            this.btnReloadMargin.TabIndex = 7;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.btnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnReload.IconChar = FontAwesome.Sharp.IconChar.ArrowsRotate;
            this.btnReload.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnReload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReload.IconSize = 17;
            this.btnReload.Location = new System.Drawing.Point(66, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(17, 17);
            this.btnReload.TabIndex = 4;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.VisibleChanged += new System.EventHandler(this.btnReload_VisibleChanged);
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnHomeMargin
            // 
            this.btnHomeMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHomeMargin.Location = new System.Drawing.Point(61, 7);
            this.btnHomeMargin.Name = "btnHomeMargin";
            this.btnHomeMargin.Size = new System.Drawing.Size(5, 17);
            this.btnHomeMargin.TabIndex = 5;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 17;
            this.btnHome.Location = new System.Drawing.Point(44, 7);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(17, 17);
            this.btnHome.TabIndex = 3;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.VisibleChanged += new System.EventHandler(this.btnHome_VisibleChanged);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnForwardMargin
            // 
            this.btnForwardMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnForwardMargin.Location = new System.Drawing.Point(39, 7);
            this.btnForwardMargin.Name = "btnForwardMargin";
            this.btnForwardMargin.Size = new System.Drawing.Size(5, 17);
            this.btnForwardMargin.TabIndex = 6;
            this.btnForwardMargin.Visible = false;
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.Transparent;
            this.btnForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.btnForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnForward.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnForward.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnForward.IconSize = 17;
            this.btnForward.Location = new System.Drawing.Point(22, 7);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(17, 17);
            this.btnForward.TabIndex = 2;
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Visible = false;
            this.btnForward.VisibleChanged += new System.EventHandler(this.btnForward_VisibleChanged);
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackMargin
            // 
            this.btnBackMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackMargin.Location = new System.Drawing.Point(17, 7);
            this.btnBackMargin.Name = "btnBackMargin";
            this.btnBackMargin.Size = new System.Drawing.Size(5, 17);
            this.btnBackMargin.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 17;
            this.btnBack.Location = new System.Drawing.Point(0, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(17, 17);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.VisibleChanged += new System.EventHandler(this.btnBack_VisibleChanged);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
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
            this.btnDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(160)))), ((int)(((byte)(230)))));
            this.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnDownload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDownload.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownload.IconSize = 17;
            this.btnDownload.Location = new System.Drawing.Point(0, 7);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(17, 17);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.Transparent;
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
            this.pnlChBrowser.PerformLayout();
            this.chBrowserContextMenu.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlUrl.ResumeLayout(false);
            this.pnlUrlInner.ResumeLayout(false);
            this.pnlUrlInner.PerformLayout();
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.SBPanelDark pnlBrowser;
        private System.Windows.Forms.ToolTip ttNav;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar pbLoading;
        private Controls.SBPanel pnlUrl;
        private Controls.SBPanel pnlNav;
        private System.Windows.Forms.ToolStrip tsNav;
        private System.Windows.Forms.Panel pnlNavMarginRight;
        public CefSharp.WinForms.ChromiumWebBrowser chBrowser;
        private Controls.SBPanel pnlChBrowser;
        private Controls.SBPanel pnlUrlInner;
        private Controls.SBIconButton btnSearch;
        private Controls.SBIconButton btnSecure;
        public System.Windows.Forms.TextBox tbUrl;
        private Controls.SBPanel pnlButtons;
        private Controls.SBIconButtonDark btnDownload;
        private Controls.SBIconButton btnFavorite;
        private Controls.SBPanel pnlFavorites;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public Controls.SBContextMenuStrip chBrowserContextMenu;
        private Controls.SBPanel pnlNavButtons;
        private Controls.SBIconButtonDark btnBack;
        private Controls.SBIconButtonDark btnHome;
        private Controls.SBIconButtonDark btnForward;
        private Controls.SBIconButtonDark btnReload;
        private Controls.SBPanel btnBackMargin;
        private Controls.SBPanel btnForwardMargin;
        private Controls.SBPanel btnHomeMargin;
        private Controls.SBPanel btnReloadMargin;
    }
}