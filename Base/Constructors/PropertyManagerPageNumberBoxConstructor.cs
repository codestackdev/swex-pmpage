//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
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
using CodeStack.SwEx.Common.Icons;

namespace CodeStack.SwEx.PMPage.Constructors
{
    [DefaultType(typeof(int))]
    [DefaultType(typeof(double))]
    internal class PropertyManagerPageNumberBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageNumberBoxEx, IPropertyManagerPageNumberbox>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageNumberBoxConstructor(ISldWorks app, IconsConverter iconsConv) 
            : base(app, swPropertyManagerPageControlType_e.swControlType_Numberbox, iconsConv)
        {
        }

        protected override PropertyManagerPageNumberBoxEx CreateControl(
            IPropertyManagerPageNumberbox swCtrl, IAttributeSet atts, THandler handler, short height)
        {
            if (height != -1)
            {
                swCtrl.Height = height;
            }

            if (atts.Has<NumberBoxOptionsAttribute>())
            {
                var style = atts.Get<NumberBoxOptionsAttribute>();
                
                if (style.Style != 0)
                {
                    swCtrl.Style = (int)style.Style;
                }

                if (style.Units != 0)
                {
                    swCtrl.SetRange2((int)style.Units, style.Minimum, style.Maximum,
                        style.Inclusive, style.Increment, style.FastIncrement, style.SlowIncrement);
                }
            }

            return new PropertyManagerPageNumberBoxEx(atts.Id, atts.Tag, swCtrl, handler);
        }
    }
}
