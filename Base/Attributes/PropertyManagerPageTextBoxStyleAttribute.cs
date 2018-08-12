using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageTextBoxStyleAttribute : Attribute, IAttribute
    {
        public swPropMgrPageTextBoxStyle_e Style { get; private set; }
        public short Height { get; private set; }

        public PropertyManagerPageTextBoxStyleAttribute(swPropMgrPageTextBoxStyle_e style = 0, short height = -1)
        {
            Style = style;
            Height = height;
        }
    }
}
