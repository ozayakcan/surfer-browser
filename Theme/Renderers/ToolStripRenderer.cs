using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Surfer.Renderers
{
    public class ToolStripRenderer : ToolStripProfessionalRenderer
    {

        public ToolStripRenderer() : base(new MenuStripColorTable())
        {
            
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {

            if (e != null)
                e.ArrowColor = Theme.Get.ColorMenuArrow;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e != null)
            {
                var textRect = e.TextRectangle;
                textRect.Height = e.Item.Height - 4; // 4 is the default difference between the item height and the text rectangle height

                e.TextRectangle = textRect;
                //e.TextFormat = TextFormatFlags.VerticalCenter;
                e.TextColor = Theme.Get.ColorText;
            }
            base.OnRenderItemText(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e == null || !e.Item.Enabled)
                return;
            base.OnRenderMenuItemBackground(e);
        }

        /*protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            if (e != null)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rectImage = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
                rectImage.Inflate(-1, -1);

                using (var p = new Pen(Theme.Get.ColorCheckSquare, 1))
                {
                    g.DrawRectangle(p, rectImage);
                }

                var rectCheck = rectImage;
                rectCheck.Width = rectImage.Width - 6;
                rectCheck.Height = rectImage.Height - 8;
                rectCheck.X += 3;
                rectCheck.Y += 4;

                using (var p = new Pen(Theme.Get.ColorCheckMark, 2))
                {
                    g.DrawLines(p,
                        new Point[]{
                            new Point(rectCheck.Left, rectCheck.Bottom - System.Convert.ToInt32(rectCheck.Height / (double)2)),
                            new Point(rectCheck.Left + System.Convert.ToInt32(rectCheck.Width / (double)3), rectCheck.Bottom),
                            new Point(rectCheck.Right, rectCheck.Top)
                        });
                }
            }
        }*/
        private class MenuStripColorTable : ProfessionalColorTable
        {
            
            public override Color ToolStripDropDownBackground => Theme.Get.ColorBackground;

            public override Color MenuStripGradientBegin => Theme.Get.ColorBackground;

            public override Color MenuStripGradientEnd => Theme.Get.ColorBackground;

            public override Color CheckBackground => Theme.Get.ColorBackground;

            public override Color CheckPressedBackground => Theme.Get.ColorBackground;

            public override Color CheckSelectedBackground => Theme.Get.ColorBackground;

            public override Color MenuItemSelected => Theme.Get.ColorButtonHover;

            public override Color ImageMarginGradientBegin => Theme.Get.ColorBackground;

            public override Color ImageMarginGradientMiddle => Theme.Get.ColorBackground;

            public override Color ImageMarginGradientEnd => Theme.Get.ColorBackground;

            public override Color MenuItemBorder => Theme.Get.ColorButtonHover;

            public override Color MenuBorder => Theme.Get.ColorMenuBorder;

            public override Color SeparatorDark => Theme.Get.ColorSeparator;

            public override Color SeparatorLight => Theme.Get.ColorSeparator;

            public override Color StatusStripGradientBegin => Theme.Get.ColorStatusStripGradient;

            public override Color StatusStripGradientEnd => Theme.Get.ColorStatusStripGradient;

            public override Color ButtonSelectedGradientBegin => Theme.Get.ColorButtonSelected;

            public override Color ButtonSelectedGradientMiddle => Theme.Get.ColorButtonSelected;

            public override Color ButtonSelectedGradientEnd => Theme.Get.ColorButtonSelected;

            public override Color ButtonSelectedBorder => Theme.Get.ColorButtonSelected;
            public override Color ButtonPressedGradientBegin => Theme.Get.ColorButtonPressed;

            public override Color ButtonPressedGradientMiddle => Theme.Get.ColorButtonPressed;

            public override Color ButtonPressedGradientEnd => Theme.Get.ColorButtonPressed;

            public override Color ButtonPressedBorder => Theme.Get.ColorButtonPressed;
        }
    }
    
}
