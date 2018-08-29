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
    [DefaultType(typeof(int))]
    [DefaultType(typeof(double))]
    internal class PropertyManagerPageNumberBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageNumberBoxEx, IPropertyManagerPageNumberbox>
        where THandler : PropertyManagerPageHandlerEx, new()
    {
        public PropertyManagerPageNumberBoxConstructor() 
            : base(swPropertyManagerPageControlType_e.swControlType_Numberbox)
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

            return new PropertyManagerPageNumberBoxEx(atts.Id, swCtrl, handler);
        }
    }
}
