using Surfer;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Win32Interop.Enums;

namespace EasyTabs
{
    public class WindowsSizingBoxes
    {
        protected TitleBarTabs _parentWindow;
        protected Image _minimizeLightImage = null;
        protected Image _minimizeDarkImage = null;
        protected Image _restoreLightImage = null;
        protected Image _restoreDarkImage = null;
        protected Image _maximizeLightImage = null;
        protected Image _maximizeDarkImage = null;
        protected Image _closeLightImage = null;
        protected Image _closeDarkImage = null;
        protected Image _closeHighlightImage = null;
        protected Brush _closeButtonHighlight = new SolidBrush(Color.FromArgb(232, 17, 35));
        protected Rectangle _minimizeButtonArea = new Rectangle(0, 0, 45, 29);
        protected Rectangle _maximizeRestoreButtonArea = new Rectangle(45, 0, 45, 29);
        protected Rectangle _closeButtonArea = new Rectangle(90, 0, 45, 29);

        public WindowsSizingBoxes(TitleBarTabs parentWindow)
        {
            _parentWindow = parentWindow;
            _minimizeLightImage = LoadSvg(Encoding.UTF8.GetString(Resources.MinimizeLight), 10, 10);
            _minimizeDarkImage = LoadSvg(Encoding.UTF8.GetString(Resources.MinimizeDark), 10, 10);
            _restoreLightImage = LoadSvg(Encoding.UTF8.GetString(Resources.RestoreLight), 10, 10);
            _restoreDarkImage = LoadSvg(Encoding.UTF8.GetString(Resources.RestoreDark), 10, 10);
            _maximizeLightImage = LoadSvg(Encoding.UTF8.GetString(Resources.MaximizeLight), 10, 10);
            _maximizeDarkImage = LoadSvg(Encoding.UTF8.GetString(Resources.MaximizeDark), 10, 10);
            _closeLightImage = LoadSvg(Encoding.UTF8.GetString(Resources.CloseLight), 10, 10);
            _closeDarkImage = LoadSvg(Encoding.UTF8.GetString(Resources.CloseDark), 10, 10);
            _closeHighlightImage = LoadSvg(Encoding.UTF8.GetString(Resources.CloseHighlight), 10, 10);
        }

        protected Image LoadSvg(string svgXml, int width, int height)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(svgXml);

            return SvgDocument.Open(xmlDocument).Draw(width, height);
        }

        public int Width
        {
            get
            {
                return _minimizeButtonArea.Width + _maximizeRestoreButtonArea.Width + _closeButtonArea.Width;
            }
        }

        public bool Contains(Point cursor)
        {
            return _minimizeButtonArea.Contains(cursor) || _maximizeRestoreButtonArea.Contains(cursor) || _closeButtonArea.Contains(cursor);
        }

        public void Render(Graphics graphicsContext, Point cursor)
        {
            int right = _parentWindow.ClientRectangle.Width;
            bool closeButtonHighlighted = false;
            
            _minimizeButtonArea.X = right - 135;
            _maximizeRestoreButtonArea.X = right - 90;
            _closeButtonArea.X = right - 45;

            if (_minimizeButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(new SolidBrush(Theme.Get.ColorButtonHover), _minimizeButtonArea);
            }

            else if (_maximizeRestoreButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(new SolidBrush(Theme.Get.ColorButtonHover), _maximizeRestoreButtonArea);
            }

            else if (_closeButtonArea.Contains(cursor))
            {
                graphicsContext.FillRectangle(_closeButtonHighlight, _closeButtonArea);
                closeButtonHighlighted = true;
            }

            graphicsContext.DrawImage(closeButtonHighlighted ? _closeHighlightImage : Theme.IsDark ? _closeDarkImage : _closeLightImage, _closeButtonArea.X + 17, _closeButtonArea.Y + 9);
            graphicsContext.DrawImage(_parentWindow.WindowState == FormWindowState.Maximized ? (Theme.IsDark ? _restoreDarkImage : _restoreLightImage) : (Theme.IsDark ? _maximizeDarkImage : _maximizeLightImage), _maximizeRestoreButtonArea.X + 17, _maximizeRestoreButtonArea.Y + 9);
            graphicsContext.DrawImage(Theme.IsDark ? _minimizeDarkImage : _minimizeLightImage, _minimizeButtonArea.X + 17, _minimizeButtonArea.Y + 9);
        }

        public HT NonClientHitTest(Point cursor)
        {
            if (_minimizeButtonArea.Contains(cursor))
            {
                return HT.HTMINBUTTON;
            }

            else if (_maximizeRestoreButtonArea.Contains(cursor))
            {
                return HT.HTMAXBUTTON;
            }

            else if (_closeButtonArea.Contains(cursor))
            {
                return HT.HTCLOSE;
            }

            return HT.HTNOWHERE;
        }
    }
}
