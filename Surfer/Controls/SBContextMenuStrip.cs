using System.ComponentModel;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public class SBContextMenuStrip: ContextMenuStrip
    {
        public SBContextMenuStrip(IContainer container) : base(container)
        {
            RenderMode = ToolStripRenderMode.Professional;
            Renderer = new Renderers.ToolStripRenderer();
        }
    }
}
