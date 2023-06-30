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
