//**********************
//SwEx.Pmp
//Copyright(C) 2018 www.codestack.net
//License: https://github.com/codestack-net-dev/vpages-sw/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.PMPage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.SwEx.PMPage.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;

namespace CodeStack.SwEx.PMPage.Constructors
{
    [DefaultType(typeof(bool))]
    internal class PropertyManagerPageCheckBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageCheckBoxEx, IPropertyManagerPageCheckbox>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageCheckBoxConstructor() 
            : base(swPropertyManagerPageControlType_e.swControlType_Checkbox)
        {
        }

        protected override PropertyManagerPageCheckBoxEx CreateControl(
            IPropertyManagerPageCheckbox swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            return new PropertyManagerPageCheckBoxEx(atts.Id, swCtrl, handler);
        }
    }
}
