using CodeStack.VPages.Sw.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Constructors;
using Xarial.VPages.Framework.Base;
using SolidWorks.Interop.swconst;
using CodeStack.VPages.Sw.Attributes;
using System.Drawing;
using SolidWorks.Interop.sldworks;

namespace CodeStack.VPages.Sw.Constructors
{
    [DefaultType(typeof(int))]
    [DefaultType(typeof(double))]
    public class PropertyManagerPageNumberBoxConstructor<THandler>
        : PropertyManagerPageControlConstructor<THandler, PropertyManagerPageNumberBox, SolidWorks.Interop.sldworks.IPropertyManagerPageNumberbox>
        where THandler : PropertyManagerPageHandler, new()
    {
        public PropertyManagerPageNumberBoxConstructor() 
            : base(swPropertyManagerPageControlType_e.swControlType_Numberbox)
        {
        }

        protected override PropertyManagerPageNumberBox CreateControl(IPropertyManagerPageNumberbox swCtrl, IAttributeSet atts, THandler handler)
        {
            if (atts.Has<PropertyManagerPageNumberBoxStyleAttribute>())
            {
                var style = atts.Get<PropertyManagerPageNumberBoxStyleAttribute>();

                if (style.Height != -1)
                {
                    swCtrl.Height = style.Height;
                }

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

            return new PropertyManagerPageNumberBox(atts.Id, swCtrl, handler);
        }
    }
}
