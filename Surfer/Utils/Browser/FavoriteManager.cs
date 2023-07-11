using System;
using System.Collections.Generic;
using System.Drawing;

namespace Surfer.Utils.Browser
{
    public class FavoriteManager
    {
        public static bool IsInitialized = false;
        private readonly static string filePath = Paths.BrowserCache("Favorites" + JSON.Extension);

        public static List<Favorite> Get { get; set; } = new List<Favorite>();

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    Get = JSON.readFile<List<Favorite>>(filePath, Secrets.EncryptKey) ?? new List<Favorite>();
                }
                catch
                {
                    Get = new List<Favorite>();
                }
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(FavoriteManager).ToString() + " is already initialized!");
            }
        }
        public static void Save(Favorite favorite, Action onSaved = null)
        {
            if (IsInitialized)
            {
                int favoriteIndex = Get.FindIndex(f => f.Url == favorite.Url);
                if (favoriteIndex >= 0)
                    Get[favoriteIndex] = favorite;
                else
                    Get.Add(favorite);
                _write();
                onSaved?.Invoke();
            }
        }
        public static void Delete(string url, Action onDeleted = null)
        {
            if (IsInitialized)
            {
                int favoriteIndex = Get.FindIndex(f => f.Url == url);
                if (favoriteIndex >= 0)
                {
                    Get.RemoveAt(favoriteIndex);
                    _write();
                    onDeleted?.Invoke();
                }
            }
        }
        private static void _write()
        {
            JSON.writeFile(filePath, Get, Secrets.EncryptKey);
        }
    }
    public class Favorite
    {
        public byte[] Favicon;
        public string Title;
        public string Url;
        public Favorite(byte[] Favicon, string Title, string Url)
        {
            this.Favicon = Favicon;
            this.Title = Title;
            this.Url = Url;
        }
    }
}
