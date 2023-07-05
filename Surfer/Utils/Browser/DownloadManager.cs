using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Surfer.Utils.Browser
{
    class DownloadManager
    {
        public static bool IsInitialized = false;
        public static readonly string Extension = JSON.Extension + "download";
        private readonly static string filePath = Paths.BrowserCache("Downloads"+JSON.Extension);

        public static List<DownloadFile> Get { get; set; } = new List<DownloadFile>();

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    Get = JSON.readFile<List<DownloadFile>>(filePath, Secrets.EncryptKey) ?? new List<DownloadFile>();

                }
                catch
                {
                    Get = new List<DownloadFile>();
                }
                bool _idsUpdated = false;
                foreach(var item in Get)
                {
                    if(item.DownloadID != 0)
                    {
                        item.DownloadID = 0;
                        _idsUpdated = true;
                    }
                    if (File.Exists(item.TempLocation))
                        File.Delete(item.TempLocation);
                }
                if (_idsUpdated)
                    _write();
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(DownloadManager).ToString() + " is already initialized!");
            }
        }
        public static void Save(DownloadFile downloadFile = null)
        {
            if (IsInitialized)
            {
                if(downloadFile != null)
                {
                    int downloadFileIndex = Get.FindIndex((d) => d.ID == downloadFile.ID);
                    if (downloadFileIndex >= 0)
                        Get[downloadFileIndex] = downloadFile;
                    else
                        Get.Insert(0, downloadFile);
                }
                _write();
            }
        }
        public static void Remove(DownloadFile downloadFile)
        {
            if (IsInitialized)
            {
                Get.Remove(downloadFile);
                _write();
            }
        }
        public static void Reset()
        {
            if (IsInitialized)
            {
                for (int i = 0; i < Get.Count; i++)
                {
                    if (Get[i].DownloadID != 0)
                        Get[i].DownloadID = 0;
                    if (!Get[i].Completed)
                    {
                        Get[i].ReceivedBytes = 0;
                        Get[i].TotalBytes = 0;
                        Get[i].CurrentSpeed = 0;
                    }
                }
                _write();
            }
        }
        private static void _write()
        {
            JSON.writeFile(filePath, Get, Secrets.EncryptKey);
        }
        public static string Location = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
        public static string GetFileName(string fileName, int current = 0, bool overwrite = false, string newExt = null)
        {
            string ext = Path.GetExtension(fileName);
            string location = Location + Path.GetFileNameWithoutExtension(fileName);
            if (!overwrite)
                location += (current > 0 ? "(" + current + ")" : "");
            location += string.IsNullOrEmpty(newExt) ? (!string.IsNullOrEmpty(ext) ? ext : "") : newExt;
            if (File.Exists(location) && !overwrite)
                return GetFileName(fileName, current + 1);
            else
                return location;
        }
        public static int LastID()
        {
            if (Get.Count > 0)
                return Get.Max(d => d.ID) + 1;
            else
                return 1;
        }
    }
    public class DownloadFile
    {
        public int ID;
        public int DownloadID;
        public string FileName;
        public string Extension;
        public string Location;
        public string TempLocation;
        public string Url;
        public DateTime Date;
        public long ReceivedBytes = 0;
        public long TotalBytes = 0;
        public long CurrentSpeed = 0;
        public bool Completed = false;
        public bool IsWebPage = false;
        public DownloadFile(int ID, int DownloadID, string FileName, string Extension, string Location, string TempLocation, string Url, DateTime Date)
        {
            this.ID = ID;
            this.DownloadID = DownloadID;
            this.FileName = FileName;
            this.Extension = Extension;
            this.Location = Location;
            this.TempLocation = TempLocation;
            this.Url = Url;
            this.Date = Date;
        }
    }
}
