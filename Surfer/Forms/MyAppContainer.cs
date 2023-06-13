using EasyTabs;
using Surfer.BrowserSettings;

namespace Surfer.Forms
{
    public partial class MyAppContainer : TitleBarTabs
    {
        public MyAppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            TitleBarTab titlebarTab = new TitleBarTab(this);
            titlebarTab.Content = new Browser(this, titlebarTab)
            {
                StartUrl = MyBrowserSettings.HomePage,
            };
            return titlebarTab;
        }
    }
}
