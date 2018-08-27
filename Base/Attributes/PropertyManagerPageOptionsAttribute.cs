//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Base;

namespace CodeStack.SwEx.Pmp.Attributes
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
