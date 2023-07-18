using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public class DragDropHandler
    {
        public static bool IsValidFile(DragEventArgs e)
        {
            bool dropEnabled = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true) && e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths)
            {
                dropEnabled = true;
            }
            return dropEnabled;
        }
        private static readonly WshShell shell = new WshShell();
        public static dynamic[] GetFileList(DragEventArgs e)
        {
            List<dynamic> fileList = new List<dynamic>();
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                 e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths)
            {
               foreach(var filePath in filePaths)
                {
                    try
                    {
                        var wshShell = shell.CreateShortcut(filePath);
                        if(wshShell != null)
                        {
                            fileList.Add(wshShell);
                        }
                    }
                    catch { }
                }
            }
            return fileList.ToArray();
        }
    }
}
