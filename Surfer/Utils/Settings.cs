using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Surfer.Utils
{
    public class Settings
    {
        public Settings()
        {

        }
        public Settings(string filePath)
        {
            this.filePath = filePath;
        }

        public static Settings User = new Settings();
        public static Settings Global = new Settings(Paths.AppData(nameof(Settings).ToString() + ".sf"));

        // Keys

        public static readonly Dictionary<string, object> Defaults = new Dictionary<string, object>
        {
            
        };

        // End Keys
        public bool IsInitialized = false;
        private string filePath = Paths.BrowserCache(nameof(Settings).ToString() + ".sf");

        private Dictionary<string, object> SettingsDict { get; set; } = new Dictionary<string, object>();

        public void Initialize()
        {
            if (!IsInitialized)
            {
                try
                {
                    SettingsDict = JSON.readFile<Dictionary<string, object>>(filePath/*, Keys.EncryptKey*/) ?? new Dictionary<string, object>();
                }
                catch
                {
                    SettingsDict = new Dictionary<string, object>();
                }
                IsInitialized = true;
            }
            else
            {
                throw new Exception(typeof(Settings).ToString() + " is already initialized!");
            }
        }
        public void Save(string key, object value)
        {
            if (!IsInitialized)
                Initialize();
            if (SettingsDict.ContainsKey(key))
                SettingsDict[key] = value;
            else
                SettingsDict.Add(key, value);
            JSON.writeFile(filePath, SettingsDict/*, Keys.EncryptKey*/);
        }
        public T Get<T>(string key)
        {
            T defaultValue = Defaults.ContainsKey(key) ? (T)Defaults[key] : default(T);
            if (!IsInitialized)
                Initialize();
            if (SettingsDict.ContainsKey(key))
            {
                try
                {
                    return (T)SettingsDict[key];
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Could not get settings: " + e.ToString());
                    return defaultValue;
                }
            }
            else
            {
                Save(key, defaultValue);
                return defaultValue;
            }
        }
    }
}
