using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Surfer.Utils
{
    public class Language
    {
        public static readonly string Location = Paths.App("locales");
        public static string Current = Settings.Languages[0];

        public Language()
        {

        }
        public string accepted_languages = "accepted_languages";
        public string open_link_in_new_tab = "open_link_in_new_tab";
        public string copy_link = "copy_link";
        public string cut_w_key = "cut_w_key";
        public string copy_w_key = "copy_w_key";
        public string paste_w_key = "paste_w_key";
        public string select_all_w_key = "select_all_w_key";
        public string back = "back";
        public string forward = "forward";
        public string go_home = "go_home";
        public string reload_w_key = "reload_w_key";
        public string force_reload_w_key = "force_reload_w_key";
        public string view_source_w_key = "view_source_w_key";
        public string inspect_w_key = "inspect_w_key";
        public string show_site_information = "show_site_information";
        public string about_site = "about_site";
        public string conn_is_secure = "conn_is_secure";
        public string conn_is_not_secure = "conn_is_not_secure";
        public string new_tab = "new_tab";

        public static Language Get { get; set; } = new Language();
        public static Language GetL(string languageCode)
        {
            return GetClass(languageCode);
        }
        public static void Set(string languageCode)
        {
            Current = languageCode;
            Get = GetClass(languageCode);
        }
        private static Language GetClass(string languageCode)
        {
            try
            {
                return JSON.readFile<Language>(Path.Combine(Location, languageCode + ".sf")/*, Keys.EncryptKey*/) ?? new Language();
            }
            catch
            {
                return new Language();
            }
        }
    }
}
