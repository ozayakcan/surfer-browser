using Surfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Surfer.BrowserSettings
{
    public class HistoryManager
    {
        public static bool IsInitialized = false;
        private readonly static string filePath = Paths.BrowserCache("History.sf");

        public static List<History> Get { get; private set; } = new List<History>();

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    Get = JSON.readFile<List<History>>(filePath/*, Keys.EncryptKey*/);
                }
                catch
                {
                    Get = new List<History>();
                }
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(HistoryManager).ToString() + " is already initialized!");
            }

        }
        public static void Save(string url, bool increaseVisited = false, string title = "", string favicon = "", Action onSaved = null)
        {
            if (IsInitialized)
            {
                int historyIndex = Get.FindIndex(h => h.fullUrl == url || h.baseUrl == url);
                History history;
                if (historyIndex >= 0)
                    history = Get[historyIndex];
                else
                {
                    history = new History();
                    history.fullUrl = url;
                    string baseUrl = url.Replace("https://", "").Replace("http://", "");
                    if (baseUrl.StartsWith("www."))
                    {
                        baseUrl = baseUrl.Substring(4);
                    }
                    history.baseUrl = baseUrl;
                }
                if (!string.IsNullOrEmpty(title) && !string.IsNullOrWhiteSpace(title))
                    history.title = title;
                if (!string.IsNullOrEmpty(favicon) && !string.IsNullOrWhiteSpace(favicon))
                    history.favicon = favicon;
                if (increaseVisited)
                {
                    history.visited += 1;
                    history.lastVisited = DateTime.Now;
                }
                if (historyIndex >= 0)
                    Get[historyIndex] = history;
                else
                    Get.Add(history);
                JSON.writeFile(filePath, Get/*, Keys.EncryptKey*/);
                onSaved?.Invoke();
            }
        }
    }
    public class History
    {
        public string fullUrl;
        public string baseUrl;
        public string title;
        public string favicon;
        public int visited = 0;
        public DateTime lastVisited;
        public History()
        {

        }
    }
}
