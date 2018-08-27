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
    public class PropertyManagerPageComboBoxStyleAttribute : Attribute, IAttribute
    {
        public swPropMgrPageComboBoxStyle_e Style { get; private set; }
        public short Height { get; private set; }

        public PropertyManagerPageComboBoxStyleAttribute(swPropMgrPageComboBoxStyle_e style = 0, short height = -1)
        {
            Style = style;
            Height = height;
        }
    }
}
