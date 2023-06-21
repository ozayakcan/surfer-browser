using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Surfer.Utils
{
    public class JSON
    {
        private const string empty = "{}";
        private static void createFile(string filePath, string content = "", string password = null, string emptyContent = empty)
        {
            if (File.Exists(filePath) && !content.Equals(""))
            {
                File.Delete(filePath);
            }
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] contentBytes = new UTF8Encoding(true).GetBytes(content.Equals("") ? (password == null ? emptyContent : StringCipher.Encrypt(emptyContent, password)) : (password == null ? content : StringCipher.Encrypt(content, password)));
                    fs.Write(contentBytes, 0, contentBytes.Length);
                }
            }
        }
        public static Dictionary<string, T> read<T>(string text)
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, T>>(text);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Json Read Error: " + e.ToString());
                Debug.WriteLine("Json Text: " + text);
                throw e;
            }
        }
        public static Dictionary<string, T> readObject<T>(object obj)
        {
            try
            {
                return ((JObject)obj).ToDict<string, T>();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Json Read Error: " + e.ToString());
                throw e;
            }
        }

        public static T readObject<T>(string text)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Json Read Error: " + e.ToString());
                Debug.WriteLine("Json Text: " + text);
                throw e;
            }
        }
        public static T readFile<T>(string filePath, string password = null)
        {
            try
            {
                if(typeof(T) == typeof(List<object>))
                    createFile(filePath, password: password, emptyContent: "[]");
                else
                    createFile(filePath, password: password);
                string text = File.ReadAllText(filePath, Encoding.Default);
                return JsonConvert.DeserializeObject<T>(password == null ? text : StringCipher.Decrypt(text, password));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Json Read Error: " + e.ToString());
                throw e;
            }
        }
        public static void writeFile<T>(string filePath, T obj, string password = null)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                createFile(filePath, json, password);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Json Write Error: " + e.ToString());
                throw e;
            }
        }
    }
}
