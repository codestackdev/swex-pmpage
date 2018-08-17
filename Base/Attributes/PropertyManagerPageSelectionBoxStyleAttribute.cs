//**********************
//vPages for SOLIDWORKS
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/vpages/
//**********************

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
