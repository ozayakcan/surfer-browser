namespace Surfer.BrowserSettings
{
    public class MyBrowserSettings
    {
        public static string HomePage
        {
            get
            {
                return "https://www.google.com/";
            }
        }
        public static bool IsSecureUrl(string url)
        {
            return url.StartsWith("https://");
        }
        public static bool IsUrl(string url)
        {
            return url.StartsWith("http://") || url.StartsWith("https://");
        }
    }
}
