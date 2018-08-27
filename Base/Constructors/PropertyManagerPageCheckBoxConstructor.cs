//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Pmp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.Pmp.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;

namespace CodeStack.SwEx.Pmp.Constructors
{
    [DefaultType(typeof(bool))]
    public class PropertyManagerPageCheckBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageCheckBoxEx, IPropertyManagerPageCheckbox>
        where THandler : PropertyManagerPageHandler, new()
    {
        public PropertyManagerPageCheckBoxConstructor() 
            : base(swPropertyManagerPageControlType_e.swControlType_Checkbox)
        {
        }

        protected override PropertyManagerPageCheckBoxEx CreateControl(
            IPropertyManagerPageCheckbox swCtrl, IAttributeSet atts, THandler handler)
        {
            return new PropertyManagerPageCheckBoxEx(atts.Id, swCtrl, handler);
        }
    }
}
