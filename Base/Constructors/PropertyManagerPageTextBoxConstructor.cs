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
    [DefaultType(typeof(string))]
    public class PropertyManagerPageTextBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageTextBoxEx, IPropertyManagerPageTextbox>
        where THandler : PropertyManagerPageHandler, new()
    {
        public PropertyManagerPageTextBoxConstructor()
            : base(swPropertyManagerPageControlType_e.swControlType_Textbox)
        {
        }

        protected override PropertyManagerPageTextBoxEx CreateControl(IPropertyManagerPageTextbox swCtrl, IAttributeSet atts, THandler handler)
        {
            if (atts.Has<PropertyManagerPageTextBoxStyleAttribute>())
            {
                var style = atts.Get<PropertyManagerPageTextBoxStyleAttribute>();

                if (style.Height != -1)
                {
                    swCtrl.Height = style.Height;
                }

                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }
            }

            return new PropertyManagerPageTextBoxEx(atts.Id, swCtrl, handler);
        }
    }
}
