//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

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
