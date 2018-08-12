using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageSelectionBoxStyleAttribute : Attribute, IAttribute
    {
        public swPropMgrPageSelectionBoxStyle_e Style { get; private set; }
        public short Height { get; private set; }
        public KnownColor SelectionColor { get; private set; }

        public PropertyManagerPageSelectionBoxStyleAttribute(
            swPropMgrPageSelectionBoxStyle_e style = 0, short height = -1,
            KnownColor selColor = 0)
        {
            Style = style;
            Height = height;
            SelectionColor = selColor;
        }
    }
}
