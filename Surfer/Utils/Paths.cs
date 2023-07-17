using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public class Paths
    {
        private static FileVersionInfo VersionInfo
        {
            get
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            }
        }
        public static string Executable
        {
            get
            {
                return Application.ExecutablePath;
            }
        }
        public static string AppDataPath
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), VersionInfo.CompanyName, VersionInfo.ProductName);
                CreateDirectory(path);
                return path;
            }
        }
        public static string App(string file = "")
        {
            string path = Path.Combine(Path.GetDirectoryName(Executable), file);
            CreateDirectory(path);
            return path;
        }
        public static string AppData(string file = "")
        {
            string path = (string.IsNullOrEmpty(file) || string.IsNullOrWhiteSpace(file)) ? AppDataPath : Path.Combine(AppDataPath, file);
            CreateDirectory(path);
            return path;
        }
        public static string GetNameFromUrl(string url)
        {
            return url.Replace("/", "").Replace("https", "").Replace("http", "").Replace(":", "");
        }
        public static string BrowserCache(string file = "")
        {
            string path = Path.Combine(AppData("Cache"), file);
            CreateDirectory(path);
            return path;
        }
        public static void CreateDirectory(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new Exception("file path can not be null or empty");
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(file)))
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
            }
        }
    }
}
