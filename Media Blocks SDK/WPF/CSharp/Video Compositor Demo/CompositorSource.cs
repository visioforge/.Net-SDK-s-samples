using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;

namespace Video_Compositor_Demo
{
    internal class CompositorSource
    {
        public MediaBlock Source { get; set; }

        public Rect Rectangle { get; set; }
    }
}
