using CefSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Surfer.Utils
{
    public enum SBShortcutKeys
    {
        FocusUrlBox,
        Search1,
        Search2,
        ReloadNoCache,
        Reload,
        ViewSource,
        Inspect1,
        Inspect2,
        Print,
        CloseTab,
        SaveAs,
        ToggleFavorites,
        AddToFavorites,
        Undo,
        Redo,
        Cut,
        Copy,
        Paste,
        SelectAll,
    }
    public static class SBShortcutKeysExtensions
    {

        public static Keys ToKey(this SBShortcutKeys sbShortcutKeys)
        {
            switch (sbShortcutKeys)
            {
                case SBShortcutKeys.FocusUrlBox:
                    return Keys.F2;
                case SBShortcutKeys.Search1:
                    return Keys.F3;
                case SBShortcutKeys.Search2:
                    return (Keys.Control | Keys.F);
                case SBShortcutKeys.ReloadNoCache:
                    return (Keys.Control | Keys.F5);
                case SBShortcutKeys.Reload:
                    return Keys.F5;
                case SBShortcutKeys.ViewSource:
                    return (Keys.Control | Keys.U);
                case SBShortcutKeys.Inspect1:
                    return Keys.F12;
                case SBShortcutKeys.Inspect2:
                    return (Keys.Control | Keys.Alt | Keys.I);
                case SBShortcutKeys.Print:
                    return (Keys.Control | Keys.P);
                case SBShortcutKeys.CloseTab:
                    return (Keys.Control | Keys.W);
                case SBShortcutKeys.SaveAs:
                    return (Keys.Control | Keys.S);
                case SBShortcutKeys.ToggleFavorites:
                    return (Keys.Control | Keys.Shift | Keys.B);
                case SBShortcutKeys.AddToFavorites:
                    return (Keys.Control | Keys.D);
                case SBShortcutKeys.Undo:
                    return (Keys.Control | Keys.Z);
                case SBShortcutKeys.Redo:
                    return (Keys.Control | Keys.Y);
                case SBShortcutKeys.Cut:
                    return (Keys.Control | Keys.X);
                case SBShortcutKeys.Copy:
                    return (Keys.Control | Keys.C);
                case SBShortcutKeys.Paste:
                    return (Keys.Control | Keys.V);
                case SBShortcutKeys.SelectAll:
                    return (Keys.Control | Keys.A);
                default:
                    return Keys.None;
            }
        }
        public static bool IsPressed(this SBShortcutKeys sbShortcutKeys, CefEventFlags modifiers, Keys key)
        {
            switch (sbShortcutKeys)
            {
                case SBShortcutKeys.Search2:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.F)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.ReloadNoCache:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.F5)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.ViewSource:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.U)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.Inspect2:
                    return (modifiers == (CefEventFlags.ControlDown | CefEventFlags.AltDown) && key == Keys.I)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.Print:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.P)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.CloseTab:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.W)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.SaveAs:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.S)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.ToggleFavorites:
                    return (modifiers == (CefEventFlags.ControlDown | CefEventFlags.ShiftDown) && key == Keys.B)
                        || key == sbShortcutKeys.ToKey();
                case SBShortcutKeys.AddToFavorites:
                    return (modifiers == CefEventFlags.ControlDown && key == Keys.D)
                        || key == sbShortcutKeys.ToKey();
                default:
                    return key == sbShortcutKeys.ToKey();
            }
        }
        public static string ToText(this SBShortcutKeys sbShortcutKeys)
        {
            return TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString(sbShortcutKeys.ToKey());
        }
        private static string AddPlusToString(string text)
        {
            if (text.Length > 0)
            {
                text += " + ";
            }
            return text;
        }
    }
}
