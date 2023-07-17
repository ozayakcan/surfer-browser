using System;
using System.Drawing;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public partial class SBProgressBar : SBPanel
    {
        private int _Value = 0;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > ValueMax)
                    value = ValueMax;
                if (value < ValueMin)
                    value = ValueMin;
                _Value = value;
                if (value == 0)
                    pnlProgress.Width = 0;
                else if (value == ValueMax)
                    pnlProgress.Width = Width;
                else
                {
                    int progressWidth = (Width / ValueMax) * value;
                    pnlProgress.Width = progressWidth;
                }
            }
        }
        private bool ShouldSerializeValue()
        {
            return _Value > ValueMin;
        }
        private void ResetValue()
        {
            Value = ValueMin;
        }
        private int _defaultValueMin = 0;
        private int? _ValueMin;
        public int ValueMin
        {
            get
            {
                if (_ValueMin != null) return (int)_ValueMin;
                return _defaultValueMin;
            }
            set
            {
                if (value < 0)
                    throw new Exception("ValueMin can not be less than 0");
                else if (value >= ValueMax)
                    throw new Exception("ValueMin can not be equal or more than ValueMax");
                else
                {
                    _ValueMin = value;
                    if (Value < value)
                        Value = value;
                }
            }
        }
        private bool ShouldSerializeValueMin()
        {
            return _ValueMin != _defaultValueMin;
        }
        private void ResetValueMin()
        {
            ValueMin = _defaultValueMin;
        }
        private int _defaultValueMax = 100;
        private int? _ValueMax;
        public int ValueMax
        {
            get
            {
                if (_ValueMax != null) return (int)_ValueMax;
                return _defaultValueMax;
            }
            set
            {
                if(value <= 0)
                    throw new Exception("ValueMax can not be less than 1");
                else if(value <= ValueMin)
                    throw new Exception("ValueMax can not be equal or less than ValueMin");
                else
                {
                    _ValueMax = value;
                    if (Value > value)
                        Value = value;
                }
            }
        }
        private bool ShouldSerializeValueMax()
        {
            return _ValueMax != _defaultValueMax;
        }
        private void ResetValueMax()
        {
            ValueMax = _defaultValueMax;
        }
        private Color _defaultForeColor = Color.FromArgb(6, 176, 37);
        public override void ResetForeColor()
        {
            ForeColor = _defaultForeColor;
        }
        public SBProgressBar()
        {
            InitializeComponent();
            Controls.Add(pnlProgress);
            SizeChanged += SBProgressBar_SizeChanged;
            ForeColorChanged += SBProgressBar_ForeColorChanged;
            ForeColor = _defaultForeColor;
            InitializeProgressColor();
        }

        private void SBProgressBar_ForeColorChanged(object sender, EventArgs e)
        {
            InitializeProgressColor();
        }

        private void InitializeProgressColor()
        {
            pnlProgress.BackColor = ForeColor;
        }

        private void SBProgressBar_SizeChanged(object sender, EventArgs e)
        {
            Value = Value;
        }
    }
}
