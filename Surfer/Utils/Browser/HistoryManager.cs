using CefSharp;
using System;
using System.Collections.Generic;

namespace Surfer.Utils.Browser
{
    public class HistoryManager
    {
        public static bool IsInitialized = false;
        private readonly static string filePath = Paths.BrowserCache("History" + JSON.Extension);

        public static List<MyNavigationEntry> Get { get; set; } = new List<MyNavigationEntry>();

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    Get = JSON.readFile<List<MyNavigationEntry>>(filePath, Secrets.EncryptKey) ?? new List<MyNavigationEntry>();
                }
                catch
                {
                    Get = new List<MyNavigationEntry>();
                }
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(HistoryManager).ToString() + " is already initialized!");
            }
        }
        public static void Save(NavigationEntry history,  Action onSaved = null)
        {
            if (IsInitialized)
            {
                if(history.HttpStatusCode == 200)
                {
                    MyNavigationEntry myNavigationEntry = new MyNavigationEntry(
                            history.CompletionTime,
                            new Uri(history.DisplayUrl).GetUrlWithoutWWW(),
                            history.OriginalUrl,
                            history.Url,
                            history.Title,
                            history.SslStatus
                    );
                    int historyIndex = Get.FindIndex(h => h.DisplayUrl == myNavigationEntry.DisplayUrl);
                    if(historyIndex >= 0)
                    {
                        myNavigationEntry.Visited = Get[historyIndex].Visited + 1;
                        Get[historyIndex] = myNavigationEntry;
                    }
                    else
                        Get.Add(myNavigationEntry);
                    JSON.writeFile(filePath, Get, Secrets.EncryptKey);
                    onSaved?.Invoke();
                }
            }
        }
    }
    public class MyNavigationEntryVisitor : INavigationEntryVisitor
    {
        private Forms.Browser MyBrowser;

        public MyNavigationEntryVisitor(Forms.Browser browser)
        {
            MyBrowser = browser;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool Visit(NavigationEntry entry, bool current, int index, int total)
        {
            HistoryManager.Save(entry, onSaved: ()=> {
                MyBrowser.UpdateAutoCompletion();
            });
            return true;
        }
    }
    public class MyNavigationEntry
    {
        public DateTime CompletionTime;
        public string DisplayUrl;
        public string OriginalUrl;
        public string Url;
        public string Title;
        public SslStatus SslStatus;
        public int Visited;
        public MyNavigationEntry(
            DateTime CompletionTime,
            string DisplayUrl,
            string OriginalUrl,
            string Url,
            string Title,
            SslStatus SslStatus,
            int Visited = 1
        )
        {
            this.CompletionTime = CompletionTime;
            this.DisplayUrl = DisplayUrl;
            this.OriginalUrl = OriginalUrl;
            this.Url = Url;
            this.Title = Title;
            this.SslStatus = SslStatus;
            this.Visited = Visited;
        }
    }
}
