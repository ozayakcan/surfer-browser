using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public class Args
    {
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void ExecuteAsAdmin(string[] args)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = string.Join(" ", args);
            proc.Start();
        }
        public static void RegisterApp(string _appName, string _appPath, string _appID, string _appDescription)
        {
            string pfadschluessel = "SOFTWARE\\Clients\\StartMenuInternet\\" + _appName;
            string pfadschluessel_cap = pfadschluessel + "\\Capabilities";
            string pfadschluessel_cap_fileA = pfadschluessel_cap + "\\FileAssociations";
            string pfadschluessel_cap_Startmenu = pfadschluessel_cap + "\\Startmenu";
            string pfadschluessel_cap_URL = pfadschluessel_cap + "\\URLAssociations";
            Registry.LocalMachine.CreateSubKey(pfadschluessel).SetValue("", _appName);
            Registry.LocalMachine.CreateSubKey(pfadschluessel).SetValue("LocalizedString", "@" + _appPath);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap).SetValue("ApplicationDescription", _appDescription);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap).SetValue("ApplicationIcon", _appPath + ",0");
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap).SetValue("ApplicationName", _appName);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_fileA).SetValue(".htm", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_fileA).SetValue(".html", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_fileA).SetValue(".shtml", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_fileA).SetValue(".xhtml", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_fileA).SetValue(".xht", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_Startmenu).SetValue("StartMenuInternet", _appName);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_URL).SetValue("ftp", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_URL).SetValue("http", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_URL).SetValue("https", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_URL).SetValue("mailto", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel_cap_URL).SetValue("webcal", _appID);
            Registry.LocalMachine.CreateSubKey(pfadschluessel + "\\DefaultIcon").SetValue("", _appPath + ",0");
            Registry.LocalMachine.CreateSubKey(pfadschluessel + "\\InstallInfo").SetValue("", "");
            Registry.LocalMachine.CreateSubKey(pfadschluessel + "\\shell\\open\\command").SetValue("", "\"" + _appPath + "\"");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\.htm\\OpenWithProgIds").SetValue(_appID, "");
            string PFAD_software_ = "SOFTWARE\\" + _appName;
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities").SetValue("ApplicationDescription", _appDescription);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities").SetValue("ApplicationName", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities").SetValue("ApplicationIcon", _appPath);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\FileAssociations").SetValue(".htm", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\FileAssociations").SetValue(".html", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\FileAssociations").SetValue(".shtml", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\FileAssociations").SetValue(".xhtml", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\FileAssociations").SetValue(".xht", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\Startmenu").SetValue("StartmenuInternet", _appPath);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\UrlAssociations").SetValue("ftp", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\UrlAssociations").SetValue("http", _appID);
            Registry.LocalMachine.CreateSubKey(PFAD_software_ + "\\Capabilities\\UrlAssociations").SetValue("https", _appID);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\RegisteredApplications").SetValue(_appName, PFAD_software_ + "\\Capabilities");
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\RegisteredApplications").SetValue(_appName, PFAD_software_ + "\\Capabilities");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID).SetValue("FriendlyTypeName", _appName);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID).SetValue("Editflags", 2);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID + "\\DefaultIcon").SetValue("", _appPath + ",0");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID + "\\shell\\open\\command").SetValue("", "\"" + _appPath + "\"%1");
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\" + _appName + ".exe").SetValue("Path", _appPath);
            Registry.ClassesRoot.CreateSubKey(_appID + "\\DefaultIcon").SetValue("", _appPath + ",0");
            Registry.ClassesRoot.CreateSubKey(_appID + "\\shell\\open\\command").SetValue("", "\"" + _appPath + "\"%1");
            Registry.ClassesRoot.CreateSubKey(_appID).SetValue("AppUserModelId", _appName);
            Registry.ClassesRoot.CreateSubKey(_appID + "\\Application").SetValue("ApplicationDescription", _appDescription);
            Registry.ClassesRoot.CreateSubKey(_appID + "\\Application").SetValue("ApplicationName", _appName);
            Registry.ClassesRoot.CreateSubKey(_appID + "\\Application").SetValue("ApplicationIcon", _appPath);
            Registry.LocalMachine.CreateSubKey(pfadschluessel + "\\DefaultIcon").SetValue("", _appPath + ",0");
            Registry.LocalMachine.CreateSubKey(pfadschluessel + "\\shell\\open\\command").SetValue("", _appPath);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\RegisteredApplications").SetValue(_appName, pfadschluessel_cap);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID).SetValue("FriendlyTypeName", _appName);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID).SetValue("Editflags", 2);
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID + "\\DefaultIcon").SetValue("", _appPath + ",0");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\" + _appID + "\\shell\\open\\command").SetValue("", "\"" + _appPath + "\"%1");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\MDK\\" + _appID + "\\Capabilities").SetValue("ApplicationName", _appName);
            Settings.Global.Save(nameof(Settings.AddedToDefaults), true);
        }
    }
}
