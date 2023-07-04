using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Surfer.Utils
{
    public class Locale
    {
        public static readonly string Location = Paths.App("locales");
        public static string Current = Settings.Locales[0];

        public Locale()
        {

        }
        public string accepted_languages = "accepted_languages";
        public string open_link_in_new_tab = "open_link_in_new_tab";
        public string copy_link = "copy_link";
        public string cut = "cut";
        public string copy = "copy";
        public string paste = "paste";
        public string select_all = "select_all";
        public string back = "back";
        public string forward = "forward";
        public string go_home = "go_home";
        public string reload = "reload";
        public string reload_w_key = "reload_w_key";
        public string force_reload = "force_reload";
        public string view_source = "view_source";
        public string inspect = "inspect";
        public string show_site_information = "show_site_information";
        public string about_site = "about_site";
        public string conn_is_secure = "conn_is_secure";
        public string conn_is_not_secure = "conn_is_not_secure";
        public string new_tab = "new_tab";
        public string print = "print";
        public string save_as = "save_as";
        public string downloads = "downloads";
        public string open_file = "open_file";
        public string download_vars = "download_vars";
        public string download_speed = "download_speed";
        public string download_rem_time_days = "download_rem_time_days";
        public string download_rem_time_hours = "download_rem_time_hours";
        public string download_rem_time_minutes = "download_rem_time_minutes";
        public string download_rem_time_seconds = "download_rem_time_seconds";

        public static Locale Get { get; set; } = new Locale();
        public static Locale GetL(string localeCode)
        {
            return GetClass(localeCode);
        }
        public static void Set(string localeCode)
        {
            Current = localeCode;
            Get = GetClass(localeCode);
        }
        private static Locale GetClass(string localeCode)
        {
            try
            {
                return JSON.readFile<Locale>(Path.Combine(Location, localeCode + JSON.Extension)/*, Keys.EncryptKey*/) ?? new Locale();
            }
            catch
            {
                return new Locale();
            }
        }
    }
}
