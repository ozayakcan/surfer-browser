using CefSharp;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public class ShortcutKeys
    {
        public static Keys FocusUrlBox = Keys.F2;
        public static bool IsFocusUrlBox(CefEventFlags modifiers, Keys key)
        {
            return key == FocusUrlBox;
        }

        public static Keys Search1 = Keys.F3;
        public static Keys Search2 = (Keys.Control | Keys.F);
        public static bool IsSearch(CefEventFlags modifiers, Keys key)
        {
            return key == Search1
                || (modifiers == CefEventFlags.ControlDown && key == Keys.F)
                || key == Search2;
        }

        public static Keys ReloadNoCache = (Keys.Control | Keys.F5);
        public static bool IsReloadNoCache(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == CefEventFlags.ControlDown && key == Keys.F5) || key == ReloadNoCache;
        }

        public static Keys Reload = Keys.F5;
        public static bool IsReload(CefEventFlags modifiers, Keys key)
        {
            return key == Reload;
        }

        public static Keys ViewSource = (Keys.Control | Keys.U);
        public static bool IsViewSource(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == CefEventFlags.ControlDown && key == Keys.U) || key == ViewSource;
        }

        public static Keys Inspect1 = Keys.F12;
        public static Keys Inspect2 = (Keys.Control | Keys.Alt | Keys.I);
        public static bool IsInspect(CefEventFlags modifiers, Keys key)
        {
            return key == Inspect1
                || (modifiers == (CefEventFlags.ControlDown | CefEventFlags.AltDown) && key == Keys.I)
                || key == Inspect2;
        }

        public static Keys Print = (Keys.Control | Keys.P);
        public static bool IsPrint(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == CefEventFlags.ControlDown && key == Keys.P)
                || key == Print;
        }

        public static Keys CloseTab = (Keys.Control | Keys.W);
        public static bool IsCloseTab(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == CefEventFlags.ControlDown && key == Keys.W)
                || key == CloseTab;
        }

        public static Keys SaveAs = (Keys.Control | Keys.S);
        public static bool IsSaveAs(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == CefEventFlags.ControlDown && key == Keys.S)
                || key == SaveAs;
        }

        public static Keys ToggleFavorites = (Keys.Control | Keys.Shift | Keys.B);
        public static bool IsToggleFavorites(CefEventFlags modifiers, Keys key)
        {
            return (modifiers == (CefEventFlags.ControlDown | CefEventFlags.ShiftDown) && key == Keys.B)
                || key == ToggleFavorites;
        }

        public static Keys Undo = (Keys.Control | Keys.Z);
        public static Keys Cut = (Keys.Control | Keys.X);
        public static Keys Copy = (Keys.Control | Keys.C);
        public static Keys Paste = (Keys.Control | Keys.V);
        public static Keys SelectAll = (Keys.Control | Keys.A);
    }
}
