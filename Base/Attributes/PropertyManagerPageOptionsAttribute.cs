using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.VPages.Sw.Attributes
{
    public class PropertyManagerPageOptionsAttribute : Attribute, IAttribute
    {
        public swPropertyManagerPageOptions_e Options { get; private set; }

        public PropertyManagerPageOptionsAttribute(swPropertyManagerPageOptions_e opts)
        {
            Options = opts;
        }
    }
}
