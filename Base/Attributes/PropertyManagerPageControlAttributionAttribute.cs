using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageControlAttributionAttribute : Attribute, IAttribute
    {
        public swControlBitmapLabelType_e StandardIcon { get; private set; } = 0;

        public PropertyManagerPageControlAttributionAttribute(swControlBitmapLabelType_e standardIcon)
        {
            StandardIcon = standardIcon;
        }
    }
}
