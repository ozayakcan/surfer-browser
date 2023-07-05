using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surfer.Utils
{
    public class FileHandler
    {
        public static FileStream Write(string path, string content)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
                fs.Write(contentBytes, 0, contentBytes.Length);
                return fs;
            }
        }
        public static string Read(string path)
        {
            return File.ReadAllText(path, Encoding.Default);
        }
    }
}
