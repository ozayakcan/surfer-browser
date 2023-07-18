using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                foreach (var filePath in filePaths)
                {
                    Debug.WriteLine("IsValidFile: " + filePath);
                }
                dropEnabled = true;
            }
            return dropEnabled;
        }
        private static readonly WshShell shell = new WshShell();
        public static List<DragDropItem> GetFileList(DragEventArgs e)
        {
            List<DragDropItem> fileList = new List<DragDropItem>();
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                 e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths)
            {
               foreach(var filePath in filePaths)
                {
                    Debug.WriteLine("GetFileList: " + filePath);
                    try
                    {
                        var wshShell = shell.CreateShortcut(filePath);
                        if(wshShell != null)
                        {
                            DragDropItem dragDropItem = new DragDropItem();
                            if (wshShell.TargetPath != null)
                                dragDropItem.TargetPath = wshShell.TargetPath;
                            if (wshShell.FullName != null)
                                dragDropItem.FullName = wshShell.FullName;
                            fileList.Add(dragDropItem);
                        }
                    }
                    catch {
                        DragDropItem dragDropItem = new DragDropItem();
                        dragDropItem.TargetPath = filePath;
                        dragDropItem.FullName = filePath;
                        fileList.Add(dragDropItem);
                    }
                }
            }
            return fileList;
        }
    }
    public class DragDropItem
    {
        public string TargetPath = "";
        private string _fullName = "";
        public string FullName {
            get => _fullName;
            set
            {
                _fullName = value;
                Name = Path.GetFileNameWithoutExtension(value);
            }
        }
        public string Name = "";
        public DragDropItem()
        {

        }
    }
}
