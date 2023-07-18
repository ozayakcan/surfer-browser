using System.IO;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public class DragDropHandler
    {
        public static bool IsValidUrl(DragEventArgs e, bool onlyLast = false)
        {
            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true) && e.Data.GetData(DataFormats.FileDrop, true) is string[] filePaths)
            {
                if (onlyLast)
                {
                    if (Path.GetExtension(filePaths[filePaths.Length -1]).ToLowerInvariant() != ".url")
                    {
                        dropEnabled = false;
                    }
                }
                else
                {
                    foreach (var filePath in filePaths)
                    {
                        if (Path.GetExtension(filePath).ToLowerInvariant() != ".url")
                        {
                            dropEnabled = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                dropEnabled = false;
            }
            return dropEnabled;
        }
    }
}
