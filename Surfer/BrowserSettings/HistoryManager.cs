using CefSharp;
using Surfer.Forms;
using Surfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Surfer.BrowserSettings
{
    public class HistoryManager
    {
        public static bool IsInitialized = false;
        private readonly static string filePath = Paths.BrowserCache("History.sf");

        public static List<NavigationEntry> Get { get; set; } = new List<NavigationEntry>();

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    Get = JSON.readFile<List<NavigationEntry>>(filePath/*, Keys.EncryptKey*/) ?? new List<NavigationEntry>();
                }
                catch
                {
                    Get = new List<NavigationEntry>();
                }
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(HistoryManager).ToString() + " is already initialized!");
            }
        }
        public static void Save(NavigationEntry history, Action onSaved = null)
        {
            if (IsInitialized)
            {
                if(history.HttpStatusCode == 200)
                {
                    history = new NavigationEntry(
                        history.IsCurrent,
                        history.CompletionTime,
                        new Uri(history.DisplayUrl).GetUrlWithoutWWW(),
                        history.HttpStatusCode,
                        history.OriginalUrl,
                        history.Title,
                        history.TransitionType,
                        history.Url,
                        history.HasPostData,
                        history.IsValid,
                        history.SslStatus
                    );
                    int historyIndex = Get.FindIndex(h => h.DisplayUrl == history.DisplayUrl);
                    if (historyIndex >= 0)
                        Get[historyIndex] = history;
                    else
                        Get.Add(history);
                    JSON.writeFile(filePath, Get/*, Keys.EncryptKey*/);
                    onSaved?.Invoke();
                }
            }
        }
    }
    public class MyNavigationEntryVisitor : INavigationEntryVisitor
    {
        private Browser MyBrowser;

        public MyNavigationEntryVisitor(Browser browser)
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
}
