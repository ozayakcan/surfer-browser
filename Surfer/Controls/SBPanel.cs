using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Surfer.Utils;

namespace Surfer.Controls
{
    public class SBPanel : Panel
    {
        private Color _defaultBorderColor = Color.Black;
        private Color? _borderColor;
        public Color BorderColor
        {
            get
            {
                if (_borderColor != null) return (Color)_borderColor;
                return _defaultBorderColor;
            }
            set
            {
                _borderColor = value;
                _pen = new Pen(value, BorderThickness);
                Invalidate();
            }
        }
        private bool ShouldSerializeBorderColor()
        {
            return _borderColor != null;
        }
        private void ResetBorderColor()
        {
            BorderColor = _defaultBorderColor;
        }

        private int _defaultBorderRadius
        {
            get { return 0; }
        }
        private int? _borderRadius;
        public int BorderRadius
        {
            get
            {
                if (_borderRadius != null) return (int)_borderRadius;
                return _defaultBorderRadius;
            }
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }
        private bool ShouldSerializeBorderRadius()
        {
            return _borderRadius != null;
        }
        private void ResetBorderRadius()
        {
            BorderRadius = _defaultBorderRadius;
        }

        private float _defaultBorderThickness
        {
            get { return 1; }
        }
        private float? _borderThickness;
        public float BorderThickness
        {
            get {
                if (_borderThickness != null) return (float)_borderThickness;
                return _defaultBorderThickness;
            } 
            set
            {
                if(value <= 0.00f)
                {
                    throw new Exception("BorderThickness must be minumum 0,01.");
                }
                else
                {
                    _borderThickness = value;
                    _pen = new Pen(BorderColor, value);
                    Invalidate();
                }
            }
        }
        private bool ShouldSerializeBorderThickness()
        {
            return _borderThickness != null;
        }
        private void ResetBorderThickness()
        {
            BorderThickness = _defaultBorderThickness;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get => base.BorderStyle;
            set => base.BorderStyle = value;
        }
        private bool ShouldSerializeBorderStyle()
        {
            return false;
        }

        private Pen _pen;

        public SBPanel() : base()
        {
            _pen = new Pen(BorderColor, BorderThickness);
            DoubleBuffered = true;
        }
        private Rectangle GetLeftUpper(int e)
        {
            return new Rectangle(0, 0, e, e);
        }
        private Rectangle GetRightUpper(int e)
        {
            return new Rectangle(Width - e, 0, e, e);
        }
        private Rectangle GetRightLower(int e)
        {
            return new Rectangle(Width - e, Height - e, e, e);
        }
        
        private Rectangle GetLeftLower(int e)
        {
            return new Rectangle(0, Height - e, e, e);
        }

        private void ExtendedDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(GetLeftUpper(BorderRadius), 180, 90);
            path.AddLine(BorderRadius, 0, Width - BorderRadius, 0);
            path.AddArc(GetRightUpper(BorderRadius), 270, 90);
            path.AddLine(Width, BorderRadius, Width, Height - BorderRadius);
            path.AddArc(GetRightLower(BorderRadius), 0, 90);
            path.AddLine(Width - BorderRadius, Height, BorderRadius, Height);
            path.AddArc(GetLeftLower(BorderRadius), 90, 90);
            path.AddLine(0, Height - BorderRadius, 0, BorderRadius);
            path.CloseFigure();
            Region = new Region(path);
        }
        private void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(_pen, new Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90);
            graphics.DrawArc(_pen, new Rectangle(Width - BorderRadius - 1, -1, BorderRadius, BorderRadius), 270, 90);
            graphics.DrawArc(_pen, new Rectangle(Width - BorderRadius - 1, Height - BorderRadius - 1, BorderRadius, BorderRadius), 0, 90);
            graphics.DrawArc(_pen, new Rectangle(0, Height - BorderRadius - 1, BorderRadius, BorderRadius), 90, 90);
            graphics.DrawRectangle(_pen, 0.0f, 0.0f, (float)Width - 1.0f, (float)Height - 1.0f);
        }
        private void Draw3DBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
        private void DrawBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderRadius > 0)
            {
                ExtendedDraw(e);
                DrawBorder(e.Graphics);
            }
        }
    }
}
