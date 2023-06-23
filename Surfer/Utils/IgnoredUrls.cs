using System.Collections.Generic;

namespace Surfer.Utils
{
    public class IgnoredUrls
    {
        public static IgnoredUrl devtools = new IgnoredUrl("devtools://", true, false, false);
        public static IgnoredUrl view_source = new IgnoredUrl("view-source:", false, true, true);
        public static List<IgnoredUrl> list = new List<IgnoredUrl>()
        {
            devtools,
            view_source,
        };
        public class IgnoredUrl
        {
            public string url;
            public bool ignoreInAddress;
            public bool canChangeTitle;
            public bool changeUrl;
            public IgnoredUrl(string url, bool ignoreInAddress,  bool canChangeTitle, bool changeUrl)
            {
                this.url = url;
                this.ignoreInAddress = ignoreInAddress;
                this.canChangeTitle = canChangeTitle;
                this.changeUrl = changeUrl;
            }
        }
    }
    
}
