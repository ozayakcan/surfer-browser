using Microsoft.Win32;
using System.Drawing;

namespace Surfer
{
    public class Theme
    {
        public static bool IsDark
        {
            get
            {
                try
                {
                    int res = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1);
                    return res == 0;
                }
                catch
                {
                    return false;
                }
            }
        }
        public Color ColorBackground;
        public Color ColorText;
        public Color ColorLink;

        public Color ColorMenuArrow;
        public Color ColorCheckSquare;
        public Color ColorCheckMark;

        public Color ColorMenuBorder;
        public Color ColorSeparator;
        public Color ColorStatusStripGradient;
        public Color ColorButtonSelected;
        public Color ColorButtonPressed;
        public Color ColorButtonHover;

        public static Theme Get
        {
            get{

                Theme theme = new Theme();
                if (IsDark)
                {
                    theme.ColorBackground = Color.FromArgb(43, 43, 43);
                    theme.ColorText = Color.FromArgb(237, 237, 237);
                    theme.ColorLink = Color.FromArgb(134, 191, 235);

                    theme.ColorMenuArrow = Color.FromArgb(237, 237, 237);
                    theme.ColorCheckSquare = Color.FromArgb(0, 122, 204);
                    theme.ColorCheckMark = Color.FromArgb(237, 237, 237);

                    theme.ColorMenuBorder = Color.FromArgb(61, 61, 67);
                    theme.ColorSeparator = Color.FromArgb(61, 61, 67);
                    theme.ColorStatusStripGradient = Color.FromArgb(234, 237, 241);
                    theme.ColorButtonSelected = Color.FromArgb(88, 146, 226);
                    theme.ColorButtonPressed = Color.FromArgb(110, 160, 230);
                    theme.ColorButtonHover = Color.FromArgb(76, 76, 77);
                }
                else
                {
                    theme.ColorBackground = Color.FromArgb(246, 246, 246);
                    theme.ColorText = Color.FromArgb(33, 33, 33);
                    theme.ColorLink = Color.FromArgb(0, 120, 212);

                    theme.ColorMenuArrow = Color.FromArgb(0, 122, 204);
                    theme.ColorCheckSquare = Color.FromArgb(0, 122, 204);
                    theme.ColorCheckMark = Color.FromArgb(19, 69, 99);

                    theme.ColorMenuBorder = Color.FromArgb(204, 206, 219);
                    theme.ColorSeparator = Color.FromArgb(224, 227, 230);
                    theme.ColorStatusStripGradient = Color.FromArgb(234, 237, 241);
                    theme.ColorButtonSelected = Color.FromArgb(88, 146, 226);
                    theme.ColorButtonPressed = Color.FromArgb(110, 160, 230);
                    theme.ColorButtonHover = Color.FromArgb(211, 211, 211);
                }
                return theme;
            }
        }
    }
}
