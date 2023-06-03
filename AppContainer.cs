using EasyTabs;
using Surfer.BrowserSettings;

namespace Surfer
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            TitleBarTab titlebarTab = new TitleBarTab(this);
            titlebarTab.Content = new Browser(titlebarTab)
            {
                Text = "New Tab",
                StartUrl = MyBrowserSettings.HomePage,
            };
            return titlebarTab;
        }
    }
}
